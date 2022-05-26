// Decompiled with JetBrains decompiler
// Type: TagScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TagScript : MonoBehaviour
{
  public UISprite Sprite;
  public Camera UICamera;
  public Camera MainCameraCamera;
  public Transform MainCamera;
  public Transform Target;

  private void Start()
  {
    this.Sprite.color = new Color(1f, 0.0f, 0.0f, 0.0f);
    this.MainCameraCamera = this.MainCamera.GetComponent<Camera>();
  }

  private void Update()
  {
    if (!((Object) this.Target != (Object) null) || (double) Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) <= 90.0)
      return;
    Vector2 screenPoint = (Vector2) this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
    this.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, 1f));
  }
}
