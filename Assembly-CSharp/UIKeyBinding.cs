// Decompiled with JetBrains decompiler
// Type: UIKeyBinding
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Key Binding")]
public class UIKeyBinding : MonoBehaviour
{
  public static List<UIKeyBinding> list = new List<UIKeyBinding>();
  public KeyCode keyCode;
  public UIKeyBinding.Modifier modifier;
  public UIKeyBinding.Action action;
  [NonSerialized]
  private bool mIgnoreUp;
  [NonSerialized]
  private bool mIsInput;
  [NonSerialized]
  private bool mPress;

  public string captionText
  {
    get
    {
      string caption = NGUITools.KeyToCaption(this.keyCode);
      return this.modifier == UIKeyBinding.Modifier.None || this.modifier == UIKeyBinding.Modifier.Any ? caption : this.modifier.ToString() + "+" + caption;
    }
  }

  public static bool IsBound(KeyCode key)
  {
    int index = 0;
    for (int count = UIKeyBinding.list.Count; index < count; ++index)
    {
      UIKeyBinding uiKeyBinding = UIKeyBinding.list[index];
      if ((UnityEngine.Object) uiKeyBinding != (UnityEngine.Object) null && uiKeyBinding.keyCode == key)
        return true;
    }
    return false;
  }

  public static UIKeyBinding Find(string name)
  {
    int index = 0;
    for (int count = UIKeyBinding.list.Count; index < count; ++index)
    {
      if (UIKeyBinding.list[index].name == name)
        return UIKeyBinding.list[index];
    }
    return (UIKeyBinding) null;
  }

  protected virtual void OnEnable() => UIKeyBinding.list.Add(this);

  protected virtual void OnDisable() => UIKeyBinding.list.Remove(this);

  protected virtual void Start()
  {
    UIInput component = this.GetComponent<UIInput>();
    this.mIsInput = (UnityEngine.Object) component != (UnityEngine.Object) null;
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    EventDelegate.Add(component.onSubmit, new EventDelegate.Callback(this.OnSubmit));
  }

  protected virtual void OnSubmit()
  {
    if (UICamera.currentKey != this.keyCode || !this.IsModifierActive())
      return;
    this.mIgnoreUp = true;
  }

  protected virtual bool IsModifierActive() => UIKeyBinding.IsModifierActive(this.modifier);

  public static bool IsModifierActive(UIKeyBinding.Modifier modifier)
  {
    switch (modifier)
    {
      case UIKeyBinding.Modifier.Any:
        return true;
      case UIKeyBinding.Modifier.Shift:
        if (UICamera.GetKey(KeyCode.LeftShift) || UICamera.GetKey(KeyCode.RightShift))
          return true;
        break;
      case UIKeyBinding.Modifier.Ctrl:
        if (UICamera.GetKey(KeyCode.LeftControl) || UICamera.GetKey(KeyCode.RightControl))
          return true;
        break;
      case UIKeyBinding.Modifier.Alt:
        if (UICamera.GetKey(KeyCode.LeftAlt) || UICamera.GetKey(KeyCode.RightAlt))
          return true;
        break;
      case UIKeyBinding.Modifier.None:
        return !UICamera.GetKey(KeyCode.LeftAlt) && !UICamera.GetKey(KeyCode.RightAlt) && !UICamera.GetKey(KeyCode.LeftControl) && !UICamera.GetKey(KeyCode.RightControl) && !UICamera.GetKey(KeyCode.LeftShift) && !UICamera.GetKey(KeyCode.RightShift);
    }
    return false;
  }

  protected virtual void Update()
  {
    if (this.keyCode != KeyCode.Numlock && UICamera.inputHasFocus || this.keyCode == KeyCode.None || !this.IsModifierActive())
      return;
    bool flag1 = UICamera.GetKeyDown(this.keyCode);
    bool flag2 = UICamera.GetKeyUp(this.keyCode);
    if (flag1)
      this.mPress = true;
    if (this.action == UIKeyBinding.Action.PressAndClick || this.action == UIKeyBinding.Action.All)
    {
      if (flag1)
      {
        UICamera.currentTouchID = -1;
        UICamera.currentKey = this.keyCode;
        this.OnBindingPress(true);
      }
      if (this.mPress & flag2)
      {
        UICamera.currentTouchID = -1;
        UICamera.currentKey = this.keyCode;
        this.OnBindingPress(false);
        this.OnBindingClick();
      }
    }
    if ((this.action == UIKeyBinding.Action.Select || this.action == UIKeyBinding.Action.All) && flag2)
    {
      if (this.mIsInput)
      {
        if (!this.mIgnoreUp && (this.keyCode == KeyCode.Numlock || !UICamera.inputHasFocus) && this.mPress)
          UICamera.selectedObject = this.gameObject;
        this.mIgnoreUp = false;
      }
      else if (this.mPress)
        UICamera.hoveredObject = this.gameObject;
    }
    if (!flag2)
      return;
    this.mPress = false;
  }

  protected virtual void OnBindingPress(bool pressed) => UICamera.Notify(this.gameObject, "OnPress", (object) pressed);

  protected virtual void OnBindingClick() => UICamera.Notify(this.gameObject, "OnClick", (object) null);

  public override string ToString() => UIKeyBinding.GetString(this.keyCode, this.modifier);

  public static string GetString(KeyCode keyCode, UIKeyBinding.Modifier modifier) => modifier == UIKeyBinding.Modifier.None ? NGUITools.KeyToCaption(keyCode) : modifier.ToString() + "+" + NGUITools.KeyToCaption(keyCode);

  public static bool GetKeyCode(string text, out KeyCode key, out UIKeyBinding.Modifier modifier)
  {
    key = KeyCode.None;
    modifier = UIKeyBinding.Modifier.None;
    if (string.IsNullOrEmpty(text))
      return true;
    if (text.Length > 2 && text.Contains("+") && text[text.Length - 1] != '+')
    {
      string[] strArray = text.Split(new char[1]{ '+' }, 2);
      key = NGUITools.CaptionToKey(strArray[1]);
      try
      {
        modifier = (UIKeyBinding.Modifier) Enum.Parse(typeof (UIKeyBinding.Modifier), strArray[0]);
      }
      catch (Exception ex)
      {
        return false;
      }
    }
    else
    {
      modifier = UIKeyBinding.Modifier.None;
      key = NGUITools.CaptionToKey(text);
    }
    return true;
  }

  public static UIKeyBinding.Modifier GetActiveModifier()
  {
    UIKeyBinding.Modifier activeModifier = UIKeyBinding.Modifier.None;
    if (UICamera.GetKey(KeyCode.LeftAlt) || UICamera.GetKey(KeyCode.RightAlt))
      activeModifier = UIKeyBinding.Modifier.Alt;
    else if (UICamera.GetKey(KeyCode.LeftShift) || UICamera.GetKey(KeyCode.RightShift))
      activeModifier = UIKeyBinding.Modifier.Shift;
    else if (UICamera.GetKey(KeyCode.LeftControl) || UICamera.GetKey(KeyCode.RightControl))
      activeModifier = UIKeyBinding.Modifier.Ctrl;
    return activeModifier;
  }

  [DoNotObfuscateNGUI]
  public enum Action
  {
    PressAndClick,
    Select,
    All,
  }

  [DoNotObfuscateNGUI]
  public enum Modifier
  {
    Any,
    Shift,
    Ctrl,
    Alt,
    None,
  }
}
