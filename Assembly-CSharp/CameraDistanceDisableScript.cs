// Decompiled with JetBrains decompiler
// Type: CameraDistanceDisableScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
