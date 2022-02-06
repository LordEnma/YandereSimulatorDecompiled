using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000559 RID: 1369
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x060022EB RID: 8939 RVA: 0x001F1DC5 File Offset: 0x001EFFC5
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022EC RID: 8940 RVA: 0x001F1DF8 File Offset: 0x001EFFF8
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022ED RID: 8941 RVA: 0x001F1DFF File Offset: 0x001EFFFF
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022EE RID: 8942 RVA: 0x001F1E02 File Offset: 0x001F0002
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x001F1E08 File Offset: 0x001F0008
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

		// Token: 0x04004ADE RID: 19166
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x02000698 RID: 1688
		private static class Uniforms
		{
			// Token: 0x04005047 RID: 20551
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005048 RID: 20552
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005049 RID: 20553
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x0400504A RID: 20554
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x0400504B RID: 20555
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
