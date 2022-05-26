// Decompiled with JetBrains decompiler
// Type: CameraDepthTextureMode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CameraDepthTextureMode : MonoBehaviour
{
  [SerializeField]
  private DepthTextureMode depthTextureMode;

  private void OnValidate() => this.SetCameraDepthTextureMode();

  private void Awake() => this.SetCameraDepthTextureMode();

  private void SetCameraDepthTextureMode() => this.GetComponent<Camera>().depthTextureMode = this.depthTextureMode;
}
