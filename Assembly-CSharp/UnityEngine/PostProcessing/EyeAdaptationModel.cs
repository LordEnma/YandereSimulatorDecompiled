// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.EyeAdaptationModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class EyeAdaptationModel : PostProcessingModel
  {
    [SerializeField]
    private EyeAdaptationModel.Settings m_Settings = EyeAdaptationModel.Settings.defaultSettings;

    public EyeAdaptationModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = EyeAdaptationModel.Settings.defaultSettings;

    public enum EyeAdaptationType
    {
      Progressive,
      Fixed,
    }

    [Serializable]
    public struct Settings
    {
      [Range(1f, 99f)]
      [Tooltip("Filters the dark part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
      public float lowPercent;
      [Range(1f, 99f)]
      [Tooltip("Filters the bright part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
      public float highPercent;
      [Tooltip("Minimum average luminance to consider for auto exposure (in EV).")]
      public float minLuminance;
      [Tooltip("Maximum average luminance to consider for auto exposure (in EV).")]
      public float maxLuminance;
      [Min(0.0f)]
      [Tooltip("Exposure bias. Use this to offset the global exposure of the scene.")]
      public float keyValue;
      [Tooltip("Set this to true to let Unity handle the key value automatically based on average luminance.")]
      public bool dynamicKeyValue;
      [Tooltip("Use \"Progressive\" if you want the auto exposure to be animated. Use \"Fixed\" otherwise.")]
      public EyeAdaptationModel.EyeAdaptationType adaptationType;
      [Min(0.0f)]
      [Tooltip("Adaptation speed from a dark to a light environment.")]
      public float speedUp;
      [Min(0.0f)]
      [Tooltip("Adaptation speed from a light to a dark environment.")]
      public float speedDown;
      [Range(-16f, -1f)]
      [Tooltip("Lower bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
      public int logMin;
      [Range(1f, 16f)]
      [Tooltip("Upper bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
      public int logMax;

      public static EyeAdaptationModel.Settings defaultSettings => new EyeAdaptationModel.Settings()
      {
        lowPercent = 45f,
        highPercent = 95f,
        minLuminance = -5f,
        maxLuminance = 1f,
        keyValue = 0.25f,
        dynamicKeyValue = true,
        adaptationType = EyeAdaptationModel.EyeAdaptationType.Progressive,
        speedUp = 2f,
        speedDown = 1f,
        logMin = -8,
        logMax = 4
      };
    }
  }
}
