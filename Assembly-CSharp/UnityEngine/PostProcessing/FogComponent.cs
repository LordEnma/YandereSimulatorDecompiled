using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000559 RID: 1369
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022E6 RID: 8934 RVA: 0x001F18A9 File Offset: 0x001EFAA9
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x001F18DC File Offset: 0x001EFADC
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x001F18E3 File Offset: 0x001EFAE3
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x001F18E6 File Offset: 0x001EFAE6
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022EA RID: 8938 RVA: 0x001F18EC File Offset: 0x001EFAEC
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

		// Token: 0x04004AD5 RID: 19157
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x02000698 RID: 1688
		private static class Uniforms
		{
			// Token: 0x0400503E RID: 20542
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x0400503F RID: 20543
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005040 RID: 20544
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005041 RID: 20545
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005042 RID: 20546
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
