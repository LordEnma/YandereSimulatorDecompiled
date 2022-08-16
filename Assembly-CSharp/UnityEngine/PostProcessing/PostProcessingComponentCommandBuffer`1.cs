// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.PostProcessingComponentCommandBuffer`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
