using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055A RID: 1370
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060022F2 RID: 8946 RVA: 0x001F2279 File Offset: 0x001F0479
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022F3 RID: 8947 RVA: 0x001F22AC File Offset: 0x001F04AC
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022F4 RID: 8948 RVA: 0x001F22B3 File Offset: 0x001F04B3
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022F5 RID: 8949 RVA: 0x001F22B6 File Offset: 0x001F04B6
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x001F22BC File Offset: 0x001F04BC
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

		// Token: 0x04004AE7 RID: 19175
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x02000699 RID: 1689
		private static class Uniforms
		{
			// Token: 0x04005050 RID: 20560
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005051 RID: 20561
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005052 RID: 20562
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005053 RID: 20563
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005054 RID: 20564
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
