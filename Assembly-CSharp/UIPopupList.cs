using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Popup List")]
public class UIPopupList : UIWidgetContainer
{
	[DoNotObfuscateNGUI]
	public enum Position
	{
		Auto = 0,
		Above = 1,
		Below = 2
	}

	[DoNotObfuscateNGUI]
	public enum Selection
	{
		OnPress = 0,
		OnClick = 1
	}

	[DoNotObfuscateNGUI]
	public enum OpenOn
	{
		ClickOrTap = 0,
		RightClick = 1,
		DoubleClick = 2,
		Manual = 3
	}

	public delegate void LegacyEvent(string val);

	public static UIPopupList current;

	protected static GameObject mChild;

	protected static float mFadeOutComplete;

	private const float animSpeed = 0.15f;

	public UnityEngine.Object atlas;

	public UnityEngine.Object bitmapFont;

	public Font trueTypeFont;

	public int fontSize = 16;

	public FontStyle fontStyle;

	public string backgroundSprite;

	public string highlightSprite;

	public Sprite background2DSprite;

	public Sprite highlight2DSprite;

	public Position position;

	public Selection selection;

	public NGUIText.Alignment alignment = NGUIText.Alignment.Left;

	public List<string> items = new List<string>();

	public List<object> itemData = new List<object>();

	public List<Action> itemCallbacks = new List<Action>();

	public Vector2 padding = new Vector3(4f, 4f);

	public Color textColor = Color.white;

	public Color backgroundColor = Color.white;

	public Color highlightColor = new Color(0.88235295f, 40f / 51f, 0.5882353f, 1f);

	public bool isAnimated = true;

	public bool isLocalized;

	public UILabel.Modifier textModifier;

	public bool separatePanel = true;

	public int overlap;

	public OpenOn openOn;

	public List<EventDelegate> onChange = new List<EventDelegate>();

	[HideInInspector]
	[SerializeField]
	protected string mSelectedItem;

	[HideInInspector]
	[SerializeField]
	protected UIPanel mPanel;

	[HideInInspector]
	[SerializeField]
	protected UIBasicSprite mBackground;

	[HideInInspector]
	[SerializeField]
	protected UIBasicSprite mHighlight;

	[HideInInspector]
	[SerializeField]
	protected UILabel mHighlightedLabel;

	[HideInInspector]
	[SerializeField]
	protected List<UILabel> mLabelList = new List<UILabel>();

	[HideInInspector]
	[SerializeField]
	protected float mBgBorder;

	[Tooltip("Whether the selection will be persistent even after the popup list is closed. By default the selection is cleared when the popup is closed so that the same selection can be chosen again the next time the popup list is opened. If enabled, the selection will persist, but selecting the same choice in succession will not result in the onChange notification being triggered more than once.")]
	public bool keepValue;

	[NonSerialized]
	protected GameObject mSelection;

	[NonSerialized]
	protected int mOpenFrame;

	[HideInInspector]
	[SerializeField]
	private GameObject eventReceiver;

	[HideInInspector]
	[SerializeField]
	private string functionName = "OnSelectionChange";

	[HideInInspector]
	[SerializeField]
	private float textScale;

	[HideInInspector]
	[SerializeField]
	private UILabel textLabel;

	[NonSerialized]
	public Vector3 startingPosition;

	private LegacyEvent mLegacyEvent;

	[NonSerialized]
	protected bool mExecuting;

	[NonSerialized]
	protected bool mStarted;

	protected bool mTweening;

	public GameObject source;

	public INGUIFont font
	{
		get
		{
			if (bitmapFont != null)
			{
				if (bitmapFont is GameObject)
				{
					return (bitmapFont as GameObject).GetComponent<UIFont>();
				}
				return bitmapFont as INGUIFont;
			}
			return null;
		}
		set
		{
			bitmapFont = value as UnityEngine.Object;
			trueTypeFont = null;
		}
	}

	public UnityEngine.Object ambigiousFont
	{
		get
		{
			if (trueTypeFont != null)
			{
				return trueTypeFont;
			}
			if (bitmapFont != null)
			{
				if (bitmapFont is GameObject)
				{
					return (bitmapFont as GameObject).GetComponent<UIFont>();
				}
				return bitmapFont;
			}
			return null;
		}
		set
		{
			if (value is Font)
			{
				trueTypeFont = value as Font;
				bitmapFont = null;
			}
			else if (value is INGUIFont)
			{
				bitmapFont = value;
				trueTypeFont = null;
			}
			else if (value is GameObject)
			{
				bitmapFont = (value as GameObject).GetComponent<UIFont>();
				trueTypeFont = null;
			}
		}
	}

	[Obsolete("Use EventDelegate.Add(popup.onChange, YourCallback) instead, and UIPopupList.current.value to determine the state")]
	public LegacyEvent onSelectionChange
	{
		get
		{
			return mLegacyEvent;
		}
		set
		{
			mLegacyEvent = value;
		}
	}

	public static bool isOpen
	{
		get
		{
			if (current != null)
			{
				if (!(mChild != null))
				{
					return mFadeOutComplete > Time.unscaledTime;
				}
				return true;
			}
			return false;
		}
	}

	public virtual string value
	{
		get
		{
			return mSelectedItem;
		}
		set
		{
			Set(value);
		}
	}

	public virtual object data
	{
		get
		{
			int num = items.IndexOf(mSelectedItem);
			if (num <= -1 || num >= itemData.Count)
			{
				return null;
			}
			return itemData[num];
		}
	}

	public Action callback
	{
		get
		{
			int num = items.IndexOf(mSelectedItem);
			if (num <= -1 || num >= itemCallbacks.Count)
			{
				return null;
			}
			return itemCallbacks[num];
		}
	}

	public bool isColliderEnabled
	{
		get
		{
			Collider component = GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = GetComponent<Collider2D>();
			if (component2 != null)
			{
				return component2.enabled;
			}
			return false;
		}
		set
		{
			Collider component = GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = value;
				return;
			}
			Collider2D component2 = GetComponent<Collider2D>();
			if (component2 != null)
			{
				component2.enabled = value;
			}
		}
	}

	protected bool isValid => ambigiousFont != null;

	protected int activeFontSize
	{
		get
		{
			INGUIFont iNGUIFont = font;
			if (trueTypeFont != null || iNGUIFont == null)
			{
				return fontSize;
			}
			return iNGUIFont?.defaultSize ?? fontSize;
		}
	}

	protected float activeFontScale
	{
		get
		{
			INGUIFont iNGUIFont = font;
			if (trueTypeFont != null || iNGUIFont == null)
			{
				return 1f;
			}
			if (iNGUIFont == null)
			{
				return 1f;
			}
			return (float)fontSize / (float)iNGUIFont.defaultSize;
		}
	}

	protected float fitScale
	{
		get
		{
			if (separatePanel)
			{
				float num = (float)items.Count * ((float)fontSize + padding.y) + padding.y;
				float y = NGUITools.screenSize.y;
				if (num > y)
				{
					return y / num;
				}
			}
			else if (mPanel != null && mPanel.anchorCamera != null && mPanel.anchorCamera.orthographic)
			{
				float num2 = (float)items.Count * ((float)fontSize + padding.y) + padding.y;
				float height = mPanel.height;
				if (num2 > height)
				{
					return height / num2;
				}
			}
			return 1f;
		}
	}

	public void Set(string value, bool notify = true)
	{
		if (!(mSelectedItem != value))
		{
			return;
		}
		mSelectedItem = value;
		if (mSelectedItem != null)
		{
			if (notify && mSelectedItem != null)
			{
				TriggerCallbacks();
			}
			if (!keepValue)
			{
				mSelectedItem = null;
			}
		}
	}

	public virtual void Clear()
	{
		items.Clear();
		itemData.Clear();
		itemCallbacks.Clear();
	}

	public virtual void AddItem(string text)
	{
		items.Add(text);
		itemData.Add(text);
		itemCallbacks.Add(null);
	}

	public virtual void AddItem(string text, Action del)
	{
		items.Add(text);
		itemCallbacks.Add(del);
	}

	public virtual void AddItem(string text, object data, Action del = null)
	{
		items.Add(text);
		itemData.Add(data);
		itemCallbacks.Add(del);
	}

	public virtual void RemoveItem(string text)
	{
		int num = items.IndexOf(text);
		if (num != -1)
		{
			items.RemoveAt(num);
			itemData.RemoveAt(num);
			if (num < itemCallbacks.Count)
			{
				itemCallbacks.RemoveAt(num);
			}
		}
	}

	public virtual void RemoveItemByData(object data)
	{
		int num = itemData.IndexOf(data);
		if (num != -1)
		{
			items.RemoveAt(num);
			itemData.RemoveAt(num);
			if (num < itemCallbacks.Count)
			{
				itemCallbacks.RemoveAt(num);
			}
		}
	}

	protected void TriggerCallbacks()
	{
		if (!mExecuting)
		{
			mExecuting = true;
			UIPopupList uIPopupList = current;
			current = this;
			if (mLegacyEvent != null)
			{
				mLegacyEvent(mSelectedItem);
			}
			if (EventDelegate.IsValid(onChange))
			{
				EventDelegate.Execute(onChange);
			}
			else if (eventReceiver != null && !string.IsNullOrEmpty(functionName))
			{
				eventReceiver.SendMessage(functionName, mSelectedItem, SendMessageOptions.DontRequireReceiver);
			}
			callback?.Invoke();
			current = uIPopupList;
			mExecuting = false;
		}
	}

	protected virtual void OnEnable()
	{
		if (EventDelegate.IsValid(onChange))
		{
			eventReceiver = null;
			functionName = null;
		}
		INGUIFont iNGUIFont = font;
		if (textScale != 0f)
		{
			fontSize = ((iNGUIFont != null) ? Mathf.RoundToInt((float)iNGUIFont.defaultSize * textScale) : 16);
			textScale = 0f;
		}
		if (trueTypeFont == null && iNGUIFont != null && iNGUIFont.isDynamic && iNGUIFont.replacement == null)
		{
			trueTypeFont = iNGUIFont.dynamicFont;
			bitmapFont = null;
		}
	}

	public virtual void Start()
	{
		if (!mStarted)
		{
			mStarted = true;
			if (keepValue)
			{
				string text = mSelectedItem;
				mSelectedItem = null;
				value = text;
			}
			else
			{
				mSelectedItem = null;
			}
			if (textLabel != null)
			{
				EventDelegate.Add(onChange, textLabel.SetCurrentSelection);
				textLabel = null;
			}
		}
	}

	protected virtual void OnLocalize()
	{
		if (isLocalized)
		{
			TriggerCallbacks();
		}
	}

	protected virtual void Highlight(UILabel lbl, bool instant)
	{
		if (!(mHighlight != null))
		{
			return;
		}
		mHighlightedLabel = lbl;
		Vector3 highlightPosition = GetHighlightPosition();
		if (!instant && isAnimated)
		{
			TweenPosition.Begin(mHighlight.gameObject, 0.1f, highlightPosition).method = UITweener.Method.EaseOut;
			if (!mTweening)
			{
				mTweening = true;
				StartCoroutine("UpdateTweenPosition");
			}
		}
		else
		{
			mHighlight.cachedTransform.localPosition = highlightPosition;
		}
	}

	protected virtual Vector3 GetHighlightPosition()
	{
		if (mHighlightedLabel == null || mHighlight == null)
		{
			return Vector3.zero;
		}
		Vector4 border = mHighlight.border;
		float num = 1f;
		if (atlas is INGUIAtlas iNGUIAtlas)
		{
			num = iNGUIAtlas.pixelSize;
		}
		float num2 = border.x * num;
		float y = border.w * num;
		return mHighlightedLabel.cachedTransform.localPosition + new Vector3(0f - num2, y, 1f);
	}

	protected virtual IEnumerator UpdateTweenPosition()
	{
		if (mHighlight != null && mHighlightedLabel != null)
		{
			TweenPosition tp = mHighlight.GetComponent<TweenPosition>();
			while (tp != null && tp.enabled)
			{
				tp.to = GetHighlightPosition();
				yield return null;
			}
		}
		mTweening = false;
	}

	protected virtual void OnItemHover(GameObject go, bool isOver)
	{
		if (isOver)
		{
			UILabel component = go.GetComponent<UILabel>();
			Highlight(component, instant: false);
		}
	}

	protected virtual void OnItemPress(GameObject go, bool isPressed)
	{
		if (isPressed && selection == Selection.OnPress)
		{
			OnItemClick(go);
		}
	}

	protected virtual void OnItemClick(GameObject go)
	{
		Select(go.GetComponent<UILabel>(), instant: true);
		UIEventListener component = go.GetComponent<UIEventListener>();
		value = component.parameter as string;
		UIPlaySound[] components = GetComponents<UIPlaySound>();
		int i = 0;
		for (int num = components.Length; i < num; i++)
		{
			UIPlaySound uIPlaySound = components[i];
			if (uIPlaySound.trigger == UIPlaySound.Trigger.OnClick)
			{
				NGUITools.PlaySound(uIPlaySound.audioClip, uIPlaySound.volume, 1f);
			}
		}
		CloseSelf();
	}

	private void Select(UILabel lbl, bool instant)
	{
		Highlight(lbl, instant);
	}

	protected virtual void OnNavigate(KeyCode key)
	{
		if (!base.enabled || !(current == this))
		{
			return;
		}
		int num = mLabelList.IndexOf(mHighlightedLabel);
		if (num == -1)
		{
			num = 0;
		}
		switch (key)
		{
		case KeyCode.UpArrow:
			if (num > 0)
			{
				Select(mLabelList[--num], instant: false);
			}
			break;
		case KeyCode.DownArrow:
			if (num + 1 < mLabelList.Count)
			{
				Select(mLabelList[++num], instant: false);
			}
			break;
		}
	}

	protected virtual void OnKey(KeyCode key)
	{
		if (base.enabled && current == this && (key == UICamera.current.cancelKey0 || key == UICamera.current.cancelKey1))
		{
			OnSelect(isSelected: false);
		}
	}

	protected virtual void OnDisable()
	{
		CloseSelf();
	}

	protected virtual void OnSelect(bool isSelected)
	{
		if (!isSelected)
		{
			GameObject selectedObject = UICamera.selectedObject;
			if (selectedObject == null || (!(selectedObject == mChild) && (!(mChild != null) || !(selectedObject != null) || !NGUITools.IsChild(mChild.transform, selectedObject.transform))))
			{
				CloseSelf();
			}
		}
	}

	public static void Close()
	{
		if (current != null)
		{
			current.CloseSelf();
			current = null;
		}
	}

	public virtual void CloseSelf()
	{
		if (!(mChild != null) || !(current == this))
		{
			return;
		}
		StopCoroutine("CloseIfUnselected");
		mSelection = null;
		mLabelList.Clear();
		if (isAnimated)
		{
			UIWidget[] componentsInChildren = mChild.GetComponentsInChildren<UIWidget>();
			int i = 0;
			for (int num = componentsInChildren.Length; i < num; i++)
			{
				UIWidget obj = componentsInChildren[i];
				Color color = obj.color;
				color.a = 0f;
				TweenColor.Begin(obj.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
			}
			Collider[] componentsInChildren2 = mChild.GetComponentsInChildren<Collider>();
			int j = 0;
			for (int num2 = componentsInChildren2.Length; j < num2; j++)
			{
				componentsInChildren2[j].enabled = false;
			}
			UnityEngine.Object.Destroy(mChild, 0.15f);
			mFadeOutComplete = Time.unscaledTime + Mathf.Max(0.1f, 0.15f);
		}
		else
		{
			UnityEngine.Object.Destroy(mChild);
			mFadeOutComplete = Time.unscaledTime + 0.1f;
		}
		mBackground = null;
		mHighlight = null;
		mChild = null;
		current = null;
	}

	protected virtual void AnimateColor(UIWidget widget)
	{
		Color color = widget.color;
		widget.color = new Color(color.r, color.g, color.b, 0f);
		TweenColor.Begin(widget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
	}

	protected virtual void AnimatePosition(UIWidget widget, bool placeAbove, float bottom)
	{
		Vector3 localPosition = widget.cachedTransform.localPosition;
		Vector3 localPosition2 = (placeAbove ? new Vector3(localPosition.x, bottom, localPosition.z) : new Vector3(localPosition.x, 0f, localPosition.z));
		widget.cachedTransform.localPosition = localPosition2;
		TweenPosition.Begin(widget.gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
	}

	protected virtual void AnimateScale(UIWidget widget, bool placeAbove, float bottom)
	{
		GameObject go = widget.gameObject;
		Transform cachedTransform = widget.cachedTransform;
		float num = fitScale;
		float num2 = (float)activeFontSize * activeFontScale + mBgBorder * 2f;
		cachedTransform.localScale = new Vector3(num, num * num2 / (float)widget.height, num);
		TweenScale.Begin(go, 0.15f, Vector3.one).method = UITweener.Method.EaseOut;
		if (placeAbove)
		{
			Vector3 localPosition = cachedTransform.localPosition;
			cachedTransform.localPosition = new Vector3(localPosition.x, localPosition.y - num * (float)widget.height + num * num2, localPosition.z);
			TweenPosition.Begin(go, 0.15f, localPosition).method = UITweener.Method.EaseOut;
		}
	}

	protected void Animate(UIWidget widget, bool placeAbove, float bottom)
	{
		AnimateColor(widget);
		AnimatePosition(widget, placeAbove, bottom);
	}

	protected virtual void OnClick()
	{
		if (mOpenFrame == Time.frameCount)
		{
			return;
		}
		if (mChild == null)
		{
			if (openOn != OpenOn.DoubleClick && openOn != OpenOn.Manual && (openOn != OpenOn.RightClick || UICamera.currentTouchID == -2))
			{
				Show();
			}
		}
		else if (mHighlightedLabel != null)
		{
			OnItemPress(mHighlightedLabel.gameObject, isPressed: true);
		}
	}

	protected virtual void OnDoubleClick()
	{
		if (openOn == OpenOn.DoubleClick)
		{
			Show();
		}
	}

	private IEnumerator CloseIfUnselected()
	{
		GameObject selectedObject;
		do
		{
			yield return null;
			selectedObject = UICamera.selectedObject;
		}
		while (!(selectedObject != mSelection) || (!(selectedObject == null) && (selectedObject == mChild || NGUITools.IsChild(mChild.transform, selectedObject.transform))));
		CloseSelf();
	}

	public virtual void Show()
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && mChild == null && isValid && items.Count > 0)
		{
			mLabelList.Clear();
			StopCoroutine("CloseIfUnselected");
			UICamera.selectedObject = UICamera.hoveredObject ?? base.gameObject;
			mSelection = UICamera.selectedObject;
			source = mSelection;
			if (source == null)
			{
				Debug.LogError("Popup list needs a source object...");
				return;
			}
			mOpenFrame = Time.frameCount;
			if (mPanel == null)
			{
				mPanel = UIPanel.Find(base.transform);
				if (mPanel == null)
				{
					return;
				}
			}
			mChild = new GameObject("Drop-down List");
			mChild.layer = base.gameObject.layer;
			if (separatePanel)
			{
				if (GetComponent<Collider>() != null)
				{
					mChild.AddComponent<Rigidbody>().isKinematic = true;
				}
				else if (GetComponent<Collider2D>() != null)
				{
					mChild.AddComponent<Rigidbody2D>().isKinematic = true;
				}
				UIPanel uIPanel = mChild.AddComponent<UIPanel>();
				uIPanel.depth = 1000000;
				uIPanel.sortingOrder = mPanel.sortingOrder;
			}
			current = this;
			Transform cachedTransform = mPanel.cachedTransform;
			Transform transform = mChild.transform;
			transform.parent = cachedTransform;
			Transform parent = cachedTransform;
			if (separatePanel)
			{
				UIRoot uIRoot = mPanel.GetComponentInParent<UIRoot>();
				if (uIRoot == null && UIRoot.list.Count != 0)
				{
					uIRoot = UIRoot.list[0];
				}
				if (uIRoot != null)
				{
					parent = uIRoot.transform;
				}
			}
			Vector3 vector;
			Vector3 vector2;
			if (openOn == OpenOn.Manual && mSelection != base.gameObject)
			{
				startingPosition = UICamera.lastEventPosition;
				vector = cachedTransform.InverseTransformPoint(mPanel.anchorCamera.ScreenToWorldPoint(startingPosition));
				vector2 = vector;
				transform.localPosition = vector;
				startingPosition = transform.position;
			}
			else
			{
				Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(cachedTransform, base.transform, considerInactive: false, considerChildren: false);
				vector = bounds.min;
				vector2 = bounds.max;
				transform.localPosition = vector;
				startingPosition = transform.position;
			}
			StartCoroutine("CloseIfUnselected");
			float num = fitScale;
			transform.localRotation = Quaternion.identity;
			transform.localScale = new Vector3(num, num, num);
			int num2 = ((!separatePanel) ? NGUITools.CalculateNextDepth(mPanel.gameObject) : 0);
			if (background2DSprite != null)
			{
				UI2DSprite uI2DSprite = mChild.AddWidget<UI2DSprite>(num2);
				uI2DSprite.sprite2D = background2DSprite;
				mBackground = uI2DSprite;
			}
			else
			{
				if (!(atlas != null))
				{
					return;
				}
				mBackground = mChild.AddSprite(atlas as INGUIAtlas, backgroundSprite, num2);
			}
			bool flag = position == Position.Above;
			if (position == Position.Auto)
			{
				UICamera uICamera = UICamera.FindCameraForLayer(mSelection.layer);
				if (uICamera != null)
				{
					flag = uICamera.cachedCamera.WorldToViewportPoint(startingPosition).y < 0.5f;
				}
			}
			mBackground.pivot = UIWidget.Pivot.TopLeft;
			mBackground.color = backgroundColor;
			Vector4 border = mBackground.border;
			mBgBorder = border.y;
			mBackground.cachedTransform.localPosition = new Vector3(0f, flag ? (border.y * 2f - (float)overlap) : ((float)overlap), 0f);
			if (highlight2DSprite != null)
			{
				UI2DSprite uI2DSprite2 = mChild.AddWidget<UI2DSprite>(++num2);
				uI2DSprite2.sprite2D = highlight2DSprite;
				mHighlight = uI2DSprite2;
			}
			else
			{
				if (!(atlas != null))
				{
					return;
				}
				mHighlight = mChild.AddSprite(atlas as INGUIAtlas, highlightSprite, ++num2);
			}
			float num3 = 0f;
			float num4 = 0f;
			if (mHighlight.hasBorder)
			{
				num3 = mHighlight.border.w;
				num4 = mHighlight.border.x;
			}
			mHighlight.pivot = UIWidget.Pivot.TopLeft;
			mHighlight.color = highlightColor;
			float num5 = (float)activeFontSize * activeFontScale;
			float num6 = num5 + padding.y;
			float a = 0f;
			float num7 = (flag ? (border.y - padding.y - (float)overlap) : (0f - padding.y - border.y + (float)overlap));
			float num8 = border.y * 2f + padding.y;
			List<UILabel> list = new List<UILabel>();
			if (!items.Contains(mSelectedItem))
			{
				mSelectedItem = null;
			}
			int i = 0;
			for (int count = items.Count; i < count; i++)
			{
				string text = items[i];
				UILabel uILabel = mChild.AddWidget<UILabel>(mBackground.depth + 2);
				uILabel.name = i.ToString();
				uILabel.pivot = UIWidget.Pivot.TopLeft;
				uILabel.bitmapFont = bitmapFont as INGUIFont;
				uILabel.trueTypeFont = trueTypeFont;
				uILabel.fontSize = fontSize;
				uILabel.fontStyle = fontStyle;
				uILabel.text = (isLocalized ? Localization.Get(text) : text);
				uILabel.modifier = textModifier;
				uILabel.color = textColor;
				uILabel.cachedTransform.localPosition = new Vector3(border.x + padding.x - uILabel.pivotOffset.x, num7, -1f);
				uILabel.overflowMethod = UILabel.Overflow.ResizeFreely;
				uILabel.alignment = alignment;
				uILabel.symbolStyle = NGUIText.SymbolStyle.Colored;
				list.Add(uILabel);
				num8 += num6;
				num7 -= num6;
				a = Mathf.Max(a, uILabel.printedSize.x);
				UIEventListener uIEventListener = UIEventListener.Get(uILabel.gameObject);
				uIEventListener.onHover = OnItemHover;
				uIEventListener.onPress = OnItemPress;
				uIEventListener.onClick = OnItemClick;
				uIEventListener.parameter = text;
				if (mSelectedItem == text || (i == 0 && string.IsNullOrEmpty(mSelectedItem)))
				{
					Highlight(uILabel, instant: true);
				}
				mLabelList.Add(uILabel);
			}
			a = Mathf.Max(a, vector2.x - vector.x - (border.x + padding.x) * 2f);
			float num9 = a;
			Vector3 vector3 = new Vector3(num9 * 0.5f, (0f - num5) * 0.5f, 0f);
			Vector3 vector4 = new Vector3(num9, num5 + padding.y, 1f);
			int j = 0;
			for (int count2 = list.Count; j < count2; j++)
			{
				UILabel uILabel2 = list[j];
				NGUITools.AddWidgetCollider(uILabel2.gameObject);
				uILabel2.autoResizeBoxCollider = false;
				BoxCollider component = uILabel2.GetComponent<BoxCollider>();
				if (component != null)
				{
					vector3.z = component.center.z;
					component.center = vector3;
					component.size = vector4;
				}
				else
				{
					BoxCollider2D component2 = uILabel2.GetComponent<BoxCollider2D>();
					component2.offset = vector3;
					component2.size = vector4;
				}
			}
			int width = Mathf.RoundToInt(a);
			a += (border.x + padding.x) * 2f;
			num7 -= border.y;
			mBackground.width = Mathf.RoundToInt(a);
			mBackground.height = Mathf.RoundToInt(num8);
			int k = 0;
			for (int count3 = list.Count; k < count3; k++)
			{
				UILabel uILabel3 = list[k];
				uILabel3.overflowMethod = UILabel.Overflow.ShrinkContent;
				uILabel3.width = width;
			}
			float num10 = 2f;
			if (atlas is INGUIAtlas iNGUIAtlas)
			{
				num10 *= iNGUIAtlas.pixelSize;
			}
			float f = a - (border.x + padding.x) * 2f + num4 * num10;
			float f2 = num5 + num3 * num10;
			mHighlight.width = Mathf.RoundToInt(f);
			mHighlight.height = Mathf.RoundToInt(f2);
			if (isAnimated)
			{
				AnimateColor(mBackground);
				if (Time.timeScale == 0f || Time.timeScale >= 0.1f)
				{
					float bottom = num7 + num5;
					Animate(mHighlight, flag, bottom);
					int l = 0;
					for (int count4 = list.Count; l < count4; l++)
					{
						Animate(list[l], flag, bottom);
					}
					AnimateScale(mBackground, flag, bottom);
				}
			}
			if (flag)
			{
				float num11 = border.y * num;
				vector.y = vector2.y - border.y * num;
				vector2.y = vector.y + ((float)mBackground.height - border.y * 2f) * num;
				vector2.x = vector.x + (float)mBackground.width * num;
				transform.localPosition = new Vector3(vector.x, vector2.y - num11, vector.z);
			}
			else
			{
				vector2.y = vector.y + border.y * num;
				vector.y = vector2.y - (float)mBackground.height * num;
				vector2.x = vector.x + (float)mBackground.width * num;
			}
			UIPanel uIPanel2 = mPanel;
			while (true)
			{
				UIRect parent2 = uIPanel2.parent;
				if (parent2 == null)
				{
					break;
				}
				UIPanel componentInParent = parent2.GetComponentInParent<UIPanel>();
				if (componentInParent == null)
				{
					break;
				}
				uIPanel2 = componentInParent;
			}
			if (cachedTransform != null)
			{
				vector = cachedTransform.TransformPoint(vector);
				vector2 = cachedTransform.TransformPoint(vector2);
				vector = uIPanel2.cachedTransform.InverseTransformPoint(vector);
				vector2 = uIPanel2.cachedTransform.InverseTransformPoint(vector2);
				float pixelSizeAdjustment = UIRoot.GetPixelSizeAdjustment(base.gameObject);
				vector /= pixelSizeAdjustment;
				vector2 /= pixelSizeAdjustment;
			}
			Vector3 vector5 = uIPanel2.CalculateConstrainOffset(vector, vector2);
			Vector3 localPosition = transform.localPosition + vector5;
			localPosition.x = Mathf.Round(localPosition.x);
			localPosition.y = Mathf.Round(localPosition.y);
			transform.localPosition = localPosition;
			transform.parent = parent;
		}
		else
		{
			OnSelect(isSelected: false);
		}
	}
}
