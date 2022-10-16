// Decompiled with JetBrains decompiler
// Type: WindowAutoYaw
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Window Auto-Yaw")]
public class WindowAutoYaw : MonoBehaviour
{
  public int updateOrder;
  public Camera uiCamera;
  public float yawAmount = 20f;
  private Transform mTrans;

  private void OnDisable() => this.mTrans.localRotation = Quaternion.identity;

  private void OnEnable()
  {
    if ((Object) this.uiCamera == (Object) null)
      this.uiCamera = NGUITools.FindCameraForLayer(this.gameObject.layer);
    this.mTrans = this.transform;
  }

  private void Update()
  {
    if (!((Object) this.uiCamera != (Object) null))
      return;
    this.mTrans.localRotation = Quaternion.Euler(0.0f, (float) ((double) this.uiCamera.WorldToViewportPoint(this.mTrans.position).x * 2.0 - 1.0) * this.yawAmount, 0.0f);
  }
}
