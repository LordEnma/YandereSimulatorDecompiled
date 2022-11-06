// Decompiled with JetBrains decompiler
// Type: UIImageButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/UI/Image Button")]
public class UIImageButton : MonoBehaviour
{
  public UISprite target;
  public string normalSprite;
  public string hoverSprite;
  public string pressedSprite;
  public string disabledSprite;
  public bool pixelSnap = true;

  public bool isEnabled
  {
    get
    {
      Collider component = this.gameObject.GetComponent<Collider>();
      return (bool) (Object) component && component.enabled;
    }
    set
    {
      Collider component = this.gameObject.GetComponent<Collider>();
      if (!(bool) (Object) component || component.enabled == value)
        return;
      component.enabled = value;
      this.UpdateImage();
    }
  }

  private void OnEnable()
  {
    if ((Object) this.target == (Object) null)
      this.target = this.GetComponentInChildren<UISprite>();
    this.UpdateImage();
  }

  private void OnValidate()
  {
    if (!((Object) this.target != (Object) null))
      return;
    if (string.IsNullOrEmpty(this.normalSprite))
      this.normalSprite = this.target.spriteName;
    if (string.IsNullOrEmpty(this.hoverSprite))
      this.hoverSprite = this.target.spriteName;
    if (string.IsNullOrEmpty(this.pressedSprite))
      this.pressedSprite = this.target.spriteName;
    if (!string.IsNullOrEmpty(this.disabledSprite))
      return;
    this.disabledSprite = this.target.spriteName;
  }

  private void UpdateImage()
  {
    if (!((Object) this.target != (Object) null))
      return;
    if (this.isEnabled)
      this.SetSprite(UICamera.IsHighlighted(this.gameObject) ? this.hoverSprite : this.normalSprite);
    else
      this.SetSprite(this.disabledSprite);
  }

  private void OnHover(bool isOver)
  {
    if (!this.isEnabled || !((Object) this.target != (Object) null))
      return;
    this.SetSprite(isOver ? this.hoverSprite : this.normalSprite);
  }

  private void OnPress(bool pressed)
  {
    if (pressed)
      this.SetSprite(this.pressedSprite);
    else
      this.UpdateImage();
  }

  private void SetSprite(string sprite)
  {
    if (string.IsNullOrEmpty(sprite))
      return;
    INGUIAtlas atlas = this.target.atlas;
    if (atlas == null)
      return;
    INGUIAtlas nguiAtlas = atlas;
    if (nguiAtlas == null || nguiAtlas.GetSprite(sprite) == null)
      return;
    this.target.spriteName = sprite;
    if (!this.pixelSnap)
      return;
    this.target.MakePixelPerfect();
  }
}
