// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.FogComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
  public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
  {
    private const string k_ShaderString = "Hidden/Post FX/Fog";

    public override bool active => this.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;

    public override string GetName() => "Fog";

    public override DepthTextureMode GetCameraFlags() => DepthTextureMode.Depth;

    public override CameraEvent GetCameraEvent() => CameraEvent.AfterImageEffectsOpaque;

    public override void PopulateCommandBuffer(CommandBuffer cb)
    {
      FogModel.Settings settings = this.model.settings;
      Material mat = this.context.materialFactory.Get("Hidden/Post FX/Fog");
      mat.shaderKeywords = (string[]) null;
      Color color = GraphicsUtils.isLinearColorSpace ? RenderSettings.fogColor.linear : RenderSettings.fogColor;
      mat.SetColor(FogComponent.Uniforms._FogColor, color);
      mat.SetFloat(FogComponent.Uniforms._Density, RenderSettings.fogDensity);
      mat.SetFloat(FogComponent.Uniforms._Start, RenderSettings.fogStartDistance);
      mat.SetFloat(FogComponent.Uniforms._End, RenderSettings.fogEndDistance);
      switch (RenderSettings.fogMode)
      {
        case FogMode.Linear:
          mat.EnableKeyword("FOG_LINEAR");
          break;
        case FogMode.Exponential:
          mat.EnableKeyword("FOG_EXP");
          break;
        case FogMode.ExponentialSquared:
          mat.EnableKeyword("FOG_EXP2");
          break;
      }
      RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default;
      cb.GetTemporaryRT(FogComponent.Uniforms._TempRT, this.context.width, this.context.height, 24, FilterMode.Bilinear, format);
      cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) FogComponent.Uniforms._TempRT);
      cb.Blit((RenderTargetIdentifier) FogComponent.Uniforms._TempRT, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, mat, settings.excludeSkybox ? 1 : 0);
      cb.ReleaseTemporaryRT(FogComponent.Uniforms._TempRT);
    }

    private static class Uniforms
    {
      internal static readonly int _FogColor = Shader.PropertyToID(nameof (_FogColor));
      internal static readonly int _Density = Shader.PropertyToID(nameof (_Density));
      internal static readonly int _Start = Shader.PropertyToID(nameof (_Start));
      internal static readonly int _End = Shader.PropertyToID(nameof (_End));
      internal static readonly int _TempRT = Shader.PropertyToID(nameof (_TempRT));
    }
  }
}
