using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06002338 RID: 9016 RVA: 0x001F7F95 File Offset: 0x001F6195
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x06002339 RID: 9017 RVA: 0x001F7FC8 File Offset: 0x001F61C8
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x0600233A RID: 9018 RVA: 0x001F7FCF File Offset: 0x001F61CF
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x0600233B RID: 9019 RVA: 0x001F7FD2 File Offset: 0x001F61D2
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x0600233C RID: 9020 RVA: 0x001F7FD8 File Offset: 0x001F61D8
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

		// Token: 0x04004BBB RID: 19387
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x020006A7 RID: 1703
		private static class Uniforms
		{
			// Token: 0x04005129 RID: 20777
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x0400512A RID: 20778
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x0400512B RID: 20779
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x0400512C RID: 20780
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x0400512D RID: 20781
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
