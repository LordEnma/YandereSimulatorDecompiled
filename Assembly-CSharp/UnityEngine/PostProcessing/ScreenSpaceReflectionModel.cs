// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.ScreenSpaceReflectionModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class ScreenSpaceReflectionModel : PostProcessingModel
  {
    [SerializeField]
    private ScreenSpaceReflectionModel.Settings m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

    public ScreenSpaceReflectionModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

    public enum SSRResolution
    {
      High = 0,
      Low = 2,
    }

    public enum SSRReflectionBlendType
    {
      PhysicallyBased,
      Additive,
    }

    [Serializable]
    public struct IntensitySettings
    {
      [Tooltip("Nonphysical multiplier for the SSR reflections. 1.0 is physically based.")]
      [Range(0.0f, 2f)]
      public float reflectionMultiplier;
      [Tooltip("How far away from the maxDistance to begin fading SSR.")]
      [Range(0.0f, 1000f)]
      public float fadeDistance;
      [Tooltip("Amplify Fresnel fade out. Increase if floor reflections look good close to the surface and bad farther 'under' the floor.")]
      [Range(0.0f, 1f)]
      public float fresnelFade;
      [Tooltip("Higher values correspond to a faster Fresnel fade as the reflection changes from the grazing angle.")]
      [Range(0.1f, 10f)]
      public float fresnelFadePower;
    }

    [Serializable]
    public struct ReflectionSettings
    {
      [Tooltip("How the reflections are blended into the render.")]
      public ScreenSpaceReflectionModel.SSRReflectionBlendType blendType;
      [Tooltip("Half resolution SSRR is much faster, but less accurate.")]
      public ScreenSpaceReflectionModel.SSRResolution reflectionQuality;
      [Tooltip("Maximum reflection distance in world units.")]
      [Range(0.1f, 300f)]
      public float maxDistance;
      [Tooltip("Max raytracing length.")]
      [Range(16f, 1024f)]
      public int iterationCount;
      [Tooltip("Log base 2 of ray tracing coarse step size. Higher traces farther, lower gives better quality silhouettes.")]
      [Range(1f, 16f)]
      public int stepSize;
      [Tooltip("Typical thickness of columns, walls, furniture, and other objects that reflection rays might pass behind.")]
      [Range(0.01f, 10f)]
      public float widthModifier;
      [Tooltip("Blurriness of reflections.")]
      [Range(0.1f, 8f)]
      public float reflectionBlur;
      [Tooltip("Disable for a performance gain in scenes where most glossy objects are horizontal, like floors, water, and tables. Leave on for scenes with glossy vertical objects.")]
      public bool reflectBackfaces;
    }

    [Serializable]
    public struct ScreenEdgeMask
    {
      [Tooltip("Higher = fade out SSRR near the edge of the screen so that reflections don't pop under camera motion.")]
      [Range(0.0f, 1f)]
      public float intensity;
    }

    [Serializable]
    public struct Settings
    {
      public ScreenSpaceReflectionModel.ReflectionSettings reflection;
      public ScreenSpaceReflectionModel.IntensitySettings intensity;
      public ScreenSpaceReflectionModel.ScreenEdgeMask screenEdgeMask;

      public static ScreenSpaceReflectionModel.Settings defaultSettings => new ScreenSpaceReflectionModel.Settings()
      {
        reflection = new ScreenSpaceReflectionModel.ReflectionSettings()
        {
          blendType = ScreenSpaceReflectionModel.SSRReflectionBlendType.PhysicallyBased,
          reflectionQuality = ScreenSpaceReflectionModel.SSRResolution.Low,
          maxDistance = 100f,
          iterationCount = 256,
          stepSize = 3,
          widthModifier = 0.5f,
          reflectionBlur = 1f,
          reflectBackfaces = false
        },
        intensity = new ScreenSpaceReflectionModel.IntensitySettings()
        {
          reflectionMultiplier = 1f,
          fadeDistance = 100f,
          fresnelFade = 1f,
          fresnelFadePower = 1f
        },
        screenEdgeMask = new ScreenSpaceReflectionModel.ScreenEdgeMask()
        {
          intensity = 0.03f
        }
      };
    }
  }
}
