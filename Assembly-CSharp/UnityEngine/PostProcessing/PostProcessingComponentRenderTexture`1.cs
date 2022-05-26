// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentRenderTexture`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
