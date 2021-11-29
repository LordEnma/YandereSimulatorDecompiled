using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000554 RID: 1364
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060022C1 RID: 8897 RVA: 0x001EDC75 File Offset: 0x001EBE75
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022C2 RID: 8898 RVA: 0x001EDCA8 File Offset: 0x001EBEA8
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x001EDCAF File Offset: 0x001EBEAF
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022C4 RID: 8900 RVA: 0x001EDCB2 File Offset: 0x001EBEB2
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022C5 RID: 8901 RVA: 0x001EDCB8 File Offset: 0x001EBEB8
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

		// Token: 0x04004A67 RID: 19047
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x02000698 RID: 1688
		private static class Uniforms
		{
			// Token: 0x04004FF2 RID: 20466
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04004FF3 RID: 20467
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04004FF4 RID: 20468
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04004FF5 RID: 20469
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04004FF6 RID: 20470
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
