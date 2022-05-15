using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x0600234C RID: 9036 RVA: 0x001FAB6D File Offset: 0x001F8D6D
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x0600234D RID: 9037 RVA: 0x001FABA0 File Offset: 0x001F8DA0
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x0600234E RID: 9038 RVA: 0x001FABA7 File Offset: 0x001F8DA7
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x0600234F RID: 9039 RVA: 0x001FABAA File Offset: 0x001F8DAA
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x001FABB0 File Offset: 0x001F8DB0
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

		// Token: 0x04004BF8 RID: 19448
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x020006A9 RID: 1705
		private static class Uniforms
		{
			// Token: 0x0400516E RID: 20846
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x0400516F RID: 20847
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005170 RID: 20848
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005171 RID: 20849
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005172 RID: 20850
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
