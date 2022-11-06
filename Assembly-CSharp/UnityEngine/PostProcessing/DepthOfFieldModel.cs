// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.DepthOfFieldModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class DepthOfFieldModel : PostProcessingModel
  {
    [SerializeField]
    private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

    public DepthOfFieldModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;

    public enum KernelSize
    {
      Small,
      Medium,
      Large,
      VeryLarge,
    }

    [Serializable]
    public struct Settings
    {
      [Min(0.1f)]
      [Tooltip("Distance to the point of focus.")]
      public float focusDistance;
      [Range(0.05f, 32f)]
      [Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
      public float aperture;
      [Range(1f, 300f)]
      [Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
      public float focalLength;
      [Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
      public bool useCameraFov;
      [Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
      public DepthOfFieldModel.KernelSize kernelSize;

      public static DepthOfFieldModel.Settings defaultSettings => new DepthOfFieldModel.Settings()
      {
        focusDistance = 10f,
        aperture = 5.6f,
        focalLength = 50f,
        useCameraFov = false,
        kernelSize = DepthOfFieldModel.KernelSize.Medium
      };
    }
  }
}
