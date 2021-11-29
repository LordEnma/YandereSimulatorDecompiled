using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054C RID: 1356
	public sealed class AmbientOcclusionComponent : PostProcessingComponentCommandBuffer<AmbientOcclusionModel>
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600227A RID: 8826 RVA: 0x001EB5D4 File Offset: 0x001E97D4
		private AmbientOcclusionComponent.OcclusionSource occlusionSource
		{
			get
			{
				if (this.context.isGBufferAvailable && !base.model.settings.forceForwardCompatibility)
				{
					return AmbientOcclusionComponent.OcclusionSource.GBuffer;
				}
				if (base.model.settings.highPrecision && (!this.context.isGBufferAvailable || base.model.settings.forceForwardCompatibility))
				{
					return AmbientOcclusionComponent.OcclusionSource.DepthTexture;
				}
				return AmbientOcclusionComponent.OcclusionSource.DepthNormalsTexture;
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600227B RID: 8827 RVA: 0x001EB638 File Offset: 0x001E9838
		private bool ambientOnlySupported
		{
			get
			{
				return this.context.isHdr && base.model.settings.ambientOnly && this.context.isGBufferAvailable && !base.model.settings.forceForwardCompatibility;
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x0600227C RID: 8828 RVA: 0x001EB686 File Offset: 0x001E9886
		public override bool active
		{
			get
			{
				return base.model.enabled && base.model.settings.intensity > 0f && !this.context.interrupted;
			}
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001EB6BC File Offset: 0x001E98BC
		public override DepthTextureMode GetCameraFlags()
		{
			DepthTextureMode depthTextureMode = DepthTextureMode.None;
			if (this.occlusionSource == AmbientOcclusionComponent.OcclusionSource.DepthTexture)
			{
				depthTextureMode |= DepthTextureMode.Depth;
			}
			if (this.occlusionSource != AmbientOcclusionComponent.OcclusionSource.GBuffer)
			{
				depthTextureMode |= DepthTextureMode.DepthNormals;
			}
			return depthTextureMode;
		}

		// Token: 0x0600227E RID: 8830 RVA: 0x001EB6E5 File Offset: 0x001E98E5
		public override string GetName()
		{
			return "Ambient Occlusion";
		}

		// Token: 0x0600227F RID: 8831 RVA: 0x001EB6EC File Offset: 0x001E98EC
		public override CameraEvent GetCameraEvent()
		{
			if (!this.ambientOnlySupported || this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.AmbientOcclusion))
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeReflections;
		}

		// Token: 0x06002280 RID: 8832 RVA: 0x001EB714 File Offset: 0x001E9914
		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			AmbientOcclusionModel.Settings settings = base.model.settings;
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Blit");
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Ambient Occlusion");
			material.shaderKeywords = null;
			material.SetFloat(AmbientOcclusionComponent.Uniforms._Intensity, settings.intensity);
			material.SetFloat(AmbientOcclusionComponent.Uniforms._Radius, settings.radius);
			material.SetFloat(AmbientOcclusionComponent.Uniforms._Downsample, settings.downsampling ? 0.5f : 1f);
			material.SetInt(AmbientOcclusionComponent.Uniforms._SampleCount, (int)settings.sampleCount);
			if (!this.context.isGBufferAvailable && RenderSettings.fog)
			{
				material.SetVector(AmbientOcclusionComponent.Uniforms._FogParams, new Vector3(RenderSettings.fogDensity, RenderSettings.fogStartDistance, RenderSettings.fogEndDistance));
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
			}
			else
			{
				material.EnableKeyword("FOG_OFF");
			}
			int width = this.context.width;
			int height = this.context.height;
			int num = settings.downsampling ? 2 : 1;
			int nameID = AmbientOcclusionComponent.Uniforms._OcclusionTexture1;
			cb.GetTemporaryRT(nameID, width / num, height / num, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			cb.Blit(null, nameID, material, (int)this.occlusionSource);
			int occlusionTexture = AmbientOcclusionComponent.Uniforms._OcclusionTexture2;
			cb.GetTemporaryRT(occlusionTexture, width, height, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, nameID);
			cb.Blit(nameID, occlusionTexture, material, (this.occlusionSource == AmbientOcclusionComponent.OcclusionSource.GBuffer) ? 4 : 3);
			cb.ReleaseTemporaryRT(nameID);
			nameID = AmbientOcclusionComponent.Uniforms._OcclusionTexture;
			cb.GetTemporaryRT(nameID, width, height, 0, FilterMode.Bilinear, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, occlusionTexture);
			cb.Blit(occlusionTexture, nameID, material, 5);
			cb.ReleaseTemporaryRT(occlusionTexture);
			if (this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.AmbientOcclusion))
			{
				cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, nameID);
				cb.Blit(nameID, BuiltinRenderTextureType.CameraTarget, material, 8);
				this.context.Interrupt();
			}
			else if (this.ambientOnlySupported)
			{
				cb.SetRenderTarget(this.m_MRT, BuiltinRenderTextureType.CameraTarget);
				cb.DrawMesh(GraphicsUtils.quad, Matrix4x4.identity, material, 0, 7);
			}
			else
			{
				RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default;
				int tempRT = AmbientOcclusionComponent.Uniforms._TempRT;
				cb.GetTemporaryRT(tempRT, this.context.width, this.context.height, 0, FilterMode.Bilinear, format);
				cb.Blit(BuiltinRenderTextureType.CameraTarget, tempRT, mat, 0);
				cb.SetGlobalTexture(AmbientOcclusionComponent.Uniforms._MainTex, tempRT);
				cb.Blit(tempRT, BuiltinRenderTextureType.CameraTarget, material, 6);
				cb.ReleaseTemporaryRT(tempRT);
			}
			cb.ReleaseTemporaryRT(nameID);
		}

		// Token: 0x04004A48 RID: 19016
		private const string k_BlitShaderString = "Hidden/Post FX/Blit";

		// Token: 0x04004A49 RID: 19017
		private const string k_ShaderString = "Hidden/Post FX/Ambient Occlusion";

		// Token: 0x04004A4A RID: 19018
		private readonly RenderTargetIdentifier[] m_MRT = new RenderTargetIdentifier[]
		{
			BuiltinRenderTextureType.GBuffer0,
			BuiltinRenderTextureType.CameraTarget
		};

		// Token: 0x0200068D RID: 1677
		private static class Uniforms
		{
			// Token: 0x04004FA1 RID: 20385
			internal static readonly int _Intensity = Shader.PropertyToID("_Intensity");

			// Token: 0x04004FA2 RID: 20386
			internal static readonly int _Radius = Shader.PropertyToID("_Radius");

			// Token: 0x04004FA3 RID: 20387
			internal static readonly int _FogParams = Shader.PropertyToID("_FogParams");

			// Token: 0x04004FA4 RID: 20388
			internal static readonly int _Downsample = Shader.PropertyToID("_Downsample");

			// Token: 0x04004FA5 RID: 20389
			internal static readonly int _SampleCount = Shader.PropertyToID("_SampleCount");

			// Token: 0x04004FA6 RID: 20390
			internal static readonly int _OcclusionTexture1 = Shader.PropertyToID("_OcclusionTexture1");

			// Token: 0x04004FA7 RID: 20391
			internal static readonly int _OcclusionTexture2 = Shader.PropertyToID("_OcclusionTexture2");

			// Token: 0x04004FA8 RID: 20392
			internal static readonly int _OcclusionTexture = Shader.PropertyToID("_OcclusionTexture");

			// Token: 0x04004FA9 RID: 20393
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04004FAA RID: 20394
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}

		// Token: 0x0200068E RID: 1678
		private enum OcclusionSource
		{
			// Token: 0x04004FAC RID: 20396
			DepthTexture,
			// Token: 0x04004FAD RID: 20397
			DepthNormalsTexture,
			// Token: 0x04004FAE RID: 20398
			GBuffer
		}
	}
}
