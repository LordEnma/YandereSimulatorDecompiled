// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.AmbientOcclusionComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
  public sealed class AmbientOcclusionComponent : 
    PostProcessingComponentCommandBuffer<AmbientOcclusionModel>
  {
    private const string k_BlitShaderString = "Hidden/Post FX/Blit";
    private const string k_ShaderString = "Hidden/Post FX/Ambient Occlusion";
    private readonly RenderTargetIdentifier[] m_MRT = new RenderTargetIdentifier[2]
    {
      (RenderTargetIdentifier) BuiltinRenderTextureType.GBuffer0,
      (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget
    };

    private AmbientOcclusionComponent.OcclusionSource occlusionSource
    {
      get
      {
        if (this.context.isGBufferAvailable && !this.model.settings.forceForwardCompatibility)
          return AmbientOcclusionComponent.OcclusionSource.GBuffer;
        return this.model.settings.highPrecision && (!this.context.isGBufferAvailable || this.model.settings.forceForwardCompatibility) ? AmbientOcclusionComponent.OcclusionSource.DepthTexture : AmbientOcclusionComponent.OcclusionSource.DepthNormalsTexture;
      }
    }

    private bool ambientOnlySupported => this.context.isHdr && this.model.settings.ambientOnly && this.context.isGBufferAvailable && !this.model.settings.forceForwardCompatibility;

    public override bool active => this.model.enabled && (double) this.model.settings.intensity > 0.0 && !this.context.interrupted;

    public override DepthTextureMode GetCameraFlags()
    {
      DepthTextureMode cameraFlags = DepthTextureMode.None;
      if (this.occlusionSource == AmbientOcclusionComponent.OcclusionSource.DepthTexture)
        cameraFlags |= DepthTextureMode.Depth;
      if (this.occlusionSource != AmbientOcclusionComponent.OcclusionSource.GBuffer)
        cameraFlags |= DepthTextureMode.DepthNormals;
      return cameraFlags;
    }

    public override string GetName() => "Ambient Occlusion";

    public override CameraEvent GetCameraEvent() => !this.ambientOnlySupported || this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.AmbientOcclusion) ? CameraEvent.BeforeImageEffectsOpaque : CameraEvent.BeforeReflections;

    public override void PopulateCommandBuffer(CommandBuffer cb)
    {
      AmbientOcclusionModel.Settings settings = this.model.settings;
      Material mat = this.context.materialFactory.Get("Hidden/Post FX/Blit");
      Material material = this.context.materialFactory.Get("Hidden/Post FX/Ambient Occlusion");
      material.shaderKeywords = (string[]) null;
      material.SetFloat(AmbientOcclusionComponent.Uniforms._Intensity, settings.intensity);
      material.SetFloat(AmbientOcclusionComponent.Uniforms._Radius, settings.radius);
      material.SetFloat(AmbientOcclusionComponent.Uniforms._Downsample, settings.downsampling ? 0.5f : 1f);
      material.SetInt(AmbientOcclusionComponent.Uniforms._SampleCount, (int) settings.sampleCount);
      if (!this.context.isGBufferAvailable && RenderSettings.fog)
      {
        material.SetVector(AmbientOcclusionComponent.Uniforms._FogParams, (Vector4) new Vector3(RenderSettings.fogDensity, RenderSettings.fogStartDistance, RenderSettings.fogEndDistance));
        switch (RenderSettings.fogMode)
        {
          case FogMode.Linear:
            material.EnableKeyword("FOG_LINEAR");
            break;
          case FogMode.Exponential:
            material.EnableKeyword("FOG_EXP");
            break;
          case FogMode.ExponentialSquared:
            material.EnableKeyword("FOG_EXP2");
            break;
        }
      }
      else
        material.EnableKeyword("FOG_OFF");
      int width = this.context.width;
      int height = this.context.height;
      int num = settings.downsampling ? 2 : 1;
      int occlusionTexture1 = AmbientOcclusionComponent.Uniforms._OcclusionTexture1;
      cb.GetTemporaryRT(occlusionTexture1, width / num, height / num, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
      cb.Blit((Texture) null, (RenderTargetIdentifier) occlusionTexture1, material, (int) this.occlusionSource);
      int occlusionTexture2 = AmbientOcclusionComponent.Uniforms._OcclusionTexture2;
      cb.GetTemporaryRT(occlusionTexture2, width, height, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
      cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, (RenderTargetIdentifier) occlusionTexture1);
      cb.Blit((RenderTargetIdentifier) occlusionTexture1, (RenderTargetIdentifier) occlusionTexture2, material, this.occlusionSource == AmbientOcclusionComponent.OcclusionSource.GBuffer ? 4 : 3);
      cb.ReleaseTemporaryRT(occlusionTexture1);
      int occlusionTexture = AmbientOcclusionComponent.Uniforms._OcclusionTexture;
      cb.GetTemporaryRT(occlusionTexture, width, height, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
      cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, (RenderTargetIdentifier) occlusionTexture2);
      cb.Blit((RenderTargetIdentifier) occlusionTexture2, (RenderTargetIdentifier) occlusionTexture, material, 5);
      cb.ReleaseTemporaryRT(occlusionTexture2);
      if (this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.AmbientOcclusion))
      {
        cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, (RenderTargetIdentifier) occlusionTexture);
        cb.Blit((RenderTargetIdentifier) occlusionTexture, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, material, 8);
        this.context.Interrupt();
      }
      else if (this.ambientOnlySupported)
      {
        cb.SetRenderTarget(this.m_MRT, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget);
        cb.DrawMesh(GraphicsUtils.quad, Matrix4x4.identity, material, 0, 7);
      }
      else
      {
        RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default;
        int tempRt = AmbientOcclusionComponent.Uniforms._TempRT;
        cb.GetTemporaryRT(tempRt, this.context.width, this.context.height, 0, FilterMode.Bilinear, format);
        cb.Blit((RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, (RenderTargetIdentifier) tempRt, mat, 0);
        cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, (RenderTargetIdentifier) tempRt);
        cb.Blit((RenderTargetIdentifier) tempRt, (RenderTargetIdentifier) BuiltinRenderTextureType.CameraTarget, material, 6);
        cb.ReleaseTemporaryRT(tempRt);
      }
      cb.ReleaseTemporaryRT(occlusionTexture);
    }

    private static class Uniforms
    {
      internal static readonly int _Intensity = Shader.PropertyToID(nameof (_Intensity));
      internal static readonly int _Radius = Shader.PropertyToID(nameof (_Radius));
      internal static readonly int _FogParams = Shader.PropertyToID(nameof (_FogParams));
      internal static readonly int _Downsample = Shader.PropertyToID(nameof (_Downsample));
      internal static readonly int _SampleCount = Shader.PropertyToID(nameof (_SampleCount));
      internal static readonly int _OcclusionTexture1 = Shader.PropertyToID(nameof (_OcclusionTexture1));
      internal static readonly int _OcclusionTexture2 = Shader.PropertyToID(nameof (_OcclusionTexture2));
      internal static readonly int _OcclusionTexture = Shader.PropertyToID(nameof (_OcclusionTexture));
      internal static readonly int _MainTex = Shader.PropertyToID(nameof (_MainTex));
      internal static readonly int _TempRT = Shader.PropertyToID(nameof (_TempRT));
    }

    private enum OcclusionSource
    {
      DepthTexture,
      DepthNormalsTexture,
      GBuffer,
    }
  }
}
