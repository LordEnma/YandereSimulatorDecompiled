// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentCommandBuffer`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
  public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T>
    where T : PostProcessingModel
  {
    public abstract CameraEvent GetCameraEvent();

    public abstract string GetName();

    public abstract void PopulateCommandBuffer(CommandBuffer cb);
  }
}
