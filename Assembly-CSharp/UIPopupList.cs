using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200005E RID: 94
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Popup List")]
public class UIPopupList : UIWidgetContainer
{
	// Token: 0x1700001E RID: 30
	// (get) Token: 0x0600022F RID: 559 RVA: 0x000197CA File Offset: 0x000179CA
	// (set) Token: 0x06000230 RID: 560 RVA: 0x00019805 File Offset: 0x00017A05
	public INGUIFont font
	{
		get
		{
			if (!(this.bitmapFont != null))
			{
				return null;
			}
			if (this.bitmapFont is GameObject)
			{
				return (this.bitmapFont as GameObject).GetComponent<UIFont>();
			}
			return this.bitmapFont as INGUIFont;
		}
		set
		{
			this.bitmapFont = (value as UnityEngine.Object);
			this.trueTypeFont = null;
		}
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000231 RID: 561 RVA: 0x0001981C File Offset: 0x00017A1C
	// (set) Token: 0x06000232 RID: 562 RVA: 0x00019874 File Offset: 0x00017A74
	public UnityEngine.Object ambigiousFont
	{
		get
		{
			if (this.trueTypeFont != null)
			{
				return this.trueTypeFont;
			}
			if (!(this.bitmapFont != null))
			{
				return null;
			}
			if (this.bitmapFont is GameObject)
			{
				return (this.bitmapFont as GameObject).GetComponent<UIFont>();
			}
			return this.bitmapFont;
		}
		set
		{
			if (value is Font)
			{
				this.trueTypeFont = (value as Font);
				this.bitmapFont = null;
				return;
			}
			if (value is INGUIFont)
			{
				this.bitmapFont = value;
				this.trueTypeFont = null;
				return;
			}
			if (value is GameObject)
			{
				this.bitmapFont = (value as GameObject).GetComponent<UIFont>();
				this.trueTypeFont = null;
			}
		}
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000233 RID: 563 RVA: 0x000198D4 File Offset: 0x00017AD4
	// (set) Token: 0x06000234 RID: 564 RVA: 0x000198DC File Offset: 0x00017ADC
	[Obsolete("Use EventDelegate.Add(popup.onChange, YourCallback) instead, and UIPopupList.current.value to determine the state")]
	public UIPopupList.LegacyEvent onSelectionChange
	{
		get
		{
			return this.mLegacyEvent;
		}
		set
		{
			this.mLegacyEvent = value;
		}
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000235 RID: 565 RVA: 0x000198E5 File Offset: 0x00017AE5
	public static bool isOpen
	{
		get
		{
			return UIPopupList.current != null && (UIPopupList.mChild != null || UIPopupList.mFadeOutComplete > Time.unscaledTime);
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000236 RID: 566 RVA: 0x00019911 File Offset: 0x00017B11
	// (set) Token: 0x06000237 RID: 567 RVA: 0x00019919 File Offset: 0x00017B19
	public virtual string value
	{
		get
		{
			return this.mSelectedItem;
		}
		set
		{
			this.Set(value, true);
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000238 RID: 568 RVA: 0x00019924 File Offset: 0x00017B24
	public virtual object data
	{
		get
		{
			int num = this.items.IndexOf(this.mSelectedItem);
			if (num <= -1 || num >= this.itemData.Count)
			{
				return null;
			}
			return this.itemData[num];
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x06000239 RID: 569 RVA: 0x00019964 File Offset: 0x00017B64
	public Action callback
	{
		get
		{
			int num = this.items.IndexOf(this.mSelectedItem);
			if (num <= -1 || num >= this.itemCallbacks.Count)
			{
				return null;
			}
			return this.itemCallbacks[num];
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x0600023A RID: 570 RVA: 0x000199A4 File Offset: 0x00017BA4
	// (set) Token: 0x0600023B RID: 571 RVA: 0x000199E0 File Offset: 0x00017BE0
	public bool isColliderEnabled
	{
		get
		{
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				return component.enabled;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			return component2 != null && component2.enabled;
		}
		set
		{
			Collider component = base.GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = value;
				return;
			}
			Collider2D component2 = base.GetComponent<Collider2D>();
			if (component2 != null)
			{
				component2.enabled = value;
				return;
			}
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x0600023C RID: 572 RVA: 0x00019A1D File Offset: 0x00017C1D
	protected bool isValid
	{
		get
		{
			return this.ambigiousFont != null;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x0600023D RID: 573 RVA: 0x00019A2C File Offset: 0x00017C2C
	protected int activeFontSize
	{
		get
		{
			INGUIFont font = this.font;
			if (this.trueTypeFont != null || font == null)
			{
				return this.fontSize;
			}
			if (font == null)
			{
				return this.fontSize;
			}
			return font.defaultSize;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x0600023E RID: 574 RVA: 0x00019A68 File Offset: 0x00017C68
	protected float activeFontScale
	{
		get
		{
			INGUIFont font = this.font;
			if (this.trueTypeFont != null || font == null)
			{
				return 1f;
			}
			if (font == null)
			{
				return 1f;
			}
			return (float)this.fontSize / (float)font.defaultSize;
		}
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600023F RID: 575 RVA: 0x00019AAC File Offset: 0x00017CAC
	protected float fitScale
	{
		get
		{
			if (this.separatePanel)
			{
				float num = (float)this.items.Count * ((float)this.fontSize + this.padding.y) + this.padding.y;
				float y = NGUITools.screenSize.y;
				if (num > y)
				{
					return y / num;
				}
			}
			else if (this.mPanel != null && this.mPanel.anchorCamera != null && this.mPanel.anchorCamera.orthographic)
			{
				float num2 = (float)this.items.Count * ((float)this.fontSize + this.padding.y) + this.padding.y;
				float height = this.mPanel.height;
				if (num2 > height)
				{
					return height / num2;
				}
			}
			return 1f;
		}
	}

	// Token: 0x06000240 RID: 576 RVA: 0x00019B7A File Offset: 0x00017D7A
	public void Set(string value, bool notify = true)
	{
		if (this.mSelectedItem != value)
		{
			this.mSelectedItem = value;
			if (this.mSelectedItem == null)
			{
				return;
			}
			if (notify && this.mSelectedItem != null)
			{
				this.TriggerCallbacks();
			}
			if (!this.keepValue)
			{
				this.mSelectedItem = null;
			}
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x00019BBA File Offset: 0x00017DBA
	public virtual void Clear()
	{
		this.items.Clear();
		this.itemData.Clear();
		this.itemCallbacks.Clear();
	}

	// Token: 0x06000242 RID: 578 RVA: 0x00019BDD File Offset: 0x00017DDD
	public virtual void AddItem(string text)
	{
		this.items.Add(text);
		this.itemData.Add(text);
		this.itemCallbacks.Add(null);
	}

	// Token: 0x06000243 RID: 579 RVA: 0x00019C03 File Offset: 0x00017E03
	public virtual void AddItem(string text, Action del)
	{
		this.items.Add(text);
		this.itemCallbacks.Add(del);
	}

	// Token: 0x06000244 RID: 580 RVA: 0x00019C1D File Offset: 0x00017E1D
	public virtual void AddItem(string text, object data, Action del = null)
	{
		this.items.Add(text);
		this.itemData.Add(data);
		this.itemCallbacks.Add(del);
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00019C44 File Offset: 0x00017E44
	public virtual void RemoveItem(string text)
	{
		int num = this.items.IndexOf(text);
		if (num != -1)
		{
			this.items.RemoveAt(num);
			this.itemData.RemoveAt(num);
			if (num < this.itemCallbacks.Count)
			{
				this.itemCallbacks.RemoveAt(num);
			}
		}
	}

	// Token: 0x06000246 RID: 582 RVA: 0x00019C94 File Offset: 0x00017E94
	public virtual void RemoveItemByData(object data)
	{
		int num = this.itemData.IndexOf(data);
		if (num != -1)
		{
			this.items.RemoveAt(num);
			this.itemData.RemoveAt(num);
			if (num < this.itemCallbacks.Count)
			{
				this.itemCallbacks.RemoveAt(num);
			}
		}
	}

	// Token: 0x06000247 RID: 583 RVA: 0x00019CE4 File Offset: 0x00017EE4
	protected void TriggerCallbacks()
	{
		if (!this.mExecuting)
		{
			this.mExecuting = true;
			UIPopupList uipopupList = UIPopupList.current;
			UIPopupList.current = this;
			if (this.mLegacyEvent != null)
			{
				this.mLegacyEvent(this.mSelectedItem);
			}
			if (EventDelegate.IsValid(this.onChange))
			{
				EventDelegate.Execute(this.onChange);
			}
			else if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName))
			{
				this.eventReceiver.SendMessage(this.functionName, this.mSelectedItem, SendMessageOptions.DontRequireReceiver);
			}
			Action callback = this.callback;
			if (callback != null)
			{
				callback();
			}
			UIPopupList.current = uipopupList;
			this.mExecuting = false;
		}
	}

	// Token: 0x06000248 RID: 584 RVA: 0x00019D90 File Offset: 0x00017F90
	protected virtual void OnEnable()
	{
		if (EventDelegate.IsValid(this.onChange))
		{
			this.eventReceiver = null;
			this.functionName = null;
		}
		INGUIFont font = this.font;
		if (this.textScale != 0f)
		{
			this.fontSize = ((font != null) ? Mathf.RoundToInt((float)font.defaultSize * this.textScale) : 16);
			this.textScale = 0f;
		}
		if (this.trueTypeFont == null && font != null && font.isDynamic && font.replacement == null)
		{
			this.trueTypeFont = font.dynamicFont;
			this.bitmapFont = null;
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x00019E2C File Offset: 0x0001802C
	public virtual void Start()
	{
		if (this.mStarted)
		{
			return;
		}
		this.mStarted = true;
		if (this.keepValue)
		{
			string value = this.mSelectedItem;
			this.mSelectedItem = null;
			this.value = value;
		}
		else
		{
			this.mSelectedItem = null;
		}
		if (this.textLabel != null)
		{
			EventDelegate.Add(this.onChange, new EventDelegate.Callback(this.textLabel.SetCurrentSelection));
			this.textLabel = null;
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00019EA1 File Offset: 0x000180A1
	protected virtual void OnLocalize()
	{
		if (this.isLocalized)
		{
			this.TriggerCallbacks();
		}
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00019EB4 File Offset: 0x000180B4
	protected virtual void Highlight(UILabel lbl, bool instant)
	{
		if (this.mHighlight != null)
		{
			this.mHighlightedLabel = lbl;
			Vector3 highlightPosition = this.GetHighlightPosition();
			if (!instant && this.isAnimated)
			{
				TweenPosition.Begin(this.mHighlight.gameObject, 0.1f, highlightPosition).method = UITweener.Method.EaseOut;
				if (!this.mTweening)
				{
					this.mTweening = true;
					base.StartCoroutine("UpdateTweenPosition");
					return;
				}
			}
			else
			{
				this.mHighlight.cachedTransform.localPosition = highlightPosition;
			}
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00019F34 File Offset: 0x00018134
	protected virtual Vector3 GetHighlightPosition()
	{
		if (this.mHighlightedLabel == null || this.mHighlight == null)
		{
			return Vector3.zero;
		}
		Vector4 border = this.mHighlight.border;
		float num = 1f;
		INGUIAtlas inguiatlas = this.atlas as INGUIAtlas;
		if (inguiatlas != null)
		{
			num = inguiatlas.pixelSize;
		}
		float num2 = border.x * num;
		float y = border.w * num;
		return this.mHighlightedLabel.cachedTransform.localPosition + new Vector3(-num2, y, 1f);
	}

	// Token: 0x0600024D RID: 589 RVA: 0x00019FBD File Offset: 0x000181BD
	protected virtual IEnumerator UpdateTweenPosition()
	{
		if (this.mHighlight != null && this.mHighlightedLabel != null)
		{
			TweenPosition tp = this.mHighlight.GetComponent<TweenPosition>();
			while (tp != null && tp.enabled)
			{
				tp.to = this.GetHighlightPosition();
				yield return null;
			}
			tp = null;
		}
		this.mTweening = false;
		yield break;
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00019FCC File Offset: 0x000181CC
	protected virtual void OnItemHover(GameObject go, bool isOver)
	{
		if (isOver)
		{
			UILabel component = go.GetComponent<UILabel>();
			this.Highlight(component, false);
		}
	}

	// Token: 0x0600024F RID: 591 RVA: 0x00019FEB File Offset: 0x000181EB
	protected virtual void OnItemPress(GameObject go, bool isPressed)
	{
		if (isPressed && this.selection == UIPopupList.Selection.OnPress)
		{
			this.OnItemClick(go);
		}
	}

	// Token: 0x06000250 RID: 592 RVA: 0x0001A000 File Offset: 0x00018200
	protected virtual void OnItemClick(GameObject go)
	{
		this.Select(go.GetComponent<UILabel>(), true);
		UIEventListener component = go.GetComponent<UIEventListener>();
		this.value = (component.parameter as string);
		UIPlaySound[] components = base.GetComponents<UIPlaySound>();
		int i = 0;
		int num = components.Length;
		while (i < num)
		{
			UIPlaySound uiplaySound = components[i];
			if (uiplaySound.trigger == UIPlaySound.Trigger.OnClick)
			{
				NGUITools.PlaySound(uiplaySound.audioClip, uiplaySound.volume, 1f);
			}
			i++;
		}
		this.CloseSelf();
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0001A076 File Offset: 0x00018276
	private void Select(UILabel lbl, bool instant)
	{
		this.Highlight(lbl, instant);
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0001A080 File Offset: 0x00018280
	protected virtual void OnNavigate(KeyCode key)
	{
		if (base.enabled && UIPopupList.current == this)
		{
			int num = this.mLabelList.IndexOf(this.mHighlightedLabel);
			if (num == -1)
			{
				num = 0;
			}
			if (key == KeyCode.UpArrow)
			{
				if (num > 0)
				{
					this.Select(this.mLabelList[num - 1], false);
					return;
				}
			}
			else if (key == KeyCode.DownArrow && num + 1 < this.mLabelList.Count)
			{
				this.Select(this.mLabelList[num + 1], false);
			}
		}
	}

	// Token: 0x06000253 RID: 595 RVA: 0x0001A10D File Offset: 0x0001830D
	protected virtual void OnKey(KeyCode key)
	{
		if (base.enabled && UIPopupList.current == this && (key == UICamera.current.cancelKey0 || key == UICamera.current.cancelKey1))
		{
			this.OnSelect(false);
		}
	}

	// Token: 0x06000254 RID: 596 RVA: 0x0001A145 File Offset: 0x00018345
	protected virtual void OnDisable()
	{
		this.CloseSelf();
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0001A150 File Offset: 0x00018350
	protected virtual void OnSelect(bool isSelected)
	{
		if (!isSelected)
		{
			GameObject selectedObject = UICamera.selectedObject;
			if (selectedObject == null || (!(selectedObject == UIPopupList.mChild) && (!(UIPopupList.mChild != null) || !(selectedObject != null) || !NGUITools.IsChild(UIPopupList.mChild.transform, selectedObject.transform))))
			{
				this.CloseSelf();
			}
		}
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0001A1AF File Offset: 0x000183AF
	public static void Close()
	{
		if (UIPopupList.current != null)
		{
			UIPopupList.current.CloseSelf();
			UIPopupList.current = null;
		}
	}

	// Token: 0x06000257 RID: 599 RVA: 0x0001A1D0 File Offset: 0x000183D0
	public virtual void CloseSelf()
	{
		if (UIPopupList.mChild != null && UIPopupList.current == this)
		{
			base.StopCoroutine("CloseIfUnselected");
			this.mSelection = null;
			this.mLabelList.Clear();
			if (this.isAnimated)
			{
				UIWidget[] componentsInChildren = UIPopupList.mChild.GetComponentsInChildren<UIWidget>();
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					UIWidget uiwidget = componentsInChildren[i];
					Color color = uiwidget.color;
					color.a = 0f;
					TweenColor.Begin(uiwidget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
					i++;
				}
				Collider[] componentsInChildren2 = UIPopupList.mChild.GetComponentsInChildren<Collider>();
				int j = 0;
				int num2 = componentsInChildren2.Length;
				while (j < num2)
				{
					componentsInChildren2[j].enabled = false;
					j++;
				}
				UnityEngine.Object.Destroy(UIPopupList.mChild, 0.15f);
				UIPopupList.mFadeOutComplete = Time.unscaledTime + Mathf.Max(0.1f, 0.15f);
			}
			else
			{
				UnityEngine.Object.Destroy(UIPopupList.mChild);
				UIPopupList.mFadeOutComplete = Time.unscaledTime + 0.1f;
			}
			this.mBackground = null;
			this.mHighlight = null;
			UIPopupList.mChild = null;
			UIPopupList.current = null;
		}
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0001A2F8 File Offset: 0x000184F8
	protected virtual void AnimateColor(UIWidget widget)
	{
		Color color = widget.color;
		widget.color = new Color(color.r, color.g, color.b, 0f);
		TweenColor.Begin(widget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0001A348 File Offset: 0x00018548
	protected virtual void AnimatePosition(UIWidget widget, bool placeAbove, float bottom)
	{
		Vector3 localPosition = widget.cachedTransform.localPosition;
		Vector3 localPosition2 = placeAbove ? new Vector3(localPosition.x, bottom, localPosition.z) : new Vector3(localPosition.x, 0f, localPosition.z);
		widget.cachedTransform.localPosition = localPosition2;
		TweenPosition.Begin(widget.gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
	}

	// Token: 0x0600025A RID: 602 RVA: 0x0001A3B4 File Offset: 0x000185B4
	protected virtual void AnimateScale(UIWidget widget, bool placeAbove, float bottom)
	{
		GameObject gameObject = widget.gameObject;
		Transform cachedTransform = widget.cachedTransform;
		float fitScale = this.fitScale;
		float num = (float)this.activeFontSize * this.activeFontScale + this.mBgBorder * 2f;
		cachedTransform.localScale = new Vector3(fitScale, fitScale * num / (float)widget.height, fitScale);
		TweenScale.Begin(gameObject, 0.15f, Vector3.one).method = UITweener.Method.EaseOut;
		if (placeAbove)
		{
			Vector3 localPosition = cachedTransform.localPosition;
			cachedTransform.localPosition = new Vector3(localPosition.x, localPosition.y - fitScale * (float)widget.height + fitScale * num, localPosition.z);
			TweenPosition.Begin(gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
		}
	}

	// Token: 0x0600025B RID: 603 RVA: 0x0001A46C File Offset: 0x0001866C
	protected void Animate(UIWidget widget, bool placeAbove, float bottom)
	{
		this.AnimateColor(widget);
		this.AnimatePosition(widget, placeAbove, bottom);
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0001A480 File Offset: 0x00018680
	protected virtual void OnClick()
	{
		if (this.mOpenFrame == Time.frameCount)
		{
			return;
		}
		if (!(UIPopupList.mChild == null))
		{
			if (this.mHighlightedLabel != null)
			{
				this.OnItemPress(this.mHighlightedLabel.gameObject, true);
			}
			return;
		}
		if (this.openOn == UIPopupList.OpenOn.DoubleClick || this.openOn == UIPopupList.OpenOn.Manual)
		{
			return;
		}
		if (this.openOn == UIPopupList.OpenOn.RightClick && UICamera.currentTouchID != -2)
		{
			return;
		}
		this.Show();
	}

	// Token: 0x0600025D RID: 605 RVA: 0x0001A4F5 File Offset: 0x000186F5
	protected virtual void OnDoubleClick()
	{
		if (this.openOn == UIPopupList.OpenOn.DoubleClick)
		{
			this.Show();
		}
	}

	// Token: 0x0600025E RID: 606 RVA: 0x0001A506 File Offset: 0x00018706
	private IEnumerator CloseIfUnselected()
	{
		GameObject selectedObject;
		do
		{
			yield return null;
			selectedObject = UICamera.selectedObject;
		}
		while (!(selectedObject != this.mSelection) || (!(selectedObject == null) && (selectedObject == UIPopupList.mChild || NGUITools.IsChild(UIPopupList.mChild.transform, selectedObject.transform))));
		this.CloseSelf();
		yield break;
	}

	// Token: 0x0600025F RID: 607 RVA: 0x0001A518 File Offset: 0x00018718
	public virtual void Show()
	{
		if (!base.enabled || !NGUITools.GetActive(base.gameObject) || !(UIPopupList.mChild == null) || !this.isValid || this.items.Count <= 0)
		{
			this.OnSelect(false);
			return;
		}
		this.mLabelList.Clear();
		base.StopCoroutine("CloseIfUnselected");
		UICamera.selectedObject = (UICamera.hoveredObject ?? base.gameObject);
		this.mSelection = UICamera.selectedObject;
		this.source = this.mSelection;
		if (this.source == null)
		{
			Debug.LogError("Popup list needs a source object...");
			return;
		}
		this.mOpenFrame = Time.frameCount;
		if (this.mPanel == null)
		{
			this.mPanel = UIPanel.Find(base.transform);
			if (this.mPanel == null)
			{
				return;
			}
		}
		UIPopupList.mChild = new GameObject("Drop-down List");
		UIPopupList.mChild.layer = base.gameObject.layer;
		if (this.separatePanel)
		{
			if (base.GetComponent<Collider>() != null)
			{
				UIPopupList.mChild.AddComponent<Rigidbody>().isKinematic = true;
			}
			else if (base.GetComponent<Collider2D>() != null)
			{
				UIPopupList.mChild.AddComponent<Rigidbody2D>().isKinematic = true;
			}
			UIPanel uipanel = UIPopupList.mChild.AddComponent<UIPanel>();
			uipanel.depth = 1000000;
			uipanel.sortingOrder = this.mPanel.sortingOrder;
		}
		UIPopupList.current = this;
		Transform cachedTransform = this.mPanel.cachedTransform;
		Transform transform = UIPopupList.mChild.transform;
		transform.parent = cachedTransform;
		Transform parent = cachedTransform;
		if (this.separatePanel)
		{
			UIRoot uiroot = this.mPanel.GetComponentInParent<UIRoot>();
			if (uiroot == null && UIRoot.list.Count != 0)
			{
				uiroot = UIRoot.list[0];
			}
			if (uiroot != null)
			{
				parent = uiroot.transform;
			}
		}
		Vector3 vector;
		Vector3 vector2;
		if (this.openOn == UIPopupList.OpenOn.Manual && this.mSelection != base.gameObject)
		{
			this.startingPosition = UICamera.lastEventPosition;
			vector = cachedTransform.InverseTransformPoint(this.mPanel.anchorCamera.ScreenToWorldPoint(this.startingPosition));
			vector2 = vector;
			transform.localPosition = vector;
			this.startingPosition = transform.position;
		}
		else
		{
			Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(cachedTransform, base.transform, false, false);
			vector = bounds.min;
			vector2 = bounds.max;
			transform.localPosition = vector;
			this.startingPosition = transform.position;
		}
		base.StartCoroutine("CloseIfUnselected");
		float fitScale = this.fitScale;
		transform.localRotation = Quaternion.identity;
		transform.localScale = new Vector3(fitScale, fitScale, fitScale);
		int num = this.separatePanel ? 0 : NGUITools.CalculateNextDepth(this.mPanel.gameObject);
		if (this.background2DSprite != null)
		{
			UI2DSprite ui2DSprite = UIPopupList.mChild.AddWidget(num);
			ui2DSprite.sprite2D = this.background2DSprite;
			this.mBackground = ui2DSprite;
		}
		else
		{
			if (!(this.atlas != null))
			{
				return;
			}
			this.mBackground = UIPopupList.mChild.AddSprite(this.atlas as INGUIAtlas, this.backgroundSprite, num);
		}
		bool flag = this.position == UIPopupList.Position.Above;
		if (this.position == UIPopupList.Position.Auto)
		{
			UICamera uicamera = UICamera.FindCameraForLayer(this.mSelection.layer);
			if (uicamera != null)
			{
				flag = (uicamera.cachedCamera.WorldToViewportPoint(this.startingPosition).y < 0.5f);
			}
		}
		this.mBackground.pivot = UIWidget.Pivot.TopLeft;
		this.mBackground.color = this.backgroundColor;
		Vector4 border = this.mBackground.border;
		this.mBgBorder = border.y;
		this.mBackground.cachedTransform.localPosition = new Vector3(0f, flag ? (border.y * 2f - (float)this.overlap) : ((float)this.overlap), 0f);
		if (this.highlight2DSprite != null)
		{
			UI2DSprite ui2DSprite2 = UIPopupList.mChild.AddWidget(num + 1);
			ui2DSprite2.sprite2D = this.highlight2DSprite;
			this.mHighlight = ui2DSprite2;
		}
		else
		{
			if (!(this.atlas != null))
			{
				return;
			}
			this.mHighlight = UIPopupList.mChild.AddSprite(this.atlas as INGUIAtlas, this.highlightSprite, num + 1);
		}
		float num2 = 0f;
		float num3 = 0f;
		if (this.mHighlight.hasBorder)
		{
			num2 = this.mHighlight.border.w;
			num3 = this.mHighlight.border.x;
		}
		this.mHighlight.pivot = UIWidget.Pivot.TopLeft;
		this.mHighlight.color = this.highlightColor;
		float num4 = (float)this.activeFontSize * this.activeFontScale;
		float num5 = num4 + this.padding.y;
		float num6 = 0f;
		float num7 = flag ? (border.y - this.padding.y - (float)this.overlap) : (-this.padding.y - border.y + (float)this.overlap);
		float num8 = border.y * 2f + this.padding.y;
		List<UILabel> list = new List<UILabel>();
		if (!this.items.Contains(this.mSelectedItem))
		{
			this.mSelectedItem = null;
		}
		int i = 0;
		int count = this.items.Count;
		while (i < count)
		{
			string text = this.items[i];
			UILabel uilabel = UIPopupList.mChild.AddWidget(this.mBackground.depth + 2);
			uilabel.name = i.ToString();
			uilabel.pivot = UIWidget.Pivot.TopLeft;
			uilabel.bitmapFont = (this.bitmapFont as INGUIFont);
			uilabel.trueTypeFont = this.trueTypeFont;
			uilabel.fontSize = this.fontSize;
			uilabel.fontStyle = this.fontStyle;
			uilabel.text = (this.isLocalized ? Localization.Get(text, true) : text);
			uilabel.modifier = this.textModifier;
			uilabel.color = this.textColor;
			uilabel.cachedTransform.localPosition = new Vector3(border.x + this.padding.x - uilabel.pivotOffset.x, num7, -1f);
			uilabel.overflowMethod = UILabel.Overflow.ResizeFreely;
			uilabel.alignment = this.alignment;
			uilabel.symbolStyle = NGUIText.SymbolStyle.Colored;
			list.Add(uilabel);
			num8 += num5;
			num7 -= num5;
			num6 = Mathf.Max(num6, uilabel.printedSize.x);
			UIEventListener uieventListener = UIEventListener.Get(uilabel.gameObject);
			uieventListener.onHover = new UIEventListener.BoolDelegate(this.OnItemHover);
			uieventListener.onPress = new UIEventListener.BoolDelegate(this.OnItemPress);
			uieventListener.onClick = new UIEventListener.VoidDelegate(this.OnItemClick);
			uieventListener.parameter = text;
			if (this.mSelectedItem == text || (i == 0 && string.IsNullOrEmpty(this.mSelectedItem)))
			{
				this.Highlight(uilabel, true);
			}
			this.mLabelList.Add(uilabel);
			i++;
		}
		num6 = Mathf.Max(num6, vector2.x - vector.x - (border.x + this.padding.x) * 2f);
		float num9 = num6;
		Vector3 vector3 = new Vector3(num9 * 0.5f, -num4 * 0.5f, 0f);
		Vector3 vector4 = new Vector3(num9, num4 + this.padding.y, 1f);
		int j = 0;
		int count2 = list.Count;
		while (j < count2)
		{
			UILabel uilabel2 = list[j];
			NGUITools.AddWidgetCollider(uilabel2.gameObject);
			uilabel2.autoResizeBoxCollider = false;
			BoxCollider component = uilabel2.GetComponent<BoxCollider>();
			if (component != null)
			{
				vector3.z = component.center.z;
				component.center = vector3;
				component.size = vector4;
			}
			else
			{
				BoxCollider2D component2 = uilabel2.GetComponent<BoxCollider2D>();
				component2.offset = vector3;
				component2.size = vector4;
			}
			j++;
		}
		int width = Mathf.RoundToInt(num6);
		num6 += (border.x + this.padding.x) * 2f;
		num7 -= border.y;
		this.mBackground.width = Mathf.RoundToInt(num6);
		this.mBackground.height = Mathf.RoundToInt(num8);
		int k = 0;
		int count3 = list.Count;
		while (k < count3)
		{
			UILabel uilabel3 = list[k];
			uilabel3.overflowMethod = UILabel.Overflow.ShrinkContent;
			uilabel3.width = width;
			k++;
		}
		float num10 = 2f;
		INGUIAtlas inguiatlas = this.atlas as INGUIAtlas;
		if (inguiatlas != null)
		{
			num10 *= inguiatlas.pixelSize;
		}
		float f = num6 - (border.x + this.padding.x) * 2f + num3 * num10;
		float f2 = num4 + num2 * num10;
		this.mHighlight.width = Mathf.RoundToInt(f);
		this.mHighlight.height = Mathf.RoundToInt(f2);
		if (this.isAnimated)
		{
			this.AnimateColor(this.mBackground);
			if (Time.timeScale == 0f || Time.timeScale >= 0.1f)
			{
				float bottom = num7 + num4;
				this.Animate(this.mHighlight, flag, bottom);
				int l = 0;
				int count4 = list.Count;
				while (l < count4)
				{
					this.Animate(list[l], flag, bottom);
					l++;
				}
				this.AnimateScale(this.mBackground, flag, bottom);
			}
		}
		if (flag)
		{
			float num11 = border.y * fitScale;
			vector.y = vector2.y - border.y * fitScale;
			vector2.y = vector.y + ((float)this.mBackground.height - border.y * 2f) * fitScale;
			vector2.x = vector.x + (float)this.mBackground.width * fitScale;
			transform.localPosition = new Vector3(vector.x, vector2.y - num11, vector.z);
		}
		else
		{
			vector2.y = vector.y + border.y * fitScale;
			vector.y = vector2.y - (float)this.mBackground.height * fitScale;
			vector2.x = vector.x + (float)this.mBackground.width * fitScale;
		}
		UIPanel uipanel2 = this.mPanel;
		for (;;)
		{
			UIRect parent2 = uipanel2.parent;
			if (parent2 == null)
			{
				break;
			}
			UIPanel componentInParent = parent2.GetComponentInParent<UIPanel>();
			if (componentInParent == null)
			{
				break;
			}
			uipanel2 = componentInParent;
		}
		if (cachedTransform != null)
		{
			vector = cachedTransform.TransformPoint(vector);
			vector2 = cachedTransform.TransformPoint(vector2);
			vector = uipanel2.cachedTransform.InverseTransformPoint(vector);
			vector2 = uipanel2.cachedTransform.InverseTransformPoint(vector2);
			float pixelSizeAdjustment = UIRoot.GetPixelSizeAdjustment(base.gameObject);
			vector /= pixelSizeAdjustment;
			vector2 /= pixelSizeAdjustment;
		}
		Vector3 b = uipanel2.CalculateConstrainOffset(vector, vector2);
		Vector3 vector5 = transform.localPosition + b;
		vector5.x = Mathf.Round(vector5.x);
		vector5.y = Mathf.Round(vector5.y);
		transform.localPosition = vector5;
		transform.parent = parent;
	}

	// Token: 0x040003D4 RID: 980
	public static UIPopupList current;

	// Token: 0x040003D5 RID: 981
	protected static GameObject mChild;

	// Token: 0x040003D6 RID: 982
	protected static float mFadeOutComplete;

	// Token: 0x040003D7 RID: 983
	private const float animSpeed = 0.15f;

	// Token: 0x040003D8 RID: 984
	public UnityEngine.Object atlas;

	// Token: 0x040003D9 RID: 985
	public UnityEngine.Object bitmapFont;

	// Token: 0x040003DA RID: 986
	public Font trueTypeFont;

	// Token: 0x040003DB RID: 987
	public int fontSize = 16;

	// Token: 0x040003DC RID: 988
	public FontStyle fontStyle;

	// Token: 0x040003DD RID: 989
	public string backgroundSprite;

	// Token: 0x040003DE RID: 990
	public string highlightSprite;

	// Token: 0x040003DF RID: 991
	public Sprite background2DSprite;

	// Token: 0x040003E0 RID: 992
	public Sprite highlight2DSprite;

	// Token: 0x040003E1 RID: 993
	public UIPopupList.Position position;

	// Token: 0x040003E2 RID: 994
	public UIPopupList.Selection selection;

	// Token: 0x040003E3 RID: 995
	public NGUIText.Alignment alignment = NGUIText.Alignment.Left;

	// Token: 0x040003E4 RID: 996
	public List<string> items = new List<string>();

	// Token: 0x040003E5 RID: 997
	public List<object> itemData = new List<object>();

	// Token: 0x040003E6 RID: 998
	public List<Action> itemCallbacks = new List<Action>();

	// Token: 0x040003E7 RID: 999
	public Vector2 padding = new Vector3(4f, 4f);

	// Token: 0x040003E8 RID: 1000
	public Color textColor = Color.white;

	// Token: 0x040003E9 RID: 1001
	public Color backgroundColor = Color.white;

	// Token: 0x040003EA RID: 1002
	public Color highlightColor = new Color(0.88235295f, 0.78431374f, 0.5882353f, 1f);

	// Token: 0x040003EB RID: 1003
	public bool isAnimated = true;

	// Token: 0x040003EC RID: 1004
	public bool isLocalized;

	// Token: 0x040003ED RID: 1005
	public UILabel.Modifier textModifier;

	// Token: 0x040003EE RID: 1006
	public bool separatePanel = true;

	// Token: 0x040003EF RID: 1007
	public int overlap;

	// Token: 0x040003F0 RID: 1008
	public UIPopupList.OpenOn openOn;

	// Token: 0x040003F1 RID: 1009
	public List<EventDelegate> onChange = new List<EventDelegate>();

	// Token: 0x040003F2 RID: 1010
	[HideInInspector]
	[SerializeField]
	protected string mSelectedItem;

	// Token: 0x040003F3 RID: 1011
	[HideInInspector]
	[SerializeField]
	protected UIPanel mPanel;

	// Token: 0x040003F4 RID: 1012
	[HideInInspector]
	[SerializeField]
	protected UIBasicSprite mBackground;

	// Token: 0x040003F5 RID: 1013
	[HideInInspector]
	[SerializeField]
	protected UIBasicSprite mHighlight;

	// Token: 0x040003F6 RID: 1014
	[HideInInspector]
	[SerializeField]
	protected UILabel mHighlightedLabel;

	// Token: 0x040003F7 RID: 1015
	[HideInInspector]
	[SerializeField]
	protected List<UILabel> mLabelList = new List<UILabel>();

	// Token: 0x040003F8 RID: 1016
	[HideInInspector]
	[SerializeField]
	protected float mBgBorder;

	// Token: 0x040003F9 RID: 1017
	[Tooltip("Whether the selection will be persistent even after the popup list is closed. By default the selection is cleared when the popup is closed so that the same selection can be chosen again the next time the popup list is opened. If enabled, the selection will persist, but selecting the same choice in succession will not result in the onChange notification being triggered more than once.")]
	public bool keepValue;

	// Token: 0x040003FA RID: 1018
	[NonSerialized]
	protected GameObject mSelection;

	// Token: 0x040003FB RID: 1019
	[NonSerialized]
	protected int mOpenFrame;

	// Token: 0x040003FC RID: 1020
	[HideInInspector]
	[SerializeField]
	private GameObject eventReceiver;

	// Token: 0x040003FD RID: 1021
	[HideInInspector]
	[SerializeField]
	private string functionName = "OnSelectionChange";

	// Token: 0x040003FE RID: 1022
	[HideInInspector]
	[SerializeField]
	private float textScale;

	// Token: 0x040003FF RID: 1023
	[HideInInspector]
	[SerializeField]
	private UILabel textLabel;

	// Token: 0x04000400 RID: 1024
	[NonSerialized]
	public Vector3 startingPosition;

	// Token: 0x04000401 RID: 1025
	private UIPopupList.LegacyEvent mLegacyEvent;

	// Token: 0x04000402 RID: 1026
	[NonSerialized]
	protected bool mExecuting;

	// Token: 0x04000403 RID: 1027
	[NonSerialized]
	protected bool mStarted;

	// Token: 0x04000404 RID: 1028
	protected bool mTweening;

	// Token: 0x04000405 RID: 1029
	public GameObject source;

	// Token: 0x020005D1 RID: 1489
	[DoNotObfuscateNGUI]
	public enum Position
	{
		// Token: 0x04004D71 RID: 19825
		Auto,
		// Token: 0x04004D72 RID: 19826
		Above,
		// Token: 0x04004D73 RID: 19827
		Below
	}

	// Token: 0x020005D2 RID: 1490
	[DoNotObfuscateNGUI]
	public enum Selection
	{
		// Token: 0x04004D75 RID: 19829
		OnPress,
		// Token: 0x04004D76 RID: 19830
		OnClick
	}

	// Token: 0x020005D3 RID: 1491
	[DoNotObfuscateNGUI]
	public enum OpenOn
	{
		// Token: 0x04004D78 RID: 19832
		ClickOrTap,
		// Token: 0x04004D79 RID: 19833
		RightClick,
		// Token: 0x04004D7A RID: 19834
		DoubleClick,
		// Token: 0x04004D7B RID: 19835
		Manual
	}

	// Token: 0x020005D4 RID: 1492
	// (Invoke) Token: 0x06002516 RID: 9494
	public delegate void LegacyEvent(string val);
}
