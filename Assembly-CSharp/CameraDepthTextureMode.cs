// Decompiled with JetBrains decompiler
// Type: CameraDepthTextureMode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CameraDepthTextureMode : MonoBehaviour
{
  [SerializeField]
  private DepthTextureMode depthTextureMode;

  private void OnValidate() => this.SetCameraDepthTextureMode();

  private void Awake() => this.SetCameraDepthTextureMode();

  private void SetCameraDepthTextureMode() => this.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
}
