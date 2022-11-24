// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentRenderTexture`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T>
    where T : PostProcessingModel
  {
    public virtual void Prepare(Material material)
    {
    }
  }
}
