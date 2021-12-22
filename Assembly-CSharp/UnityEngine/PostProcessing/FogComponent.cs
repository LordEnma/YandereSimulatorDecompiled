using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000556 RID: 1366
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060022D2 RID: 8914 RVA: 0x001EF3A9 File Offset: 0x001ED5A9
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022D3 RID: 8915 RVA: 0x001EF3DC File Offset: 0x001ED5DC
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022D4 RID: 8916 RVA: 0x001EF3E3 File Offset: 0x001ED5E3
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022D5 RID: 8917 RVA: 0x001EF3E6 File Offset: 0x001ED5E6
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022D6 RID: 8918 RVA: 0x001EF3EC File Offset: 0x001ED5EC
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

		// Token: 0x04004AA6 RID: 19110
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x0200069B RID: 1691
		private static class Uniforms
		{
			// Token: 0x0400503D RID: 20541
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x0400503E RID: 20542
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x0400503F RID: 20543
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005040 RID: 20544
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005041 RID: 20545
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
