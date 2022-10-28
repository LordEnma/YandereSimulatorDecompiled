// Decompiled with JetBrains decompiler
// Type: DepthTextureTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
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
