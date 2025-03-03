using System;

namespace UnityEngine.PostProcessing
{
	public sealed class DepthOfFieldComponent : PostProcessingComponentRenderTexture<DepthOfFieldModel>
	{
		private static class Uniforms
		{
			internal static readonly int _DepthOfFieldTex = Shader.PropertyToID("_DepthOfFieldTex");

			internal static readonly int _DepthOfFieldCoCTex = Shader.PropertyToID("_DepthOfFieldCoCTex");

			internal static readonly int _Distance = Shader.PropertyToID("_Distance");

			internal static readonly int _LensCoeff = Shader.PropertyToID("_LensCoeff");

			internal static readonly int _MaxCoC = Shader.PropertyToID("_MaxCoC");

			internal static readonly int _RcpMaxCoC = Shader.PropertyToID("_RcpMaxCoC");

			internal static readonly int _RcpAspect = Shader.PropertyToID("_RcpAspect");

			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			internal static readonly int _CoCTex = Shader.PropertyToID("_CoCTex");

			internal static readonly int _TaaParams = Shader.PropertyToID("_TaaParams");

			internal static readonly int _DepthOfFieldParams = Shader.PropertyToID("_DepthOfFieldParams");
		}

		private const string k_ShaderString = "Hidden/Post FX/Depth Of Field";

		private RenderTexture m_CoCHistory;

		private const float k_FilmHeight = 0.024f;

		public override bool active
		{
			get
			{
				if (base.model.enabled)
				{
					return !context.interrupted;
				}
				return false;
			}
		}

		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		private float CalculateFocalLength()
		{
			DepthOfFieldModel.Settings settings = base.model.settings;
			if (!settings.useCameraFov)
			{
				return settings.focalLength / 1000f;
			}
			float num = context.camera.fieldOfView * (MathF.PI / 180f);
			return 0.012f / Mathf.Tan(0.5f * num);
		}

		private float CalculateMaxCoCRadius(int screenHeight)
		{
			float num = (float)base.model.settings.kernelSize * 4f + 6f;
			return Mathf.Min(0.05f, num / (float)screenHeight);
		}

		private bool CheckHistory(int width, int height)
		{
			if (m_CoCHistory != null && m_CoCHistory.IsCreated() && m_CoCHistory.width == width)
			{
				return m_CoCHistory.height == height;
			}
			return false;
		}

		private RenderTextureFormat SelectFormat(RenderTextureFormat primary, RenderTextureFormat secondary)
		{
			if (SystemInfo.SupportsRenderTextureFormat(primary))
			{
				return primary;
			}
			if (SystemInfo.SupportsRenderTextureFormat(secondary))
			{
				return secondary;
			}
			return RenderTextureFormat.Default;
		}

		public void Prepare(RenderTexture source, Material uberMaterial, bool antialiasCoC, Vector2 taaJitter, float taaBlending)
		{
			DepthOfFieldModel.Settings settings = base.model.settings;
			RenderTextureFormat format = RenderTextureFormat.DefaultHDR;
			RenderTextureFormat format2 = SelectFormat(RenderTextureFormat.R8, RenderTextureFormat.RHalf);
			float num = CalculateFocalLength();
			float num2 = Mathf.Max(settings.focusDistance, num);
			float num3 = (float)source.width / (float)source.height;
			float num4 = num * num / (settings.aperture * (num2 - num) * 0.024f * 2f);
			float num5 = CalculateMaxCoCRadius(source.height);
			Material material = context.materialFactory.Get("Hidden/Post FX/Depth Of Field");
			material.SetFloat(Uniforms._Distance, num2);
			material.SetFloat(Uniforms._LensCoeff, num4);
			material.SetFloat(Uniforms._MaxCoC, num5);
			material.SetFloat(Uniforms._RcpMaxCoC, 1f / num5);
			material.SetFloat(Uniforms._RcpAspect, 1f / num3);
			RenderTexture renderTexture = context.renderTextureFactory.Get(context.width, context.height, 0, format2, RenderTextureReadWrite.Linear);
			Graphics.Blit(null, renderTexture, material, 0);
			if (antialiasCoC)
			{
				material.SetTexture(Uniforms._CoCTex, renderTexture);
				float z = (CheckHistory(context.width, context.height) ? taaBlending : 0f);
				material.SetVector(Uniforms._TaaParams, new Vector3(taaJitter.x, taaJitter.y, z));
				RenderTexture temporary = RenderTexture.GetTemporary(context.width, context.height, 0, format2);
				Graphics.Blit(m_CoCHistory, temporary, material, 1);
				context.renderTextureFactory.Release(renderTexture);
				if (m_CoCHistory != null)
				{
					RenderTexture.ReleaseTemporary(m_CoCHistory);
				}
				renderTexture = (m_CoCHistory = temporary);
			}
			RenderTexture renderTexture2 = context.renderTextureFactory.Get(context.width / 2, context.height / 2, 0, format);
			material.SetTexture(Uniforms._CoCTex, renderTexture);
			Graphics.Blit(source, renderTexture2, material, 2);
			RenderTexture renderTexture3 = context.renderTextureFactory.Get(context.width / 2, context.height / 2, 0, format);
			Graphics.Blit(renderTexture2, renderTexture3, material, (int)(3 + settings.kernelSize));
			Graphics.Blit(renderTexture3, renderTexture2, material, 7);
			uberMaterial.SetVector(Uniforms._DepthOfFieldParams, new Vector3(num2, num4, num5));
			if (context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.FocusPlane))
			{
				uberMaterial.EnableKeyword("DEPTH_OF_FIELD_COC_VIEW");
				context.Interrupt();
			}
			else
			{
				uberMaterial.SetTexture(Uniforms._DepthOfFieldTex, renderTexture2);
				uberMaterial.SetTexture(Uniforms._DepthOfFieldCoCTex, renderTexture);
				uberMaterial.EnableKeyword("DEPTH_OF_FIELD");
			}
			context.renderTextureFactory.Release(renderTexture3);
		}

		public override void OnDisable()
		{
			if (m_CoCHistory != null)
			{
				RenderTexture.ReleaseTemporary(m_CoCHistory);
			}
			m_CoCHistory = null;
		}
	}
}
