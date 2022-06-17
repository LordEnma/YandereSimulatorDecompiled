// Decompiled with JetBrains decompiler
// Type: UIViewport
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (Camera))]
[AddComponentMenu("NGUI/UI/Viewport Camera")]
public class UIViewport : MonoBehaviour
{
  public Camera sourceCamera;
  public Transform topLeft;
  public Transform bottomRight;
  public float fullSize = 1f;
  private Camera mCam;

  private void Start()
  {
    this.mCam = this.GetComponent<Camera>();
    if (!((Object) this.sourceCamera == (Object) null))
      return;
    this.sourceCamera = Camera.main;
  }

  private void LateUpdate()
  {
    if (!((Object) this.topLeft != (Object) null) || !((Object) this.bottomRight != (Object) null))
      return;
    if (this.topLeft.gameObject.activeInHierarchy)
    {
      Vector3 screenPoint1 = this.sourceCamera.WorldToScreenPoint(this.topLeft.position);
      Vector3 screenPoint2 = this.sourceCamera.WorldToScreenPoint(this.bottomRight.position);
      Rect rect = new Rect(screenPoint1.x / (float) Screen.width, screenPoint2.y / (float) Screen.height, (screenPoint2.x - screenPoint1.x) / (float) Screen.width, (screenPoint1.y - screenPoint2.y) / (float) Screen.height);
      float num = this.fullSize * rect.height;
      if (rect != this.mCam.rect)
        this.mCam.rect = rect;
      if ((double) this.mCam.orthographicSize != (double) num)
        this.mCam.orthographicSize = num;
      this.mCam.enabled = true;
    }
    else
      this.mCam.enabled = false;
  }
}
