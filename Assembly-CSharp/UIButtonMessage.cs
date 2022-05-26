// Decompiled with JetBrains decompiler
// Type: UIButtonMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Message (Legacy)")]
public class UIButtonMessage : MonoBehaviour
{
  public GameObject target;
  public string functionName;
  public UIButtonMessage.Trigger trigger;
  public bool includeChildren;
  private bool mStarted;

  private void Start() => this.mStarted = true;

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.OnHover(UICamera.IsHighlighted(this.gameObject));
  }

  private void OnHover(bool isOver)
  {
    if (!this.enabled || (!isOver || this.trigger != UIButtonMessage.Trigger.OnMouseOver) && (isOver || this.trigger != UIButtonMessage.Trigger.OnMouseOut))
      return;
    this.Send();
  }

  private void OnPress(bool isPressed)
  {
    if (!this.enabled || (!isPressed || this.trigger != UIButtonMessage.Trigger.OnPress) && (isPressed || this.trigger != UIButtonMessage.Trigger.OnRelease))
      return;
    this.Send();
  }

  private void OnSelect(bool isSelected)
  {
    if (!this.enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }

  private void OnClick()
  {
    if (!this.enabled || this.trigger != UIButtonMessage.Trigger.OnClick)
      return;
    this.Send();
  }

  private void OnDoubleClick()
  {
    if (!this.enabled || this.trigger != UIButtonMessage.Trigger.OnDoubleClick)
      return;
    this.Send();
  }

  private void Send()
  {
    if (string.IsNullOrEmpty(this.functionName))
      return;
    if ((Object) this.target == (Object) null)
      this.target = this.gameObject;
    if (this.includeChildren)
    {
      Transform[] componentsInChildren = this.target.GetComponentsInChildren<Transform>();
      int index = 0;
      for (int length = componentsInChildren.Length; index < length; ++index)
        componentsInChildren[index].gameObject.SendMessage(this.functionName, (object) this.gameObject, SendMessageOptions.DontRequireReceiver);
    }
    else
      this.target.SendMessage(this.functionName, (object) this.gameObject, SendMessageOptions.DontRequireReceiver);
  }

  [DoNotObfuscateNGUI]
  public enum Trigger
  {
    OnClick,
    OnMouseOver,
    OnMouseOut,
    OnPress,
    OnRelease,
    OnDoubleClick,
  }
}
