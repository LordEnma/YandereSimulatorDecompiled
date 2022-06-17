// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
