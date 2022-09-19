// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
