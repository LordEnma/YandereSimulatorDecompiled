using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000559 RID: 1369
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022E8 RID: 8936 RVA: 0x001F1BC1 File Offset: 0x001EFDC1
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x001F1BF4 File Offset: 0x001EFDF4
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022EA RID: 8938 RVA: 0x001F1BFB File Offset: 0x001EFDFB
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022EB RID: 8939 RVA: 0x001F1BFE File Offset: 0x001EFDFE
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022EC RID: 8940 RVA: 0x001F1C04 File Offset: 0x001EFE04
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

		// Token: 0x04004ADB RID: 19163
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x02000698 RID: 1688
		private static class Uniforms
		{
			// Token: 0x04005044 RID: 20548
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005045 RID: 20549
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005046 RID: 20550
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005047 RID: 20551
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005048 RID: 20552
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
