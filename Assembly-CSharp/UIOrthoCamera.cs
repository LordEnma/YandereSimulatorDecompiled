// Decompiled with JetBrains decompiler
// Type: UIOrthoCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (Camera))]
[AddComponentMenu("NGUI/UI/Orthographic Camera")]
public class UIOrthoCamera : MonoBehaviour
{
  private Camera mCam;
  private Transform mTrans;

  private void Start()
  {
    this.mCam = this.GetComponent<Camera>();
    this.mTrans = this.transform;
    this.mCam.orthographic = true;
  }

  private void Update()
  {
    float b = (float) (((double) this.mCam.rect.yMax * (double) Screen.height - (double) (this.mCam.rect.yMin * (float) Screen.height)) * 0.5) * this.mTrans.lossyScale.y;
    if (Mathf.Approximately(this.mCam.orthographicSize, b))
      return;
    this.mCam.orthographicSize = b;
  }
}
