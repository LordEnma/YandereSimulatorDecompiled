// Decompiled with JetBrains decompiler
// Type: BlendshapeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BlendshapeScript : MonoBehaviour
{
  public SkinnedMeshRenderer MyMesh;
  public float Happiness;
  public float Blink;

  private void LateUpdate()
  {
    this.Happiness += Time.deltaTime * 10f;
    this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
    this.Blink += Time.deltaTime * 10f;
    this.MyMesh.SetBlendShapeWeight(8, 100f);
  }
}
