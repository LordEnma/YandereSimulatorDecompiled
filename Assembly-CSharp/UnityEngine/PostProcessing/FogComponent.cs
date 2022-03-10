using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06002301 RID: 8961 RVA: 0x001F3831 File Offset: 0x001F1A31
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x06002302 RID: 8962 RVA: 0x001F3864 File Offset: 0x001F1A64
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x06002303 RID: 8963 RVA: 0x001F386B File Offset: 0x001F1A6B
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x06002304 RID: 8964 RVA: 0x001F386E File Offset: 0x001F1A6E
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x06002305 RID: 8965 RVA: 0x001F3874 File Offset: 0x001F1A74
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

		// Token: 0x04004B14 RID: 19220
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x0200069D RID: 1693
		private static class Uniforms
		{
			// Token: 0x04005082 RID: 20610
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005083 RID: 20611
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005084 RID: 20612
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005085 RID: 20613
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005086 RID: 20614
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
