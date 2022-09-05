// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.ColorGradingModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class ColorGradingModel : PostProcessingModel
  {
    [SerializeField]
    private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

    public ColorGradingModel.Settings settings
    {
      get => this.m_Settings;
      set
      {
        this.m_Settings = value;
        this.OnValidate();
      }
    }

    public bool isDirty { get; internal set; }

    public RenderTexture bakedLut { get; internal set; }

    public override void Reset()
    {
      this.m_Settings = ColorGradingModel.Settings.defaultSettings;
      this.OnValidate();
    }

    public override void OnValidate() => this.isDirty = true;

    public enum Tonemapper
    {
      None,
      ACES,
      Neutral,
    }

    [Serializable]
    public struct TonemappingSettings
    {
      [Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
      public ColorGradingModel.Tonemapper tonemapper;
      [Range(-0.1f, 0.1f)]
      public float neutralBlackIn;
      [Range(1f, 20f)]
      public float neutralWhiteIn;
      [Range(-0.09f, 0.1f)]
      public float neutralBlackOut;
      [Range(1f, 19f)]
      public float neutralWhiteOut;
      [Range(0.1f, 20f)]
      public float neutralWhiteLevel;
      [Range(1f, 10f)]
      public float neutralWhiteClip;

      public static ColorGradingModel.TonemappingSettings defaultSettings => new ColorGradingModel.TonemappingSettings()
      {
        tonemapper = ColorGradingModel.Tonemapper.Neutral,
        neutralBlackIn = 0.02f,
        neutralWhiteIn = 10f,
        neutralBlackOut = 0.0f,
        neutralWhiteOut = 10f,
        neutralWhiteLevel = 5.3f,
        neutralWhiteClip = 10f
      };
    }

    [Serializable]
    public struct BasicSettings
    {
      [Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
      public float postExposure;
      [Range(-100f, 100f)]
      [Tooltip("Sets the white balance to a custom color temperature.")]
      public float temperature;
      [Range(-100f, 100f)]
      [Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
      public float tint;
      [Range(-180f, 180f)]
      [Tooltip("Shift the hue of all colors.")]
      public float hueShift;
      [Range(0.0f, 2f)]
      [Tooltip("Pushes the intensity of all colors.")]
      public float saturation;
      [Range(0.0f, 2f)]
      [Tooltip("Expands or shrinks the overall range of tonal values.")]
      public float contrast;

      public static ColorGradingModel.BasicSettings defaultSettings => new ColorGradingModel.BasicSettings()
      {
        postExposure = 0.0f,
        temperature = 0.0f,
        tint = 0.0f,
        hueShift = 0.0f,
        saturation = 1f,
        contrast = 1f
      };
    }

    [Serializable]
    public struct ChannelMixerSettings
    {
      public Vector3 red;
      public Vector3 green;
      public Vector3 blue;
      [HideInInspector]
      public int currentEditingChannel;

      public static ColorGradingModel.ChannelMixerSettings defaultSettings => new ColorGradingModel.ChannelMixerSettings()
      {
        red = new Vector3(1f, 0.0f, 0.0f),
        green = new Vector3(0.0f, 1f, 0.0f),
        blue = new Vector3(0.0f, 0.0f, 1f),
        currentEditingChannel = 0
      };
    }

    [Serializable]
    public struct LogWheelsSettings
    {
      [Trackball("GetSlopeValue")]
      public Color slope;
      [Trackball("GetPowerValue")]
      public Color power;
      [Trackball("GetOffsetValue")]
      public Color offset;

      public static ColorGradingModel.LogWheelsSettings defaultSettings => new ColorGradingModel.LogWheelsSettings()
      {
        slope = Color.clear,
        power = Color.clear,
        offset = Color.clear
      };
    }

    [Serializable]
    public struct LinearWheelsSettings
    {
      [Trackball("GetLiftValue")]
      public Color lift;
      [Trackball("GetGammaValue")]
      public Color gamma;
      [Trackball("GetGainValue")]
      public Color gain;

      public static ColorGradingModel.LinearWheelsSettings defaultSettings => new ColorGradingModel.LinearWheelsSettings()
      {
        lift = Color.clear,
        gamma = Color.clear,
        gain = Color.clear
      };
    }

    public enum ColorWheelMode
    {
      Linear,
      Log,
    }

    [Serializable]
    public struct ColorWheelsSettings
    {
      public ColorGradingModel.ColorWheelMode mode;
      [TrackballGroup]
      public ColorGradingModel.LogWheelsSettings log;
      [TrackballGroup]
      public ColorGradingModel.LinearWheelsSettings linear;

      public static ColorGradingModel.ColorWheelsSettings defaultSettings => new ColorGradingModel.ColorWheelsSettings()
      {
        mode = ColorGradingModel.ColorWheelMode.Log,
        log = ColorGradingModel.LogWheelsSettings.defaultSettings,
        linear = ColorGradingModel.LinearWheelsSettings.defaultSettings
      };
    }

    [Serializable]
    public struct CurvesSettings
    {
      public ColorGradingCurve master;
      public ColorGradingCurve red;
      public ColorGradingCurve green;
      public ColorGradingCurve blue;
      public ColorGradingCurve hueVShue;
      public ColorGradingCurve hueVSsat;
      public ColorGradingCurve satVSsat;
      public ColorGradingCurve lumVSsat;
      [HideInInspector]
      public int e_CurrentEditingCurve;
      [HideInInspector]
      public bool e_CurveY;
      [HideInInspector]
      public bool e_CurveR;
      [HideInInspector]
      public bool e_CurveG;
      [HideInInspector]
      public bool e_CurveB;

      public static ColorGradingModel.CurvesSettings defaultSettings => new ColorGradingModel.CurvesSettings()
      {
        master = new ColorGradingCurve(new AnimationCurve(new Keyframe[2]
        {
          new Keyframe(0.0f, 0.0f, 1f, 1f),
          new Keyframe(1f, 1f, 1f, 1f)
        }), 0.0f, false, new Vector2(0.0f, 1f)),
        red = new ColorGradingCurve(new AnimationCurve(new Keyframe[2]
        {
          new Keyframe(0.0f, 0.0f, 1f, 1f),
          new Keyframe(1f, 1f, 1f, 1f)
        }), 0.0f, false, new Vector2(0.0f, 1f)),
        green = new ColorGradingCurve(new AnimationCurve(new Keyframe[2]
        {
          new Keyframe(0.0f, 0.0f, 1f, 1f),
          new Keyframe(1f, 1f, 1f, 1f)
        }), 0.0f, false, new Vector2(0.0f, 1f)),
        blue = new ColorGradingCurve(new AnimationCurve(new Keyframe[2]
        {
          new Keyframe(0.0f, 0.0f, 1f, 1f),
          new Keyframe(1f, 1f, 1f, 1f)
        }), 0.0f, false, new Vector2(0.0f, 1f)),
        hueVShue = new ColorGradingCurve(new AnimationCurve(), 0.5f, true, new Vector2(0.0f, 1f)),
        hueVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, true, new Vector2(0.0f, 1f)),
        satVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, false, new Vector2(0.0f, 1f)),
        lumVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, false, new Vector2(0.0f, 1f)),
        e_CurrentEditingCurve = 0,
        e_CurveY = true,
        e_CurveR = false,
        e_CurveG = false,
        e_CurveB = false
      };
    }

    [Serializable]
    public struct Settings
    {
      public ColorGradingModel.TonemappingSettings tonemapping;
      public ColorGradingModel.BasicSettings basic;
      public ColorGradingModel.ChannelMixerSettings channelMixer;
      public ColorGradingModel.ColorWheelsSettings colorWheels;
      public ColorGradingModel.CurvesSettings curves;

      public static ColorGradingModel.Settings defaultSettings => new ColorGradingModel.Settings()
      {
        tonemapping = ColorGradingModel.TonemappingSettings.defaultSettings,
        basic = ColorGradingModel.BasicSettings.defaultSettings,
        channelMixer = ColorGradingModel.ChannelMixerSettings.defaultSettings,
        colorWheels = ColorGradingModel.ColorWheelsSettings.defaultSettings,
        curves = ColorGradingModel.CurvesSettings.defaultSettings
      };
    }
  }
}
