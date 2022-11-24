// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
