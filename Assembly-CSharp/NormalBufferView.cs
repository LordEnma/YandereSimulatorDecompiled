// Decompiled with JetBrains decompiler
// Type: NormalBufferView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NormalBufferView : MonoBehaviour
{
  [SerializeField]
  private Camera camera;
  [SerializeField]
  private Shader normalShader;

  public void ApplyNormalView() => this.camera.SetReplacementShader(this.normalShader, "RenderType");

  public void DisableNormalView() => this.camera.ResetReplacementShader();
}
