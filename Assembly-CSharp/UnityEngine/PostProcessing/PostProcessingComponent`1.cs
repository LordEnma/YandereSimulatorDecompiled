// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponent`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
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
