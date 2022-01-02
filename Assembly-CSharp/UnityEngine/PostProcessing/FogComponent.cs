using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000556 RID: 1366
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022D5 RID: 8917 RVA: 0x001EF999 File Offset: 0x001EDB99
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x001EF9CC File Offset: 0x001EDBCC
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022D7 RID: 8919 RVA: 0x001EF9D3 File Offset: 0x001EDBD3
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022D8 RID: 8920 RVA: 0x001EF9D6 File Offset: 0x001EDBD6
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022D9 RID: 8921 RVA: 0x001EF9DC File Offset: 0x001EDBDC
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

		// Token: 0x04004AAF RID: 19119
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x0200069B RID: 1691
		private static class Uniforms
		{
			// Token: 0x04005046 RID: 20550
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005047 RID: 20551
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005048 RID: 20552
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005049 RID: 20553
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x0400504A RID: 20554
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
