using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000559 RID: 1369
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060022E2 RID: 8930 RVA: 0x001F1009 File Offset: 0x001EF209
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x060022E3 RID: 8931 RVA: 0x001F103C File Offset: 0x001EF23C
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x060022E4 RID: 8932 RVA: 0x001F1043 File Offset: 0x001EF243
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022E5 RID: 8933 RVA: 0x001F1046 File Offset: 0x001EF246
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x001F104C File Offset: 0x001EF24C
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

		// Token: 0x04004ACA RID: 19146
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x0200069E RID: 1694
		private static class Uniforms
		{
			// Token: 0x04005061 RID: 20577
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005062 RID: 20578
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005063 RID: 20579
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005064 RID: 20580
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005065 RID: 20581
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
