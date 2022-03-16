using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000560 RID: 1376
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06002319 RID: 8985 RVA: 0x001F5799 File Offset: 0x001F3999
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x0600231A RID: 8986 RVA: 0x001F57CC File Offset: 0x001F39CC
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x0600231B RID: 8987 RVA: 0x001F57D3 File Offset: 0x001F39D3
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x0600231C RID: 8988 RVA: 0x001F57D6 File Offset: 0x001F39D6
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x0600231D RID: 8989 RVA: 0x001F57DC File Offset: 0x001F39DC
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

		// Token: 0x04004B73 RID: 19315
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x020006A1 RID: 1697
		private static class Uniforms
		{
			// Token: 0x040050E1 RID: 20705
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x040050E2 RID: 20706
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x040050E3 RID: 20707
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x040050E4 RID: 20708
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x040050E5 RID: 20709
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
