// Decompiled with JetBrains decompiler
// Type: UIInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Input Field")]
public class UIInput : MonoBehaviour
{
  public static UIInput current;
  public static UIInput selection;
  public UILabel label;
  public UIInput.InputType inputType;
  public UIInput.OnReturnKey onReturnKey;
  public UIInput.KeyboardType keyboardType;
  public bool hideInput;
  [NonSerialized]
  public bool selectAllTextOnFocus = true;
  public bool submitOnUnselect;
  public UIInput.Validation validation;
  public int characterLimit;
  public string savedAs;
  [HideInInspector]
  [SerializeField]
  private GameObject selectOnTab;
  public Color activeTextColor = Color.white;
  public Color caretColor = new Color(1f, 1f, 1f, 0.8f);
  public Color selectionColor = new Color(1f, 0.8745098f, 0.5529412f, 0.5f);
  public List<EventDelegate> onSubmit = new List<EventDelegate>();
  public List<EventDelegate> onChange = new List<EventDelegate>();
  public UIInput.OnValidate onValidate;
  [SerializeField]
  [HideInInspector]
  protected string mValue;
  [NonSerialized]
  protected string mDefaultText = "";
  [NonSerialized]
  protected Color mDefaultColor = Color.white;
  [NonSerialized]
  protected float mPosition;
  [NonSerialized]
  protected bool mDoInit = true;
  [NonSerialized]
  protected NGUIText.Alignment mAlignment = NGUIText.Alignment.Left;
  [NonSerialized]
  protected bool mLoadSavedValue = true;
  protected static int mDrawStart = 0;
  protected static string mLastIME = "";
  [NonSerialized]
  protected int mSelectionStart;
  [NonSerialized]
  protected int mSelectionEnd;
  [NonSerialized]
  protected UITexture mHighlight;
  [NonSerialized]
  protected UITexture mCaret;
  [NonSerialized]
  protected Texture2D mBlankTex;
  [NonSerialized]
  protected float mNextBlink;
  [NonSerialized]
  protected float mLastAlpha;
  [NonSerialized]
  protected string mCached = "";
  [NonSerialized]
  protected int mSelectMe = -1;
  [NonSerialized]
  protected int mSelectTime = -1;
  [NonSerialized]
  protected bool mStarted;
  [NonSerialized]
  private UIInputOnGUI mOnGUI;
  [NonSerialized]
  private UICamera mCam;
  [NonSerialized]
  private bool mEllipsis;
  private static int mIgnoreKey = 0;
  [NonSerialized]
  public System.Action onUpArrow;
  [NonSerialized]
  public System.Action onDownArrow;

  public string defaultText
  {
    get
    {
      if (this.mDoInit)
        this.Init();
      return this.mDefaultText;
    }
    set
    {
      if (this.mDoInit)
        this.Init();
      this.mDefaultText = value;
      this.UpdateLabel();
    }
  }

  public Color defaultColor
  {
    get
    {
      if (this.mDoInit)
        this.Init();
      return this.mDefaultColor;
    }
    set
    {
      this.mDefaultColor = value;
      if (this.isSelected)
        return;
      this.label.color = value;
    }
  }

  public bool inputShouldBeHidden => this.hideInput && (UnityEngine.Object) this.label != (UnityEngine.Object) null && !this.label.multiLine && this.inputType != UIInput.InputType.Password;

  [Obsolete("Use UIInput.value instead")]
  public string text
  {
    get => this.value;
    set => this.value = value;
  }

  public string value
  {
    get
    {
      if (this.mDoInit)
        this.Init();
      return this.mValue;
    }
    set => this.Set(value);
  }

  public void Set(string value, bool notify = true)
  {
    if (this.mDoInit)
      this.Init();
    if (value == this.value)
      return;
    UIInput.mDrawStart = 0;
    value = this.Validate(value);
    if (!(this.mValue != value))
      return;
    this.mValue = value;
    this.mLoadSavedValue = false;
    if (this.isSelected)
    {
      if (string.IsNullOrEmpty(value))
      {
        this.mSelectionStart = 0;
        this.mSelectionEnd = 0;
      }
      else
      {
        this.mSelectionStart = value.Length;
        this.mSelectionEnd = this.mSelectionStart;
      }
    }
    else if (this.mStarted)
      this.SaveToPlayerPrefs(value);
    this.UpdateLabel();
    if (!notify)
      return;
    this.ExecuteOnChange();
  }

  [Obsolete("Use UIInput.isSelected instead")]
  public bool selected
  {
    get => this.isSelected;
    set => this.isSelected = value;
  }

  public bool isSelected
  {
    get => (UnityEngine.Object) UIInput.selection == (UnityEngine.Object) this;
    set
    {
      if (!value)
      {
        if (!this.isSelected)
          return;
        UICamera.selectedObject = (GameObject) null;
      }
      else
        UICamera.selectedObject = this.gameObject;
    }
  }

  public int cursorPosition
  {
    get => !this.isSelected ? this.value.Length : this.mSelectionEnd;
    set
    {
      if (!this.isSelected)
        return;
      this.mSelectionEnd = value;
      this.UpdateLabel();
    }
  }

  public int selectionStart
  {
    get => !this.isSelected ? this.value.Length : this.mSelectionStart;
    set
    {
      if (!this.isSelected)
        return;
      this.mSelectionStart = value;
      this.UpdateLabel();
    }
  }

  public int selectionEnd
  {
    get => !this.isSelected ? this.value.Length : this.mSelectionEnd;
    set
    {
      if (!this.isSelected)
        return;
      this.mSelectionEnd = value;
      this.UpdateLabel();
    }
  }

  public UITexture caret => this.mCaret;

  public string Validate(string val)
  {
    if (string.IsNullOrEmpty(val))
      return "";
    StringBuilder stringBuilder = new StringBuilder(val.Length);
    for (int index = 0; index < val.Length; ++index)
    {
      char ch = val[index];
      if (this.onValidate != null)
        ch = this.onValidate(stringBuilder.ToString(), stringBuilder.Length, ch);
      else if (this.validation != UIInput.Validation.None)
        ch = this.Validate(stringBuilder.ToString(), stringBuilder.Length, ch);
      if (ch != char.MinValue)
        stringBuilder.Append(ch);
    }
    return this.characterLimit > 0 && stringBuilder.Length > this.characterLimit ? stringBuilder.ToString(0, this.characterLimit) : stringBuilder.ToString();
  }

  public void Start()
  {
    if (this.mStarted)
      return;
    if ((UnityEngine.Object) this.selectOnTab != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.GetComponent<UIKeyNavigation>() == (UnityEngine.Object) null)
        this.gameObject.AddComponent<UIKeyNavigation>().onDown = this.selectOnTab;
      this.selectOnTab = (GameObject) null;
      NGUITools.SetDirty((UnityEngine.Object) this);
    }
    if (this.mLoadSavedValue && !string.IsNullOrEmpty(this.savedAs))
      this.LoadValue();
    else
      this.value = this.mValue.Replace("\\n", "\n");
    this.mStarted = true;
  }

  protected void Init()
  {
    if (!this.mDoInit || !((UnityEngine.Object) this.label != (UnityEngine.Object) null))
      return;
    this.mDoInit = false;
    this.mDefaultText = this.label.text;
    this.mDefaultColor = this.label.color;
    this.mEllipsis = this.label.overflowEllipsis;
    if (this.label.alignment == NGUIText.Alignment.Justified)
    {
      this.label.alignment = NGUIText.Alignment.Left;
      Debug.LogWarning((object) "Input fields using labels with justified alignment are not supported at this time", (UnityEngine.Object) this);
    }
    this.mAlignment = this.label.alignment;
    this.mPosition = this.label.cachedTransform.localPosition.x;
    this.UpdateLabel();
  }

  protected void SaveToPlayerPrefs(string val)
  {
    if (string.IsNullOrEmpty(this.savedAs))
      return;
    if (string.IsNullOrEmpty(val))
      PlayerPrefs.DeleteKey(this.savedAs);
    else
      PlayerPrefs.SetString(this.savedAs, val);
  }

  protected virtual void OnSelect(bool isSelected)
  {
    if (isSelected)
    {
      if ((UnityEngine.Object) this.label != (UnityEngine.Object) null)
        this.label.supportEncoding = false;
      if ((UnityEngine.Object) this.mOnGUI == (UnityEngine.Object) null)
        this.mOnGUI = this.gameObject.AddComponent<UIInputOnGUI>();
      this.OnSelectEvent();
    }
    else
    {
      if ((UnityEngine.Object) this.mOnGUI != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.mOnGUI);
        this.mOnGUI = (UIInputOnGUI) null;
      }
      this.OnDeselectEvent();
    }
  }

  protected void OnSelectEvent()
  {
    this.mSelectTime = Time.frameCount;
    UIInput.selection = this;
    if (this.mDoInit)
      this.Init();
    if ((UnityEngine.Object) this.label != (UnityEngine.Object) null)
    {
      this.mEllipsis = this.label.overflowEllipsis;
      this.label.overflowEllipsis = false;
    }
    if (!((UnityEngine.Object) this.label != (UnityEngine.Object) null) || !NGUITools.GetActive((Behaviour) this))
      return;
    this.mSelectMe = Time.frameCount;
  }

  protected void OnDeselectEvent()
  {
    if (this.mDoInit)
      this.Init();
    if ((UnityEngine.Object) this.label != (UnityEngine.Object) null)
      this.label.overflowEllipsis = this.mEllipsis;
    if ((UnityEngine.Object) this.label != (UnityEngine.Object) null && NGUITools.GetActive((Behaviour) this))
    {
      this.mValue = this.value;
      if (string.IsNullOrEmpty(this.mValue))
      {
        this.label.text = this.mDefaultText;
        this.label.color = this.mDefaultColor;
      }
      else
        this.label.text = this.mValue;
      Input.imeCompositionMode = IMECompositionMode.Auto;
      this.label.alignment = this.mAlignment;
    }
    UIInput.selection = (UIInput) null;
    this.UpdateLabel();
    if (!this.submitOnUnselect)
      return;
    this.Submit();
  }

  protected virtual void Update()
  {
    if (!this.isSelected || this.mSelectTime == Time.frameCount)
      return;
    if (this.mDoInit)
      this.Init();
    if (this.mSelectMe != -1 && this.mSelectMe != Time.frameCount)
    {
      this.mSelectMe = -1;
      this.mSelectionEnd = string.IsNullOrEmpty(this.mValue) ? 0 : this.mValue.Length;
      UIInput.mDrawStart = 0;
      this.mSelectionStart = this.selectAllTextOnFocus ? 0 : this.mSelectionEnd;
      this.label.color = this.activeTextColor;
      Vector2 vector2 = (Vector2) (!((UnityEngine.Object) UICamera.current != (UnityEngine.Object) null) || !((UnityEngine.Object) UICamera.current.cachedCamera != (UnityEngine.Object) null) ? this.label.worldCorners[0] : UICamera.current.cachedCamera.WorldToScreenPoint(this.label.worldCorners[0]));
      vector2.y = (float) Screen.height - vector2.y;
      Input.imeCompositionMode = IMECompositionMode.On;
      Input.compositionCursorPos = vector2;
      this.UpdateLabel();
      if (string.IsNullOrEmpty(Input.inputString))
        return;
    }
    string compositionString = Input.compositionString;
    if (string.IsNullOrEmpty(compositionString) && !string.IsNullOrEmpty(Input.inputString))
    {
      foreach (char ch in Input.inputString)
      {
        if (ch >= ' ' && ch != '\uF700' && ch != '\uF701' && ch != '\uF702' && ch != '\uF703' && ch != '\uF728')
          this.Insert(ch.ToString());
      }
    }
    if (UIInput.mLastIME != compositionString)
    {
      this.mSelectionEnd = string.IsNullOrEmpty(compositionString) ? this.mSelectionStart : this.mValue.Length + compositionString.Length;
      UIInput.mLastIME = compositionString;
      this.UpdateLabel();
      this.ExecuteOnChange();
    }
    if ((UnityEngine.Object) this.mCaret != (UnityEngine.Object) null && (double) this.mNextBlink < (double) RealTime.time)
    {
      this.mNextBlink = RealTime.time + 0.5f;
      this.mCaret.enabled = !this.mCaret.enabled;
    }
    if (this.isSelected && (double) this.mLastAlpha != (double) this.label.finalAlpha)
      this.UpdateLabel();
    if ((UnityEngine.Object) this.mCam == (UnityEngine.Object) null)
      this.mCam = UICamera.FindCameraForLayer(this.gameObject.layer);
    if (!((UnityEngine.Object) this.mCam != (UnityEngine.Object) null))
      return;
    bool flag1 = false;
    if (this.label.multiLine)
    {
      bool flag2 = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
      flag1 = this.onReturnKey != UIInput.OnReturnKey.Submit ? !flag2 : flag2;
    }
    if (UICamera.GetKeyDown(this.mCam.submitKey0) || this.mCam.submitKey0 == KeyCode.Return && UICamera.GetKeyDown(KeyCode.KeypadEnter))
    {
      if (flag1)
      {
        this.Insert("\n");
      }
      else
      {
        if ((UnityEngine.Object) UICamera.controller.current != (UnityEngine.Object) null)
          UICamera.controller.clickNotification = UICamera.ClickNotification.None;
        UICamera.currentKey = this.mCam.submitKey0;
        this.Submit();
      }
    }
    if (UICamera.GetKeyDown(this.mCam.submitKey1) || this.mCam.submitKey1 == KeyCode.Return && UICamera.GetKeyDown(KeyCode.KeypadEnter))
    {
      if (flag1)
      {
        this.Insert("\n");
      }
      else
      {
        if ((UnityEngine.Object) UICamera.controller.current != (UnityEngine.Object) null)
          UICamera.controller.clickNotification = UICamera.ClickNotification.None;
        UICamera.currentKey = this.mCam.submitKey1;
        this.Submit();
      }
    }
    if (this.mCam.useKeyboard || !UICamera.GetKeyUp(KeyCode.Tab))
      return;
    this.OnKey(KeyCode.Tab);
  }

  private void OnKey(KeyCode key)
  {
    int frameCount = Time.frameCount;
    if (UIInput.mIgnoreKey == frameCount)
      return;
    if ((UnityEngine.Object) this.mCam != (UnityEngine.Object) null && (key == this.mCam.cancelKey0 || key == this.mCam.cancelKey1))
    {
      UIInput.mIgnoreKey = frameCount;
      this.isSelected = false;
    }
    else
    {
      if (key != KeyCode.Tab)
        return;
      UIInput.mIgnoreKey = frameCount;
      this.isSelected = false;
      UIKeyNavigation component = this.GetComponent<UIKeyNavigation>();
      if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
        return;
      component.OnKey(KeyCode.Tab);
    }
  }

  protected void DoBackspace()
  {
    if (string.IsNullOrEmpty(this.mValue))
      return;
    if (this.mSelectionStart == this.mSelectionEnd)
    {
      if (this.mSelectionStart < 1)
        return;
      --this.mSelectionEnd;
    }
    this.Insert("");
  }

  public virtual bool ProcessEvent(Event ev)
  {
    if ((UnityEngine.Object) this.label == (UnityEngine.Object) null)
      return false;
    RuntimePlatform platform = Application.platform;
    bool flag1 = (platform == RuntimePlatform.OSXEditor ? 1 : (platform == RuntimePlatform.OSXPlayer ? 1 : 0)) != 0 ? (ev.modifiers & EventModifiers.Command) != 0 : (ev.modifiers & EventModifiers.Control) != 0;
    if ((ev.modifiers & EventModifiers.Alt) != EventModifiers.None)
      flag1 = false;
    bool flag2 = (ev.modifiers & EventModifiers.Shift) != 0;
    switch (ev.keyCode)
    {
      case KeyCode.Backspace:
        ev.Use();
        this.DoBackspace();
        return true;
      case KeyCode.A:
        if (flag1)
        {
          ev.Use();
          this.mSelectionStart = 0;
          this.mSelectionEnd = this.mValue.Length;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.C:
        if (flag1)
        {
          ev.Use();
          NGUITools.clipboard = this.GetSelection();
        }
        return true;
      case KeyCode.V:
        if (flag1)
        {
          ev.Use();
          this.Insert(NGUITools.clipboard);
        }
        return true;
      case KeyCode.X:
        if (flag1)
        {
          ev.Use();
          NGUITools.clipboard = this.GetSelection();
          this.Insert("");
        }
        return true;
      case KeyCode.Delete:
        ev.Use();
        if (!string.IsNullOrEmpty(this.mValue))
        {
          if (this.mSelectionStart == this.mSelectionEnd)
          {
            if (this.mSelectionStart >= this.mValue.Length)
              return true;
            ++this.mSelectionEnd;
          }
          this.Insert("");
        }
        return true;
      case KeyCode.UpArrow:
        ev.Use();
        if (this.onUpArrow != null)
          this.onUpArrow();
        else if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.UpArrow);
          if (this.mSelectionEnd != 0)
            this.mSelectionEnd += UIInput.mDrawStart;
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.DownArrow:
        ev.Use();
        if (this.onDownArrow != null)
          this.onDownArrow();
        else if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.DownArrow);
          if (this.mSelectionEnd != this.label.processedText.Length)
            this.mSelectionEnd += UIInput.mDrawStart;
          else
            this.mSelectionEnd = this.mValue.Length;
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.RightArrow:
        ev.Use();
        if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = Mathf.Min(this.mSelectionEnd + 1, this.mValue.Length);
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.LeftArrow:
        ev.Use();
        if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = Mathf.Max(this.mSelectionEnd - 1, 0);
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.Home:
        ev.Use();
        if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = !this.label.multiLine ? 0 : this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.Home);
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.End:
        ev.Use();
        if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = !this.label.multiLine ? this.mValue.Length : this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.End);
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.PageUp:
        ev.Use();
        if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = 0;
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      case KeyCode.PageDown:
        ev.Use();
        if (!string.IsNullOrEmpty(this.mValue))
        {
          this.mSelectionEnd = this.mValue.Length;
          if (!flag2)
            this.mSelectionStart = this.mSelectionEnd;
          this.UpdateLabel();
        }
        return true;
      default:
        return false;
    }
  }

  protected virtual void Insert(string text)
  {
    string leftText = this.GetLeftText();
    string rightText = this.GetRightText();
    int length1 = rightText.Length;
    StringBuilder stringBuilder = new StringBuilder(leftText.Length + rightText.Length + text.Length);
    stringBuilder.Append(leftText);
    int index1 = 0;
    for (int length2 = text.Length; index1 < length2; ++index1)
    {
      char ch = text[index1];
      if (ch == '\b')
        this.DoBackspace();
      else if (this.characterLimit <= 0 || stringBuilder.Length + length1 < this.characterLimit)
      {
        if (this.onValidate != null)
          ch = this.onValidate(stringBuilder.ToString(), stringBuilder.Length, ch);
        else if (this.validation != UIInput.Validation.None)
          ch = this.Validate(stringBuilder.ToString(), stringBuilder.Length, ch);
        if (ch != char.MinValue)
          stringBuilder.Append(ch);
      }
      else
        break;
    }
    this.mSelectionStart = stringBuilder.Length;
    this.mSelectionEnd = this.mSelectionStart;
    int index2 = 0;
    for (int length3 = rightText.Length; index2 < length3; ++index2)
    {
      char ch = rightText[index2];
      if (this.onValidate != null)
        ch = this.onValidate(stringBuilder.ToString(), stringBuilder.Length, ch);
      else if (this.validation != UIInput.Validation.None)
        ch = this.Validate(stringBuilder.ToString(), stringBuilder.Length, ch);
      if (ch != char.MinValue)
        stringBuilder.Append(ch);
    }
    this.mValue = stringBuilder.ToString();
    this.UpdateLabel();
    this.ExecuteOnChange();
  }

  protected string GetLeftText()
  {
    int length = Mathf.Min(new int[3]
    {
      this.mSelectionStart,
      this.mSelectionEnd,
      this.mValue.Length
    });
    return !string.IsNullOrEmpty(this.mValue) && length >= 0 ? this.mValue.Substring(0, length) : "";
  }

  protected string GetRightText()
  {
    int startIndex = Mathf.Max(this.mSelectionStart, this.mSelectionEnd);
    return !string.IsNullOrEmpty(this.mValue) && startIndex < this.mValue.Length ? this.mValue.Substring(startIndex) : "";
  }

  protected string GetSelection()
  {
    if (string.IsNullOrEmpty(this.mValue) || this.mSelectionStart == this.mSelectionEnd)
      return "";
    int startIndex = Mathf.Min(this.mSelectionStart, this.mSelectionEnd);
    int num = Mathf.Max(this.mSelectionStart, this.mSelectionEnd);
    return this.mValue.Substring(startIndex, num - startIndex);
  }

  protected int GetCharUnderMouse()
  {
    Vector3[] worldCorners = this.label.worldCorners;
    Ray currentRay = UICamera.currentRay;
    float enter;
    return !new Plane(worldCorners[0], worldCorners[1], worldCorners[2]).Raycast(currentRay, out enter) ? 0 : UIInput.mDrawStart + this.label.GetCharacterIndexAtPosition(currentRay.GetPoint(enter), false);
  }

  protected virtual void OnPress(bool isPressed)
  {
    if (!isPressed || !this.isSelected || !((UnityEngine.Object) this.label != (UnityEngine.Object) null) || UICamera.currentScheme != UICamera.ControlScheme.Mouse && UICamera.currentScheme != UICamera.ControlScheme.Touch)
      return;
    this.selectionEnd = this.GetCharUnderMouse();
    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
      return;
    this.selectionStart = this.mSelectionEnd;
  }

  protected virtual void OnDrag(Vector2 delta)
  {
    if (!((UnityEngine.Object) this.label != (UnityEngine.Object) null) || UICamera.currentScheme != UICamera.ControlScheme.Mouse && UICamera.currentScheme != UICamera.ControlScheme.Touch)
      return;
    this.selectionEnd = this.GetCharUnderMouse();
  }

  private void OnDisable() => this.Cleanup();

  protected virtual void Cleanup()
  {
    if ((bool) (UnityEngine.Object) this.mHighlight)
      this.mHighlight.enabled = false;
    if ((bool) (UnityEngine.Object) this.mCaret)
      this.mCaret.enabled = false;
    if (!(bool) (UnityEngine.Object) this.mBlankTex)
      return;
    NGUITools.Destroy((UnityEngine.Object) this.mBlankTex);
    this.mBlankTex = (Texture2D) null;
  }

  public void Submit()
  {
    if (!NGUITools.GetActive((Behaviour) this))
      return;
    this.mValue = this.value;
    if ((UnityEngine.Object) UIInput.current == (UnityEngine.Object) null)
    {
      UIInput.current = this;
      EventDelegate.Execute(this.onSubmit);
      UIInput.current = (UIInput) null;
    }
    this.SaveToPlayerPrefs(this.mValue);
  }

  public void UpdateLabel()
  {
    if (!((UnityEngine.Object) this.label != (UnityEngine.Object) null))
      return;
    if (this.mDoInit)
      this.Init();
    bool isSelected = this.isSelected;
    string str1 = this.value;
    bool flag = string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(Input.compositionString);
    this.label.color = !flag || isSelected ? this.activeTextColor : this.mDefaultColor;
    string text;
    if (flag)
    {
      text = isSelected ? "" : this.mDefaultText;
      this.label.alignment = this.mAlignment;
    }
    else
    {
      string str2;
      if (this.inputType == UIInput.InputType.Password)
      {
        str2 = "";
        string str3 = "*";
        INGUIFont bitmapFont = this.label.bitmapFont;
        if (bitmapFont != null && bitmapFont.bmFont != null && bitmapFont.bmFont.GetGlyph(42) == null)
          str3 = "x";
        int num = 0;
        for (int length = str1.Length; num < length; ++num)
          str2 += str3;
      }
      else
        str2 = str1;
      int num1 = isSelected ? Mathf.Min(str2.Length, this.cursorPosition) : 0;
      string str4 = str2.Substring(0, num1);
      if (isSelected)
        str4 += Input.compositionString;
      text = str4 + str2.Substring(num1, str2.Length - num1);
      if (isSelected && this.label.overflowMethod == UILabel.Overflow.ClampContent && this.label.maxLineCount == 1)
      {
        int offsetToFit1 = this.label.CalculateOffsetToFit(text);
        if (offsetToFit1 == 0)
        {
          UIInput.mDrawStart = 0;
          this.label.alignment = this.mAlignment;
        }
        else if (num1 < UIInput.mDrawStart)
        {
          UIInput.mDrawStart = num1;
          this.label.alignment = NGUIText.Alignment.Left;
        }
        else if (offsetToFit1 < UIInput.mDrawStart)
        {
          UIInput.mDrawStart = offsetToFit1;
          this.label.alignment = NGUIText.Alignment.Left;
        }
        else
        {
          int offsetToFit2 = this.label.CalculateOffsetToFit(text.Substring(0, num1));
          if (offsetToFit2 > UIInput.mDrawStart)
          {
            UIInput.mDrawStart = offsetToFit2;
            this.label.alignment = NGUIText.Alignment.Right;
          }
        }
        if (UIInput.mDrawStart != 0)
          text = text.Substring(UIInput.mDrawStart, text.Length - UIInput.mDrawStart);
      }
      else
      {
        UIInput.mDrawStart = 0;
        this.label.alignment = this.mAlignment;
      }
    }
    this.label.text = text;
    if (isSelected)
    {
      int start = this.mSelectionStart - UIInput.mDrawStart;
      int end = this.mSelectionEnd - UIInput.mDrawStart;
      if ((UnityEngine.Object) this.mBlankTex == (UnityEngine.Object) null)
      {
        this.mBlankTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        for (int y = 0; y < 2; ++y)
        {
          for (int x = 0; x < 2; ++x)
            this.mBlankTex.SetPixel(x, y, Color.white);
        }
        this.mBlankTex.Apply();
      }
      if (start != end)
      {
        if ((UnityEngine.Object) this.mHighlight == (UnityEngine.Object) null)
        {
          this.mHighlight = this.label.cachedGameObject.AddWidget<UITexture>();
          this.mHighlight.name = "Input Highlight";
          this.mHighlight.mainTexture = (Texture) this.mBlankTex;
          this.mHighlight.fillGeometry = false;
          this.mHighlight.pivot = this.label.pivot;
          this.mHighlight.SetAnchor(this.label.cachedTransform);
        }
        else
        {
          this.mHighlight.pivot = this.label.pivot;
          this.mHighlight.mainTexture = (Texture) this.mBlankTex;
          this.mHighlight.MarkAsChanged();
          this.mHighlight.enabled = true;
        }
      }
      if ((UnityEngine.Object) this.mCaret == (UnityEngine.Object) null)
      {
        this.mCaret = this.label.cachedGameObject.AddWidget<UITexture>();
        this.mCaret.name = "Input Caret";
        this.mCaret.mainTexture = (Texture) this.mBlankTex;
        this.mCaret.fillGeometry = false;
        this.mCaret.pivot = this.label.pivot;
        this.mCaret.SetAnchor(this.label.cachedTransform);
      }
      else
      {
        this.mCaret.pivot = this.label.pivot;
        this.mCaret.mainTexture = (Texture) this.mBlankTex;
        this.mCaret.MarkAsChanged();
        this.mCaret.enabled = true;
      }
      if (start != end)
      {
        this.label.PrintOverlay(start, end, this.mCaret.geometry, this.mHighlight.geometry, this.caretColor, this.selectionColor);
        this.mHighlight.enabled = this.mHighlight.geometry.hasVertices;
      }
      else
      {
        this.label.PrintOverlay(start, end, this.mCaret.geometry, (UIGeometry) null, this.caretColor, this.selectionColor);
        if ((UnityEngine.Object) this.mHighlight != (UnityEngine.Object) null)
          this.mHighlight.enabled = false;
      }
      this.mNextBlink = RealTime.time + 0.5f;
      this.mLastAlpha = this.label.finalAlpha;
    }
    else
      this.Cleanup();
  }

  protected char Validate(string text, int pos, char ch)
  {
    if (this.validation == UIInput.Validation.None || !this.enabled)
      return ch;
    if (this.validation == UIInput.Validation.Integer)
    {
      if (ch >= '0' && ch <= '9' || ch == '-' && pos == 0 && !text.Contains("-"))
        return ch;
    }
    else if (this.validation == UIInput.Validation.Float)
    {
      if (ch >= '0' && ch <= '9' || ch == '-' && pos == 0 && !text.Contains("-") || ch == '.' && !text.Contains("."))
        return ch;
    }
    else if (this.validation == UIInput.Validation.Alphanumeric)
    {
      if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9')
        return ch;
    }
    else if (this.validation == UIInput.Validation.Username)
    {
      if (ch >= 'A' && ch <= 'Z')
        return (char) ((int) ch - 65 + 97);
      if (ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9')
        return ch;
    }
    else
    {
      if (this.validation == UIInput.Validation.Filename)
        return ch == ':' || ch == '/' || ch == '\\' || ch == '<' || ch == '>' || ch == '|' || ch == '^' || ch == '*' || ch == ';' || ch == '"' || ch == '`' || ch == '\t' || ch == '\n' ? char.MinValue : ch;
      if (this.validation == UIInput.Validation.Name)
      {
        char ch1 = text.Length > 0 ? text[Mathf.Clamp(pos, 0, text.Length - 1)] : ' ';
        char ch2 = text.Length > 0 ? text[Mathf.Clamp(pos + 1, 0, text.Length - 1)] : '\n';
        if (ch >= 'a' && ch <= 'z')
          return ch1 == ' ' ? (char) ((int) ch - 97 + 65) : ch;
        if (ch >= 'A' && ch <= 'Z')
          return ch1 != ' ' && ch1 != '\'' ? (char) ((int) ch - 65 + 97) : ch;
        if (ch == '\'')
        {
          if (ch1 != ' ' && ch1 != '\'' && ch2 != '\'' && !text.Contains("'"))
            return ch;
        }
        else if (ch == ' ' && ch1 != ' ' && ch1 != '\'' && ch2 != ' ' && ch2 != '\'')
          return ch;
      }
    }
    return char.MinValue;
  }

  protected void ExecuteOnChange()
  {
    if (!((UnityEngine.Object) UIInput.current == (UnityEngine.Object) null) || !EventDelegate.IsValid(this.onChange))
      return;
    UIInput.current = this;
    EventDelegate.Execute(this.onChange);
    UIInput.current = (UIInput) null;
  }

  public void RemoveFocus() => this.isSelected = false;

  public void SaveValue() => this.SaveToPlayerPrefs(this.mValue);

  public void LoadValue()
  {
    if (string.IsNullOrEmpty(this.savedAs))
      return;
    string str = this.mValue.Replace("\\n", "\n");
    this.mValue = "";
    this.value = PlayerPrefs.HasKey(this.savedAs) ? PlayerPrefs.GetString(this.savedAs) : str;
  }

  [DoNotObfuscateNGUI]
  public enum InputType
  {
    Standard,
    AutoCorrect,
    Password,
  }

  [DoNotObfuscateNGUI]
  public enum Validation
  {
    None,
    Integer,
    Float,
    Alphanumeric,
    Username,
    Name,
    Filename,
  }

  [DoNotObfuscateNGUI]
  public enum KeyboardType
  {
    Default,
    ASCIICapable,
    NumbersAndPunctuation,
    URL,
    NumberPad,
    PhonePad,
    NamePhonePad,
    EmailAddress,
  }

  [DoNotObfuscateNGUI]
  public enum OnReturnKey
  {
    Default,
    Submit,
    NewLine,
  }

  public delegate char OnValidate(string text, int charIndex, char addedChar);
}
