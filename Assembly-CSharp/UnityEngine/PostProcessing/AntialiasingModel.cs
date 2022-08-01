// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.AntialiasingModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class AntialiasingModel : PostProcessingModel
  {
    [SerializeField]
    private AntialiasingModel.Settings m_Settings = AntialiasingModel.Settings.defaultSettings;

    public AntialiasingModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = AntialiasingModel.Settings.defaultSettings;

    public enum Method
    {
      Fxaa,
      Taa,
    }

    public enum FxaaPreset
    {
      ExtremePerformance,
      Performance,
      Default,
      Quality,
      ExtremeQuality,
    }

    [Serializable]
    public struct FxaaQualitySettings
    {
      [Tooltip("The amount of desired sub-pixel aliasing removal. Effects the sharpeness of the output.")]
      [Range(0.0f, 1f)]
      public float subpixelAliasingRemovalAmount;
      [Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
      [Range(0.063f, 0.333f)]
      public float edgeDetectionThreshold;
      [Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
      [Range(0.0f, 0.0833f)]
      public float minimumRequiredLuminance;
      public static AntialiasingModel.FxaaQualitySettings[] presets = new AntialiasingModel.FxaaQualitySettings[5]
      {
        new AntialiasingModel.FxaaQualitySettings()
        {
          subpixelAliasingRemovalAmount = 0.0f,
          edgeDetectionThreshold = 0.333f,
          minimumRequiredLuminance = 0.0833f
        },
        new AntialiasingModel.FxaaQualitySettings()
        {
          subpixelAliasingRemovalAmount = 0.25f,
          edgeDetectionThreshold = 0.25f,
          minimumRequiredLuminance = 0.0833f
        },
        new AntialiasingModel.FxaaQualitySettings()
        {
          subpixelAliasingRemovalAmount = 0.75f,
          edgeDetectionThreshold = 0.166f,
          minimumRequiredLuminance = 0.0833f
        },
        new AntialiasingModel.FxaaQualitySettings()
        {
          subpixelAliasingRemovalAmount = 1f,
          edgeDetectionThreshold = 0.125f,
          minimumRequiredLuminance = 1f / 16f
        },
        new AntialiasingModel.FxaaQualitySettings()
        {
          subpixelAliasingRemovalAmount = 1f,
          edgeDetectionThreshold = 0.063f,
          minimumRequiredLuminance = 0.0312f
        }
      };
    }

    [Serializable]
    public struct FxaaConsoleSettings
    {
      [Tooltip("The amount of spread applied to the sampling coordinates while sampling for subpixel information.")]
      [Range(0.33f, 0.5f)]
      public float subpixelSpreadAmount;
      [Tooltip("This value dictates how sharp the edges in the image are kept; a higher value implies sharper edges.")]
      [Range(2f, 8f)]
      public float edgeSharpnessAmount;
      [Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
      [Range(0.125f, 0.25f)]
      public float edgeDetectionThreshold;
      [Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
      [Range(0.04f, 0.06f)]
      public float minimumRequiredLuminance;
      public static AntialiasingModel.FxaaConsoleSettings[] presets = new AntialiasingModel.FxaaConsoleSettings[5]
      {
        new AntialiasingModel.FxaaConsoleSettings()
        {
          subpixelSpreadAmount = 0.33f,
          edgeSharpnessAmount = 8f,
          edgeDetectionThreshold = 0.25f,
          minimumRequiredLuminance = 0.06f
        },
        new AntialiasingModel.FxaaConsoleSettings()
        {
          subpixelSpreadAmount = 0.33f,
          edgeSharpnessAmount = 8f,
          edgeDetectionThreshold = 0.125f,
          minimumRequiredLuminance = 0.06f
        },
        new AntialiasingModel.FxaaConsoleSettings()
        {
          subpixelSpreadAmount = 0.5f,
          edgeSharpnessAmount = 8f,
          edgeDetectionThreshold = 0.125f,
          minimumRequiredLuminance = 0.05f
        },
        new AntialiasingModel.FxaaConsoleSettings()
        {
          subpixelSpreadAmount = 0.5f,
          edgeSharpnessAmount = 4f,
          edgeDetectionThreshold = 0.125f,
          minimumRequiredLuminance = 0.04f
        },
        new AntialiasingModel.FxaaConsoleSettings()
        {
          subpixelSpreadAmount = 0.5f,
          edgeSharpnessAmount = 2f,
          edgeDetectionThreshold = 0.125f,
          minimumRequiredLuminance = 0.04f
        }
      };
    }

    [Serializable]
    public struct FxaaSettings
    {
      public AntialiasingModel.FxaaPreset preset;

      public static AntialiasingModel.FxaaSettings defaultSettings => new AntialiasingModel.FxaaSettings()
      {
        preset = AntialiasingModel.FxaaPreset.Default
      };
    }

    [Serializable]
    public struct TaaSettings
    {
      [Tooltip("The diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper but more aliased output, while larger values result in more stable but blurrier output.")]
      [Range(0.1f, 1f)]
      public float jitterSpread;
      [Tooltip("Controls the amount of sharpening applied to the color buffer.")]
      [Range(0.0f, 3f)]
      public float sharpen;
      [Tooltip("The blend coefficient for a stationary fragment. Controls the percentage of history sample blended into the final color.")]
      [Range(0.0f, 0.99f)]
      public float stationaryBlending;
      [Tooltip("The blend coefficient for a fragment with significant motion. Controls the percentage of history sample blended into the final color.")]
      [Range(0.0f, 0.99f)]
      public float motionBlending;

      public static AntialiasingModel.TaaSettings defaultSettings => new AntialiasingModel.TaaSettings()
      {
        jitterSpread = 0.75f,
        sharpen = 0.3f,
        stationaryBlending = 0.95f,
        motionBlending = 0.85f
      };
    }

    [Serializable]
    public struct Settings
    {
      public AntialiasingModel.Method method;
      public AntialiasingModel.FxaaSettings fxaaSettings;
      public AntialiasingModel.TaaSettings taaSettings;

      public static AntialiasingModel.Settings defaultSettings => new AntialiasingModel.Settings()
      {
        method = AntialiasingModel.Method.Fxaa,
        fxaaSettings = AntialiasingModel.FxaaSettings.defaultSettings,
        taaSettings = AntialiasingModel.TaaSettings.defaultSettings
      };
    }
  }
}
