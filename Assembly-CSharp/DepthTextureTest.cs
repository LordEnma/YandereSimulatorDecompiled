// Decompiled with JetBrains decompiler
// Type: DepthTextureTest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
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
