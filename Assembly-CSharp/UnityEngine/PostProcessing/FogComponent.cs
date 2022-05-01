using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06002341 RID: 9025 RVA: 0x001F9421 File Offset: 0x001F7621
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x06002342 RID: 9026 RVA: 0x001F9454 File Offset: 0x001F7654
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x06002343 RID: 9027 RVA: 0x001F945B File Offset: 0x001F765B
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x06002344 RID: 9028 RVA: 0x001F945E File Offset: 0x001F765E
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x06002345 RID: 9029 RVA: 0x001F9464 File Offset: 0x001F7664
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

		// Token: 0x04004BD1 RID: 19409
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x020006A8 RID: 1704
		private static class Uniforms
		{
			// Token: 0x04005147 RID: 20807
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005148 RID: 20808
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005149 RID: 20809
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x0400514A RID: 20810
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x0400514B RID: 20811
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
