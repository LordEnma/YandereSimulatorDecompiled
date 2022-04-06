using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06002331 RID: 9009 RVA: 0x001F7539 File Offset: 0x001F5739
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && RenderSettings.fog && !this.context.interrupted;
			}
		}

		// Token: 0x06002332 RID: 9010 RVA: 0x001F756C File Offset: 0x001F576C
		public override string GetName()
		{
			return "Fog";
		}

		// Token: 0x06002333 RID: 9011 RVA: 0x001F7573 File Offset: 0x001F5773
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x06002334 RID: 9012 RVA: 0x001F7576 File Offset: 0x001F5776
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		// Token: 0x06002335 RID: 9013 RVA: 0x001F757C File Offset: 0x001F577C
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

		// Token: 0x04004BA9 RID: 19369
		private const string k_ShaderString = "Hidden/Post FX/Fog";

		// Token: 0x020006A7 RID: 1703
		private static class Uniforms
		{
			// Token: 0x04005117 RID: 20759
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			// Token: 0x04005118 RID: 20760
			internal static readonly int _Density = Shader.PropertyToID("_Density");

			// Token: 0x04005119 RID: 20761
			internal static readonly int _Start = Shader.PropertyToID("_Start");

			// Token: 0x0400511A RID: 20762
			internal static readonly int _End = Shader.PropertyToID("_End");

			// Token: 0x0400511B RID: 20763
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}
	}
}
