// Decompiled with JetBrains decompiler
// Type: NormalBufferView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
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
