// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.BloomModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class BloomModel : PostProcessingModel
  {
    [SerializeField]
    private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

    public BloomModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = BloomModel.Settings.defaultSettings;

    [Serializable]
    public struct BloomSettings
    {
      [Min(0.0f)]
      [Tooltip("Strength of the bloom filter.")]
      public float intensity;
      [Min(0.0f)]
      [Tooltip("Filters out pixels under this level of brightness.")]
      public float threshold;
      [Range(0.0f, 1f)]
      [Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
      public float softKnee;
      [Range(1f, 7f)]
      [Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
      public float radius;
      [Tooltip("Reduces flashing noise with an additional filter.")]
      public bool antiFlicker;

      public float thresholdLinear
      {
        set => this.threshold = Mathf.LinearToGammaSpace(value);
        get => Mathf.GammaToLinearSpace(this.threshold);
      }

      public static BloomModel.BloomSettings defaultSettings => new BloomModel.BloomSettings()
      {
        intensity = 0.5f,
        threshold = 1.1f,
        softKnee = 0.5f,
        radius = 4f,
        antiFlicker = false
      };
    }

    [Serializable]
    public struct LensDirtSettings
    {
      [Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
      public Texture texture;
      [Min(0.0f)]
      [Tooltip("Amount of lens dirtiness.")]
      public float intensity;

      public static BloomModel.LensDirtSettings defaultSettings => new BloomModel.LensDirtSettings()
      {
        texture = (Texture) null,
        intensity = 3f
      };
    }

    [Serializable]
    public struct Settings
    {
      public BloomModel.BloomSettings bloom;
      public BloomModel.LensDirtSettings lensDirt;

      public static BloomModel.Settings defaultSettings => new BloomModel.Settings()
      {
        bloom = BloomModel.BloomSettings.defaultSettings,
        lensDirt = BloomModel.LensDirtSettings.defaultSettings
      };
    }
  }
}
