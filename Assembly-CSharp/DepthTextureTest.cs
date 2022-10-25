// Decompiled with JetBrains decompiler
// Type: DepthTextureTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
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
