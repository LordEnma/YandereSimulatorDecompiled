// Decompiled with JetBrains decompiler
// Type: CameraDistanceDisableScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CameraDistanceDisableScript : MonoBehaviour
{
  public Transform RenderTarget;
  public Transform Yandere;
  public Camera MyCamera;

  private void Update()
  {
    if ((double) Vector3.Distance(this.Yandere.position, this.RenderTarget.position) > 15.0)
      this.MyCamera.enabled = false;
    else
      this.MyCamera.enabled = true;
  }
}
