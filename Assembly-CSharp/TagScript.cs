// Decompiled with JetBrains decompiler
// Type: TagScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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

  private void LateUpdate()
  {
    if (!((Object) this.Target != (Object) null))
      return;
    if ((double) Vector3.Angle(this.MainCamera.forward, this.MainCamera.position - this.Target.position) > 90.0)
    {
      Vector2 screenPoint = (Vector2) this.MainCameraCamera.WorldToScreenPoint(this.Target.position);
      this.transform.position = this.UICamera.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, 1f));
    }
    if (this.Target.gameObject.activeInHierarchy)
      return;
    this.Target = (Transform) null;
  }
}
