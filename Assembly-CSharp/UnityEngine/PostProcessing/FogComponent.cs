using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06002329 RID: 9001 RVA: 0x001F7009 File Offset: 0x001F5209
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x0600232A RID: 9002 RVA: 0x001F703C File Offset: 0x001F523C
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x0600232B RID: 9003 RVA: 0x001F7043 File Offset: 0x001F5243
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x0600232C RID: 9004 RVA: 0x001F7046 File Offset: 0x001F5246
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x0600232D RID: 9005 RVA: 0x001F704C File Offset: 0x001F524C
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

		// Token: 0x04004BA5 RID: 19365
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x020006A6 RID: 1702
		private static class Uniforms
		{
			// Token: 0x04005113 RID: 20755
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005114 RID: 20756
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005115 RID: 20757
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x04005116 RID: 20758
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x04005117 RID: 20759
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
