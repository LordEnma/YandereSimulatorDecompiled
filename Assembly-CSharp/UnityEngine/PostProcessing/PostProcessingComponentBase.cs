// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public abstract class PostProcessingComponentBase
  {
    public PostProcessingContext context;

    public virtual DepthTextureMode GetCameraFlags() => DepthTextureMode.None;

    public abstract bool active { get; }

    public virtual void OnEnable()
    {
    }

    public virtual void OnDisable()
    {
    }

    public abstract PostProcessingModel GetModel();
  }
}
