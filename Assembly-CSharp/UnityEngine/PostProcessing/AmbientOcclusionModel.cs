// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.AmbientOcclusionModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class AmbientOcclusionModel : PostProcessingModel
  {
    [SerializeField]
    private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

    public AmbientOcclusionModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

    public enum SampleCount
    {
      Lowest = 3,
      Low = 6,
      Medium = 10, // 0x0000000A
      High = 16, // 0x00000010
    }

    [Serializable]
    public struct Settings
    {
      [Range(0.0f, 4f)]
      [Tooltip("Degree of darkness produced by the effect.")]
      public float intensity;
      [Min(0.0001f)]
      [Tooltip("Radius of sample points, which affects extent of darkened areas.")]
      public float radius;
      [Tooltip("Number of sample points, which affects quality and performance.")]
      public AmbientOcclusionModel.SampleCount sampleCount;
      [Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
      public bool downsampling;
      [Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
      public bool forceForwardCompatibility;
      [Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
      public bool ambientOnly;
      [Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
      public bool highPrecision;

      public static AmbientOcclusionModel.Settings defaultSettings => new AmbientOcclusionModel.Settings()
      {
        intensity = 1f,
        radius = 0.3f,
        sampleCount = AmbientOcclusionModel.SampleCount.Medium,
        downsampling = true,
        forceForwardCompatibility = false,
        ambientOnly = false,
        highPrecision = false
      };
    }
  }
}
