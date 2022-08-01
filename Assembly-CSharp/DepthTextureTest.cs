// Decompiled with JetBrains decompiler
// Type: DepthTextureTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
