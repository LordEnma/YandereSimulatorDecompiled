// Decompiled with JetBrains decompiler
// Type: UIForwardEvents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Forward Events (Legacy)")]
public class UIForwardEvents : MonoBehaviour
{
  public GameObject target;
  public bool onHover;
  public bool onPress;
  public bool onClick;
  public bool onDoubleClick;
  public bool onSelect;
  public bool onDrag;
  public bool onDrop;
  public bool onSubmit;
  public bool onScroll;

  private void OnHover(bool isOver)
  {
    if (!this.onHover || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnHover), (object) isOver, SendMessageOptions.DontRequireReceiver);
  }

  private void OnPress(bool pressed)
  {
    if (!this.onPress || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnPress), (object) pressed, SendMessageOptions.DontRequireReceiver);
  }

  private void OnClick()
  {
    if (!this.onClick || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnClick), SendMessageOptions.DontRequireReceiver);
  }

  private void OnDoubleClick()
  {
    if (!this.onDoubleClick || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnDoubleClick), SendMessageOptions.DontRequireReceiver);
  }

  private void OnSelect(bool selected)
  {
    if (!this.onSelect || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnSelect), (object) selected, SendMessageOptions.DontRequireReceiver);
  }

  private void OnDrag(Vector2 delta)
  {
    if (!this.onDrag || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnDrag), (object) delta, SendMessageOptions.DontRequireReceiver);
  }

  private void OnDrop(GameObject go)
  {
    if (!this.onDrop || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnDrop), (object) go, SendMessageOptions.DontRequireReceiver);
  }

  private void OnSubmit()
  {
    if (!this.onSubmit || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnSubmit), SendMessageOptions.DontRequireReceiver);
  }

  private void OnScroll(float delta)
  {
    if (!this.onScroll || !((Object) this.target != (Object) null))
      return;
    this.target.SendMessage(nameof (OnScroll), (object) delta, SendMessageOptions.DontRequireReceiver);
  }
}
