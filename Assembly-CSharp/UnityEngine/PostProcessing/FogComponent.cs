using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x0600234D RID: 9037 RVA: 0x001FB0D5 File Offset: 0x001F92D5
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x0600234E RID: 9038 RVA: 0x001FB108 File Offset: 0x001F9308
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x0600234F RID: 9039 RVA: 0x001FB10F File Offset: 0x001F930F
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x001FB112 File Offset: 0x001F9312
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x06002351 RID: 9041 RVA: 0x001FB118 File Offset: 0x001F9318
		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			FogModel.Settings settings = base.model.settings;
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Fog");
			material.shaderKeywords = null;
			Color value = GraphicsUtils.isLinearColorSpace ? RenderSettings.fogColor.linear : RenderSettings.fogColor;
			material.SetColor(FogComponent.Uniforms._FogColor, value);
			material.SetFloat(FogComponent.Uniforms._Density, RenderSettings.fogDensity);
			material.SetFloat(FogComponent.Uniforms._Start, RenderSettings.fogStartDistance);
			material.SetFloat(FogComponent.Uniforms._End, RenderSettings.fogEndDistance);
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
			RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default;
			cb.GetTemporaryRT(FogComponent.Uniforms._TempRT, this.context.width, this.context.height, 24, FilterMode.Bilinear, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, FogComponent.Uniforms._TempRT);
			cb.Blit(FogComponent.Uniforms._TempRT, BuiltinRenderTextureType.CameraTarget, material, settings.excludeSkybox ? 1 : 0);
			cb.ReleaseTemporaryRT(FogComponent.Uniforms._TempRT);
		}

		// Token: 0x04004C01 RID: 19457
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x020006A9 RID: 1705
		private static class Uniforms
		{
			// Token: 0x04005177 RID: 20855
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005178 RID: 20856
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005179 RID: 20857
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x0400517A RID: 20858
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x0400517B RID: 20859
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
