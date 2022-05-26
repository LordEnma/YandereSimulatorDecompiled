// Decompiled with JetBrains decompiler
// Type: UIButtonKeys
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Button Keys (Legacy)")]
public class UIButtonKeys : UIKeyNavigation
{
  public UIButtonKeys selectOnClick;
  public UIButtonKeys selectOnUp;
  public UIButtonKeys selectOnDown;
  public UIButtonKeys selectOnLeft;
  public UIButtonKeys selectOnRight;

  protected override void OnEnable()
  {
    this.Upgrade();
    base.OnEnable();
  }

  public void Upgrade()
  {
    if ((Object) this.onClick == (Object) null && (Object) this.selectOnClick != (Object) null)
    {
      this.onClick = this.selectOnClick.gameObject;
      this.selectOnClick = (UIButtonKeys) null;
      NGUITools.SetDirty((Object) this);
    }
    if ((Object) this.onLeft == (Object) null && (Object) this.selectOnLeft != (Object) null)
    {
      this.onLeft = this.selectOnLeft.gameObject;
      this.selectOnLeft = (UIButtonKeys) null;
      NGUITools.SetDirty((Object) this);
    }
    if ((Object) this.onRight == (Object) null && (Object) this.selectOnRight != (Object) null)
    {
      this.onRight = this.selectOnRight.gameObject;
      this.selectOnRight = (UIButtonKeys) null;
      NGUITools.SetDirty((Object) this);
    }
    if ((Object) this.onUp == (Object) null && (Object) this.selectOnUp != (Object) null)
    {
      this.onUp = this.selectOnUp.gameObject;
      this.selectOnUp = (UIButtonKeys) null;
      NGUITools.SetDirty((Object) this);
    }
    if (!((Object) this.onDown == (Object) null) || !((Object) this.selectOnDown != (Object) null))
      return;
    this.onDown = this.selectOnDown.gameObject;
    this.selectOnDown = (UIButtonKeys) null;
    NGUITools.SetDirty((Object) this);
  }
}
