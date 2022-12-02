using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	public sealed class FogComponent : PostProcessingComponentCommandBuffer<FogModel>
	{
		private static class Uniforms
		{
			internal static readonly int _FogColor = Shader.PropertyToID("_FogColor");

			internal static readonly int _Density = Shader.PropertyToID("_Density");

			internal static readonly int _Start = Shader.PropertyToID("_Start");

			internal static readonly int _End = Shader.PropertyToID("_End");

			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");
		}

		private const string k_ShaderString = "Hidden/Post FX/Fog";

		public override bool active
		{
			get
			{
				if (base.model.enabled && context.isGBufferAvailable && RenderSettings.fog)
				{
					return !context.interrupted;
				}
				return false;
			}
		}

		public override string GetName()
		{
			return "Fog";
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterImageEffectsOpaque;
		}

		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			FogModel.Settings settings = base.model.settings;
			Material material = context.materialFactory.Get("Hidden/Post FX/Fog");
			material.shaderKeywords = null;
			Color value = (GraphicsUtils.isLinearColorSpace ? RenderSettings.fogColor.linear : RenderSettings.fogColor);
			material.SetColor(Uniforms._FogColor, value);
			material.SetFloat(Uniforms._Density, RenderSettings.fogDensity);
			material.SetFloat(Uniforms._Start, RenderSettings.fogStartDistance);
			material.SetFloat(Uniforms._End, RenderSettings.fogEndDistance);
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
			RenderTextureFormat format = (context.isHdr ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default);
			cb.GetTemporaryRT(Uniforms._TempRT, context.width, context.height, 24, FilterMode.Bilinear, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, Uniforms._TempRT);
			cb.Blit(Uniforms._TempRT, BuiltinRenderTextureType.CameraTarget, material, settings.excludeSkybox ? 1 : 0);
			cb.ReleaseTemporaryRT(Uniforms._TempRT);
		}
	}
}
