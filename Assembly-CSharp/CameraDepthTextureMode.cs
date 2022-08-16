// Decompiled with JetBrains decompiler
// Type: CameraDepthTextureMode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CameraDepthTextureMode : MonoBehaviour
{
  [SerializeField]
  private DepthTextureMode depthTextureMode;

  private void OnValidate() => this.SetCameraDepthTextureMode();

  private void Awake() => this.SetCameraDepthTextureMode();

  private void SetCameraDepthTextureMode() => this.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
}
