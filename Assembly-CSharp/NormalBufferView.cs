// Decompiled with JetBrains decompiler
// Type: NormalBufferView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
