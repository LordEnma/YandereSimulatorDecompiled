// Decompiled with JetBrains decompiler
// Type: UIPopupList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Popup List")]
public class UIPopupList : UIWidgetContainer
{
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
  public UnityEngine.Sprite background2DSprite;
  public UnityEngine.Sprite highlight2DSprite;
  public UIPopupList.Position position;
  public UIPopupList.Selection selection;
  public NGUIText.Alignment alignment = NGUIText.Alignment.Left;
  public List<string> items = new List<string>();
  public List<object> itemData = new List<object>();
  public List<System.Action> itemCallbacks = new List<System.Action>();
  public Vector2 padding = (Vector2) new Vector3(4f, 4f);
  public Color textColor = Color.white;
  public Color backgroundColor = Color.white;
  public Color highlightColor = new Color(0.882352948f, 0.784313738f, 0.5882353f, 1f);
  public bool isAnimated = true;
  public bool isLocalized;
  public UILabel.Modifier textModifier;
  public bool separatePanel = true;
  public int overlap;
  public UIPopupList.OpenOn openOn;
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
  private UIPopupList.LegacyEvent mLegacyEvent;
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
      if (!(this.bitmapFont != (UnityEngine.Object) null))
        return (INGUIFont) null;
      return this.bitmapFont is GameObject ? (INGUIFont) (this.bitmapFont as GameObject).GetComponent<UIFont>() : this.bitmapFont as INGUIFont;
    }
    set
    {
      this.bitmapFont = value as UnityEngine.Object;
      this.trueTypeFont = (Font) null;
    }
  }

  public UnityEngine.Object ambigiousFont
  {
    get
    {
      if ((UnityEngine.Object) this.trueTypeFont != (UnityEngine.Object) null)
        return (UnityEngine.Object) this.trueTypeFont;
      if (!(this.bitmapFont != (UnityEngine.Object) null))
        return (UnityEngine.Object) null;
      return this.bitmapFont is GameObject ? (UnityEngine.Object) (this.bitmapFont as GameObject).GetComponent<UIFont>() : this.bitmapFont;
    }
    set
    {
      switch (value)
      {
        case Font _:
          this.trueTypeFont = value as Font;
          this.bitmapFont = (UnityEngine.Object) null;
          break;
        case INGUIFont _:
          this.bitmapFont = value;
          this.trueTypeFont = (Font) null;
          break;
        case GameObject _:
          this.bitmapFont = (UnityEngine.Object) (value as GameObject).GetComponent<UIFont>();
          this.trueTypeFont = (Font) null;
          break;
      }
    }
  }

  [Obsolete("Use EventDelegate.Add(popup.onChange, YourCallback) instead, and UIPopupList.current.value to determine the state")]
  public UIPopupList.LegacyEvent onSelectionChange
  {
    get => this.mLegacyEvent;
    set => this.mLegacyEvent = value;
  }

  public static bool isOpen
  {
    get
    {
      if (!((UnityEngine.Object) UIPopupList.current != (UnityEngine.Object) null))
        return false;
      return (UnityEngine.Object) UIPopupList.mChild != (UnityEngine.Object) null || (double) UIPopupList.mFadeOutComplete > (double) Time.unscaledTime;
    }
  }

  public virtual string value
  {
    get => this.mSelectedItem;
    set => this.Set(value);
  }

  public virtual object data
  {
    get
    {
      int index = this.items.IndexOf(this.mSelectedItem);
      return index <= -1 || index >= this.itemData.Count ? (object) null : this.itemData[index];
    }
  }

  public System.Action callback
  {
    get
    {
      int index = this.items.IndexOf(this.mSelectedItem);
      return index <= -1 || index >= this.itemCallbacks.Count ? (System.Action) null : this.itemCallbacks[index];
    }
  }

  public bool isColliderEnabled
  {
    get
    {
      Collider component1 = this.GetComponent<Collider>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        return component1.enabled;
      Collider2D component2 = this.GetComponent<Collider2D>();
      return (UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.enabled;
    }
    set
    {
      Collider component1 = this.GetComponent<Collider>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      {
        component1.enabled = value;
      }
      else
      {
        Collider2D component2 = this.GetComponent<Collider2D>();
        if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
          return;
        component2.enabled = value;
      }
    }
  }

  protected bool isValid => this.ambigiousFont != (UnityEngine.Object) null;

  protected int activeFontSize
  {
    get
    {
      INGUIFont font = this.font;
      return (UnityEngine.Object) this.trueTypeFont != (UnityEngine.Object) null || font == null || font == null ? this.fontSize : font.defaultSize;
    }
  }

  protected float activeFontScale
  {
    get
    {
      INGUIFont font = this.font;
      return (UnityEngine.Object) this.trueTypeFont != (UnityEngine.Object) null || font == null || font == null ? 1f : (float) this.fontSize / (float) font.defaultSize;
    }
  }

  protected float fitScale
  {
    get
    {
      if (this.separatePanel)
      {
        float num = (float) this.items.Count * ((float) this.fontSize + this.padding.y) + this.padding.y;
        float y = NGUITools.screenSize.y;
        if ((double) num > (double) y)
          return y / num;
      }
      else if ((UnityEngine.Object) this.mPanel != (UnityEngine.Object) null && (UnityEngine.Object) this.mPanel.anchorCamera != (UnityEngine.Object) null && this.mPanel.anchorCamera.orthographic)
      {
        float num = (float) this.items.Count * ((float) this.fontSize + this.padding.y) + this.padding.y;
        float height = this.mPanel.height;
        if ((double) num > (double) height)
          return height / num;
      }
      return 1f;
    }
  }

  public void Set(string value, bool notify = true)
  {
    if (!(this.mSelectedItem != value))
      return;
    this.mSelectedItem = value;
    if (this.mSelectedItem == null)
      return;
    if (notify && this.mSelectedItem != null)
      this.TriggerCallbacks();
    if (this.keepValue)
      return;
    this.mSelectedItem = (string) null;
  }

  public virtual void Clear()
  {
    this.items.Clear();
    this.itemData.Clear();
    this.itemCallbacks.Clear();
  }

  public virtual void AddItem(string text)
  {
    this.items.Add(text);
    this.itemData.Add((object) text);
    this.itemCallbacks.Add((System.Action) null);
  }

  public virtual void AddItem(string text, System.Action del)
  {
    this.items.Add(text);
    this.itemCallbacks.Add(del);
  }

  public virtual void AddItem(string text, object data, System.Action del = null)
  {
    this.items.Add(text);
    this.itemData.Add(data);
    this.itemCallbacks.Add(del);
  }

  public virtual void RemoveItem(string text)
  {
    int index = this.items.IndexOf(text);
    if (index == -1)
      return;
    this.items.RemoveAt(index);
    this.itemData.RemoveAt(index);
    if (index >= this.itemCallbacks.Count)
      return;
    this.itemCallbacks.RemoveAt(index);
  }

  public virtual void RemoveItemByData(object data)
  {
    int index = this.itemData.IndexOf(data);
    if (index == -1)
      return;
    this.items.RemoveAt(index);
    this.itemData.RemoveAt(index);
    if (index >= this.itemCallbacks.Count)
      return;
    this.itemCallbacks.RemoveAt(index);
  }

  protected void TriggerCallbacks()
  {
    if (this.mExecuting)
      return;
    this.mExecuting = true;
    UIPopupList current = UIPopupList.current;
    UIPopupList.current = this;
    if (this.mLegacyEvent != null)
      this.mLegacyEvent(this.mSelectedItem);
    if (EventDelegate.IsValid(this.onChange))
      EventDelegate.Execute(this.onChange);
    else if ((UnityEngine.Object) this.eventReceiver != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.functionName))
      this.eventReceiver.SendMessage(this.functionName, (object) this.mSelectedItem, SendMessageOptions.DontRequireReceiver);
    System.Action callback = this.callback;
    if (callback != null)
      callback();
    UIPopupList.current = current;
    this.mExecuting = false;
  }

  protected virtual void OnEnable()
  {
    if (EventDelegate.IsValid(this.onChange))
    {
      this.eventReceiver = (GameObject) null;
      this.functionName = (string) null;
    }
    INGUIFont font = this.font;
    if ((double) this.textScale != 0.0)
    {
      this.fontSize = font != null ? Mathf.RoundToInt((float) font.defaultSize * this.textScale) : 16;
      this.textScale = 0.0f;
    }
    if (!((UnityEngine.Object) this.trueTypeFont == (UnityEngine.Object) null) || font == null || !font.isDynamic || font.replacement != null)
      return;
    this.trueTypeFont = font.dynamicFont;
    this.bitmapFont = (UnityEngine.Object) null;
  }

  public virtual void Start()
  {
    if (this.mStarted)
      return;
    this.mStarted = true;
    if (this.keepValue)
    {
      string mSelectedItem = this.mSelectedItem;
      this.mSelectedItem = (string) null;
      this.value = mSelectedItem;
    }
    else
      this.mSelectedItem = (string) null;
    if (!((UnityEngine.Object) this.textLabel != (UnityEngine.Object) null))
      return;
    EventDelegate.Add(this.onChange, new EventDelegate.Callback(this.textLabel.SetCurrentSelection));
    this.textLabel = (UILabel) null;
  }

  protected virtual void OnLocalize()
  {
    if (!this.isLocalized)
      return;
    this.TriggerCallbacks();
  }

  protected virtual void Highlight(UILabel lbl, bool instant)
  {
    if (!((UnityEngine.Object) this.mHighlight != (UnityEngine.Object) null))
      return;
    this.mHighlightedLabel = lbl;
    Vector3 highlightPosition = this.GetHighlightPosition();
    if (!instant && this.isAnimated)
    {
      TweenPosition.Begin(this.mHighlight.gameObject, 0.1f, highlightPosition).method = UITweener.Method.EaseOut;
      if (this.mTweening)
        return;
      this.mTweening = true;
      this.StartCoroutine("UpdateTweenPosition");
    }
    else
      this.mHighlight.cachedTransform.localPosition = highlightPosition;
  }

  protected virtual Vector3 GetHighlightPosition()
  {
    if ((UnityEngine.Object) this.mHighlightedLabel == (UnityEngine.Object) null || (UnityEngine.Object) this.mHighlight == (UnityEngine.Object) null)
      return Vector3.zero;
    Vector4 border = this.mHighlight.border;
    float num = 1f;
    if (this.atlas is INGUIAtlas atlas)
      num = atlas.pixelSize;
    return this.mHighlightedLabel.cachedTransform.localPosition + new Vector3(-(border.x * num), border.w * num, 1f);
  }

  protected virtual IEnumerator UpdateTweenPosition()
  {
    if ((UnityEngine.Object) this.mHighlight != (UnityEngine.Object) null && (UnityEngine.Object) this.mHighlightedLabel != (UnityEngine.Object) null)
    {
      TweenPosition tp = this.mHighlight.GetComponent<TweenPosition>();
      while ((UnityEngine.Object) tp != (UnityEngine.Object) null && tp.enabled)
      {
        tp.to = this.GetHighlightPosition();
        yield return (object) null;
      }
      tp = (TweenPosition) null;
    }
    this.mTweening = false;
  }

  protected virtual void OnItemHover(GameObject go, bool isOver)
  {
    if (!isOver)
      return;
    this.Highlight(go.GetComponent<UILabel>(), false);
  }

  protected virtual void OnItemPress(GameObject go, bool isPressed)
  {
    if (!isPressed || this.selection != UIPopupList.Selection.OnPress)
      return;
    this.OnItemClick(go);
  }

  protected virtual void OnItemClick(GameObject go)
  {
    this.Select(go.GetComponent<UILabel>(), true);
    this.value = go.GetComponent<UIEventListener>().parameter as string;
    UIPlaySound[] components = this.GetComponents<UIPlaySound>();
    int index = 0;
    for (int length = components.Length; index < length; ++index)
    {
      UIPlaySound uiPlaySound = components[index];
      if (uiPlaySound.trigger == UIPlaySound.Trigger.OnClick)
        NGUITools.PlaySound(uiPlaySound.audioClip, uiPlaySound.volume, 1f);
    }
    this.CloseSelf();
  }

  private void Select(UILabel lbl, bool instant) => this.Highlight(lbl, instant);

  protected virtual void OnNavigate(KeyCode key)
  {
    if (!this.enabled || !((UnityEngine.Object) UIPopupList.current == (UnityEngine.Object) this))
      return;
    int num1 = this.mLabelList.IndexOf(this.mHighlightedLabel);
    if (num1 == -1)
      num1 = 0;
    int num2;
    switch (key)
    {
      case KeyCode.UpArrow:
        if (num1 <= 0)
          break;
        this.Select(this.mLabelList[num2 = num1 - 1], false);
        break;
      case KeyCode.DownArrow:
        if (num1 + 1 >= this.mLabelList.Count)
          break;
        this.Select(this.mLabelList[num2 = num1 + 1], false);
        break;
    }
  }

  protected virtual void OnKey(KeyCode key)
  {
    if (!this.enabled || !((UnityEngine.Object) UIPopupList.current == (UnityEngine.Object) this) || key != UICamera.current.cancelKey0 && key != UICamera.current.cancelKey1)
      return;
    this.OnSelect(false);
  }

  protected virtual void OnDisable() => this.CloseSelf();

  protected virtual void OnSelect(bool isSelected)
  {
    if (isSelected)
      return;
    GameObject selectedObject = UICamera.selectedObject;
    if (!((UnityEngine.Object) selectedObject == (UnityEngine.Object) null) && ((UnityEngine.Object) selectedObject == (UnityEngine.Object) UIPopupList.mChild || (UnityEngine.Object) UIPopupList.mChild != (UnityEngine.Object) null && (UnityEngine.Object) selectedObject != (UnityEngine.Object) null && NGUITools.IsChild(UIPopupList.mChild.transform, selectedObject.transform)))
      return;
    this.CloseSelf();
  }

  public static void Close()
  {
    if (!((UnityEngine.Object) UIPopupList.current != (UnityEngine.Object) null))
      return;
    UIPopupList.current.CloseSelf();
    UIPopupList.current = (UIPopupList) null;
  }

  public virtual void CloseSelf()
  {
    if (!((UnityEngine.Object) UIPopupList.mChild != (UnityEngine.Object) null) || !((UnityEngine.Object) UIPopupList.current == (UnityEngine.Object) this))
      return;
    this.StopCoroutine("CloseIfUnselected");
    this.mSelection = (GameObject) null;
    this.mLabelList.Clear();
    if (this.isAnimated)
    {
      UIWidget[] componentsInChildren1 = UIPopupList.mChild.GetComponentsInChildren<UIWidget>();
      int index1 = 0;
      for (int length = componentsInChildren1.Length; index1 < length; ++index1)
      {
        UIWidget uiWidget = componentsInChildren1[index1];
        TweenColor.Begin(uiWidget.gameObject, 0.15f, uiWidget.color with
        {
          a = 0.0f
        }).method = UITweener.Method.EaseOut;
      }
      Collider[] componentsInChildren2 = UIPopupList.mChild.GetComponentsInChildren<Collider>();
      int index2 = 0;
      for (int length = componentsInChildren2.Length; index2 < length; ++index2)
        componentsInChildren2[index2].enabled = false;
      UnityEngine.Object.Destroy((UnityEngine.Object) UIPopupList.mChild, 0.15f);
      UIPopupList.mFadeOutComplete = Time.unscaledTime + Mathf.Max(0.1f, 0.15f);
    }
    else
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) UIPopupList.mChild);
      UIPopupList.mFadeOutComplete = Time.unscaledTime + 0.1f;
    }
    this.mBackground = (UIBasicSprite) null;
    this.mHighlight = (UIBasicSprite) null;
    UIPopupList.mChild = (GameObject) null;
    UIPopupList.current = (UIPopupList) null;
  }

  protected virtual void AnimateColor(UIWidget widget)
  {
    Color color = widget.color;
    widget.color = new Color(color.r, color.g, color.b, 0.0f);
    TweenColor.Begin(widget.gameObject, 0.15f, color).method = UITweener.Method.EaseOut;
  }

  protected virtual void AnimatePosition(UIWidget widget, bool placeAbove, float bottom)
  {
    Vector3 localPosition = widget.cachedTransform.localPosition;
    Vector3 vector3 = placeAbove ? new Vector3(localPosition.x, bottom, localPosition.z) : new Vector3(localPosition.x, 0.0f, localPosition.z);
    widget.cachedTransform.localPosition = vector3;
    TweenPosition.Begin(widget.gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
  }

  protected virtual void AnimateScale(UIWidget widget, bool placeAbove, float bottom)
  {
    GameObject gameObject = widget.gameObject;
    Transform cachedTransform = widget.cachedTransform;
    float fitScale = this.fitScale;
    float num = (float) ((double) this.activeFontSize * (double) this.activeFontScale + (double) this.mBgBorder * 2.0);
    cachedTransform.localScale = new Vector3(fitScale, fitScale * num / (float) widget.height, fitScale);
    TweenScale.Begin(gameObject, 0.15f, Vector3.one).method = UITweener.Method.EaseOut;
    if (!placeAbove)
      return;
    Vector3 localPosition = cachedTransform.localPosition;
    cachedTransform.localPosition = new Vector3(localPosition.x, (float) ((double) localPosition.y - (double) fitScale * (double) widget.height + (double) fitScale * (double) num), localPosition.z);
    TweenPosition.Begin(gameObject, 0.15f, localPosition).method = UITweener.Method.EaseOut;
  }

  protected void Animate(UIWidget widget, bool placeAbove, float bottom)
  {
    this.AnimateColor(widget);
    this.AnimatePosition(widget, placeAbove, bottom);
  }

  protected virtual void OnClick()
  {
    if (this.mOpenFrame == Time.frameCount)
      return;
    if ((UnityEngine.Object) UIPopupList.mChild == (UnityEngine.Object) null)
    {
      if (this.openOn == UIPopupList.OpenOn.DoubleClick || this.openOn == UIPopupList.OpenOn.Manual || this.openOn == UIPopupList.OpenOn.RightClick && UICamera.currentTouchID != -2)
        return;
      this.Show();
    }
    else
    {
      if (!((UnityEngine.Object) this.mHighlightedLabel != (UnityEngine.Object) null))
        return;
      this.OnItemPress(this.mHighlightedLabel.gameObject, true);
    }
  }

  protected virtual void OnDoubleClick()
  {
    if (this.openOn != UIPopupList.OpenOn.DoubleClick)
      return;
    this.Show();
  }

  private IEnumerator CloseIfUnselected()
  {
    GameObject selectedObject;
    do
    {
      yield return (object) null;
      selectedObject = UICamera.selectedObject;
    }
    while (!((UnityEngine.Object) selectedObject != (UnityEngine.Object) this.mSelection) || !((UnityEngine.Object) selectedObject == (UnityEngine.Object) null) && ((UnityEngine.Object) selectedObject == (UnityEngine.Object) UIPopupList.mChild || NGUITools.IsChild(UIPopupList.mChild.transform, selectedObject.transform)));
    this.CloseSelf();
  }

  public virtual void Show()
  {
    if (this.enabled && NGUITools.GetActive(this.gameObject) && (UnityEngine.Object) UIPopupList.mChild == (UnityEngine.Object) null && this.isValid && this.items.Count > 0)
    {
      this.mLabelList.Clear();
      this.StopCoroutine("CloseIfUnselected");
      UICamera.selectedObject = UICamera.hoveredObject ?? this.gameObject;
      this.mSelection = UICamera.selectedObject;
      this.source = this.mSelection;
      if ((UnityEngine.Object) this.source == (UnityEngine.Object) null)
      {
        Debug.LogError((object) "Popup list needs a source object...");
      }
      else
      {
        this.mOpenFrame = Time.frameCount;
        if ((UnityEngine.Object) this.mPanel == (UnityEngine.Object) null)
        {
          this.mPanel = UIPanel.Find(this.transform);
          if ((UnityEngine.Object) this.mPanel == (UnityEngine.Object) null)
            return;
        }
        UIPopupList.mChild = new GameObject("Drop-down List");
        UIPopupList.mChild.layer = this.gameObject.layer;
        if (this.separatePanel)
        {
          if ((UnityEngine.Object) this.GetComponent<Collider>() != (UnityEngine.Object) null)
            UIPopupList.mChild.AddComponent<Rigidbody>().isKinematic = true;
          else if ((UnityEngine.Object) this.GetComponent<Collider2D>() != (UnityEngine.Object) null)
            UIPopupList.mChild.AddComponent<Rigidbody2D>().isKinematic = true;
          UIPanel uiPanel = UIPopupList.mChild.AddComponent<UIPanel>();
          uiPanel.depth = 1000000;
          uiPanel.sortingOrder = this.mPanel.sortingOrder;
        }
        UIPopupList.current = this;
        Transform cachedTransform = this.mPanel.cachedTransform;
        Transform transform1 = UIPopupList.mChild.transform;
        transform1.parent = cachedTransform;
        Transform transform2 = cachedTransform;
        if (this.separatePanel)
        {
          UIRoot componentInParent = this.mPanel.GetComponentInParent<UIRoot>();
          if ((UnityEngine.Object) componentInParent == (UnityEngine.Object) null && UIRoot.list.Count != 0)
            componentInParent = UIRoot.list[0];
          if ((UnityEngine.Object) componentInParent != (UnityEngine.Object) null)
            transform2 = componentInParent.transform;
        }
        Vector3 vector3_1;
        Vector3 vector3_2;
        if (this.openOn == UIPopupList.OpenOn.Manual && (UnityEngine.Object) this.mSelection != (UnityEngine.Object) this.gameObject)
        {
          this.startingPosition = (Vector3) UICamera.lastEventPosition;
          vector3_1 = cachedTransform.InverseTransformPoint(this.mPanel.anchorCamera.ScreenToWorldPoint(this.startingPosition));
          vector3_2 = vector3_1;
          transform1.localPosition = vector3_1;
          this.startingPosition = transform1.position;
        }
        else
        {
          Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(cachedTransform, this.transform, false, false);
          vector3_1 = relativeWidgetBounds.min;
          vector3_2 = relativeWidgetBounds.max;
          transform1.localPosition = vector3_1;
          this.startingPosition = transform1.position;
        }
        this.StartCoroutine("CloseIfUnselected");
        float fitScale = this.fitScale;
        transform1.localRotation = Quaternion.identity;
        transform1.localScale = new Vector3(fitScale, fitScale, fitScale);
        int depth = this.separatePanel ? 0 : NGUITools.CalculateNextDepth(this.mPanel.gameObject);
        if ((UnityEngine.Object) this.background2DSprite != (UnityEngine.Object) null)
        {
          UI2DSprite ui2Dsprite = UIPopupList.mChild.AddWidget<UI2DSprite>(depth);
          ui2Dsprite.sprite2D = this.background2DSprite;
          this.mBackground = (UIBasicSprite) ui2Dsprite;
        }
        else
        {
          if (!(this.atlas != (UnityEngine.Object) null))
            return;
          this.mBackground = (UIBasicSprite) UIPopupList.mChild.AddSprite(this.atlas as INGUIAtlas, this.backgroundSprite, depth);
        }
        bool placeAbove = this.position == UIPopupList.Position.Above;
        if (this.position == UIPopupList.Position.Auto)
        {
          UICamera cameraForLayer = UICamera.FindCameraForLayer(this.mSelection.layer);
          if ((UnityEngine.Object) cameraForLayer != (UnityEngine.Object) null)
            placeAbove = (double) cameraForLayer.cachedCamera.WorldToViewportPoint(this.startingPosition).y < 0.5;
        }
        this.mBackground.pivot = UIWidget.Pivot.TopLeft;
        this.mBackground.color = this.backgroundColor;
        Vector4 border = this.mBackground.border;
        this.mBgBorder = border.y;
        this.mBackground.cachedTransform.localPosition = new Vector3(0.0f, placeAbove ? border.y * 2f - (float) this.overlap : (float) this.overlap, 0.0f);
        int num1;
        if ((UnityEngine.Object) this.highlight2DSprite != (UnityEngine.Object) null)
        {
          UI2DSprite ui2Dsprite = UIPopupList.mChild.AddWidget<UI2DSprite>(num1 = depth + 1);
          ui2Dsprite.sprite2D = this.highlight2DSprite;
          this.mHighlight = (UIBasicSprite) ui2Dsprite;
        }
        else
        {
          if (!(this.atlas != (UnityEngine.Object) null))
            return;
          this.mHighlight = (UIBasicSprite) UIPopupList.mChild.AddSprite(this.atlas as INGUIAtlas, this.highlightSprite, num1 = depth + 1);
        }
        float num2 = 0.0f;
        float num3 = 0.0f;
        if (this.mHighlight.hasBorder)
        {
          num2 = this.mHighlight.border.w;
          num3 = this.mHighlight.border.x;
        }
        this.mHighlight.pivot = UIWidget.Pivot.TopLeft;
        this.mHighlight.color = this.highlightColor;
        float num4 = (float) this.activeFontSize * this.activeFontScale;
        float num5 = num4 + this.padding.y;
        float a = 0.0f;
        float y = placeAbove ? border.y - this.padding.y - (float) this.overlap : -this.padding.y - border.y + (float) this.overlap;
        float f1 = border.y * 2f + this.padding.y;
        List<UILabel> uiLabelList = new List<UILabel>();
        if (!this.items.Contains(this.mSelectedItem))
          this.mSelectedItem = (string) null;
        int index1 = 0;
        for (int count = this.items.Count; index1 < count; ++index1)
        {
          string key = this.items[index1];
          UILabel lbl = UIPopupList.mChild.AddWidget<UILabel>(this.mBackground.depth + 2);
          lbl.name = index1.ToString();
          lbl.pivot = UIWidget.Pivot.TopLeft;
          lbl.bitmapFont = this.bitmapFont as INGUIFont;
          lbl.trueTypeFont = this.trueTypeFont;
          lbl.fontSize = this.fontSize;
          lbl.fontStyle = this.fontStyle;
          lbl.text = this.isLocalized ? Localization.Get(key) : key;
          lbl.modifier = this.textModifier;
          lbl.color = this.textColor;
          lbl.cachedTransform.localPosition = new Vector3(border.x + this.padding.x - lbl.pivotOffset.x, y, -1f);
          lbl.overflowMethod = UILabel.Overflow.ResizeFreely;
          lbl.alignment = this.alignment;
          lbl.symbolStyle = NGUIText.SymbolStyle.Colored;
          uiLabelList.Add(lbl);
          f1 += num5;
          y -= num5;
          a = Mathf.Max(a, lbl.printedSize.x);
          UIEventListener uiEventListener = UIEventListener.Get(lbl.gameObject);
          uiEventListener.onHover = new UIEventListener.BoolDelegate(this.OnItemHover);
          uiEventListener.onPress = new UIEventListener.BoolDelegate(this.OnItemPress);
          uiEventListener.onClick = new UIEventListener.VoidDelegate(this.OnItemClick);
          uiEventListener.parameter = (object) key;
          if (this.mSelectedItem == key || index1 == 0 && string.IsNullOrEmpty(this.mSelectedItem))
            this.Highlight(lbl, true);
          this.mLabelList.Add(lbl);
        }
        float f2 = Mathf.Max(a, (float) ((double) vector3_2.x - (double) vector3_1.x - ((double) border.x + (double) this.padding.x) * 2.0));
        float x = f2;
        Vector3 vector3_3 = new Vector3(x * 0.5f, (float) (-(double) num4 * 0.5), 0.0f);
        Vector3 vector3_4 = new Vector3(x, num4 + this.padding.y, 1f);
        int index2 = 0;
        for (int count = uiLabelList.Count; index2 < count; ++index2)
        {
          UILabel uiLabel = uiLabelList[index2];
          NGUITools.AddWidgetCollider(uiLabel.gameObject);
          uiLabel.autoResizeBoxCollider = false;
          BoxCollider component1 = uiLabel.GetComponent<BoxCollider>();
          if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
          {
            vector3_3.z = component1.center.z;
            component1.center = vector3_3;
            component1.size = vector3_4;
          }
          else
          {
            BoxCollider2D component2 = uiLabel.GetComponent<BoxCollider2D>();
            component2.offset = (Vector2) vector3_3;
            component2.size = (Vector2) vector3_4;
          }
        }
        int num6 = Mathf.RoundToInt(f2);
        float f3 = f2 + (float) (((double) border.x + (double) this.padding.x) * 2.0);
        float num7 = y - border.y;
        this.mBackground.width = Mathf.RoundToInt(f3);
        this.mBackground.height = Mathf.RoundToInt(f1);
        int index3 = 0;
        for (int count = uiLabelList.Count; index3 < count; ++index3)
        {
          UILabel uiLabel = uiLabelList[index3];
          uiLabel.overflowMethod = UILabel.Overflow.ShrinkContent;
          uiLabel.width = num6;
        }
        float num8 = 2f;
        if (this.atlas is INGUIAtlas atlas)
          num8 *= atlas.pixelSize;
        float f4 = (float) ((double) f3 - ((double) border.x + (double) this.padding.x) * 2.0 + (double) num3 * (double) num8);
        float f5 = num4 + num2 * num8;
        this.mHighlight.width = Mathf.RoundToInt(f4);
        this.mHighlight.height = Mathf.RoundToInt(f5);
        if (this.isAnimated)
        {
          this.AnimateColor((UIWidget) this.mBackground);
          if ((double) Time.timeScale == 0.0 || (double) Time.timeScale >= 0.10000000149011612)
          {
            float bottom = num7 + num4;
            this.Animate((UIWidget) this.mHighlight, placeAbove, bottom);
            int index4 = 0;
            for (int count = uiLabelList.Count; index4 < count; ++index4)
              this.Animate((UIWidget) uiLabelList[index4], placeAbove, bottom);
            this.AnimateScale((UIWidget) this.mBackground, placeAbove, bottom);
          }
        }
        if (placeAbove)
        {
          float num9 = border.y * fitScale;
          vector3_1.y = vector3_2.y - border.y * fitScale;
          vector3_2.y = vector3_1.y + ((float) this.mBackground.height - border.y * 2f) * fitScale;
          vector3_2.x = vector3_1.x + (float) this.mBackground.width * fitScale;
          transform1.localPosition = new Vector3(vector3_1.x, vector3_2.y - num9, vector3_1.z);
        }
        else
        {
          vector3_2.y = vector3_1.y + border.y * fitScale;
          vector3_1.y = vector3_2.y - (float) this.mBackground.height * fitScale;
          vector3_2.x = vector3_1.x + (float) this.mBackground.width * fitScale;
        }
        UIPanel uiPanel1 = this.mPanel;
        while (true)
        {
          UIRect parent = uiPanel1.parent;
          if (!((UnityEngine.Object) parent == (UnityEngine.Object) null))
          {
            UIPanel componentInParent = parent.GetComponentInParent<UIPanel>();
            if (!((UnityEngine.Object) componentInParent == (UnityEngine.Object) null))
              uiPanel1 = componentInParent;
            else
              break;
          }
          else
            break;
        }
        if ((UnityEngine.Object) cachedTransform != (UnityEngine.Object) null)
        {
          Vector3 position1 = cachedTransform.TransformPoint(vector3_1);
          Vector3 position2 = cachedTransform.TransformPoint(vector3_2);
          Vector3 vector3_5 = uiPanel1.cachedTransform.InverseTransformPoint(position1);
          Vector3 vector3_6 = uiPanel1.cachedTransform.InverseTransformPoint(position2);
          float pixelSizeAdjustment = UIRoot.GetPixelSizeAdjustment(this.gameObject);
          vector3_1 = vector3_5 / pixelSizeAdjustment;
          vector3_2 = vector3_6 / pixelSizeAdjustment;
        }
        Vector3 constrainOffset = uiPanel1.CalculateConstrainOffset((Vector2) vector3_1, (Vector2) vector3_2);
        Vector3 vector3_7 = transform1.localPosition + constrainOffset;
        vector3_7.x = Mathf.Round(vector3_7.x);
        vector3_7.y = Mathf.Round(vector3_7.y);
        transform1.localPosition = vector3_7;
        transform1.parent = transform2;
      }
    }
    else
      this.OnSelect(false);
  }

  [DoNotObfuscateNGUI]
  public enum Position
  {
    Auto,
    Above,
    Below,
  }

  [DoNotObfuscateNGUI]
  public enum Selection
  {
    OnPress,
    OnClick,
  }

  [DoNotObfuscateNGUI]
  public enum OpenOn
  {
    ClickOrTap,
    RightClick,
    DoubleClick,
    Manual,
  }

  public delegate void LegacyEvent(string val);
}
