// Decompiled with JetBrains decompiler
// Type: CameraDepthTextureMode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
