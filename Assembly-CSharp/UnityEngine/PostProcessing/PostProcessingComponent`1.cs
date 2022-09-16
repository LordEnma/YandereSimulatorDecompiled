// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponent`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public abstract class PostProcessingComponent<T> : PostProcessingComponentBase
    where T : PostProcessingModel
  {
    public T model { get; internal set; }

    public virtual void Init(PostProcessingContext pcontext, T pmodel)
    {
      this.context = pcontext;
      this.model = pmodel;
    }

    public override PostProcessingModel GetModel() => (PostProcessingModel) this.model;
  }
}
