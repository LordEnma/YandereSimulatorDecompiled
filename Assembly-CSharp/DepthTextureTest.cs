// Decompiled with JetBrains decompiler
// Type: DepthTextureTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DepthTextureTest : MonoBehaviour
{
  public Camera mainCamera;

  public void Update()
  {
    if (this.mainCamera.depthTextureMode == DepthTextureMode.None)
      return;
    this.mainCamera.depthTextureMode = DepthTextureMode.None;
  }
}
