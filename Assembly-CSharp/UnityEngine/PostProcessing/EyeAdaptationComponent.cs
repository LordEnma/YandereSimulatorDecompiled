namespace UnityEngine.PostProcessing
{
	public sealed class EyeAdaptationComponent : PostProcessingComponentRenderTexture<EyeAdaptationModel>
	{
		private static class Uniforms
		{
			internal static readonly int _Params = Shader.PropertyToID("_Params");

			internal static readonly int _Speed = Shader.PropertyToID("_Speed");

			internal static readonly int _ScaleOffsetRes = Shader.PropertyToID("_ScaleOffsetRes");

			internal static readonly int _ExposureCompensation = Shader.PropertyToID("_ExposureCompensation");

			internal static readonly int _AutoExposure = Shader.PropertyToID("_AutoExposure");

			internal static readonly int _DebugWidth = Shader.PropertyToID("_DebugWidth");
		}

		private ComputeShader m_EyeCompute;

		private ComputeBuffer m_HistogramBuffer;

		private readonly RenderTexture[] m_AutoExposurePool = new RenderTexture[2];

		private int m_AutoExposurePingPing;

		private RenderTexture m_CurrentAutoExposure;

		private RenderTexture m_DebugHistogram;

		private static uint[] s_EmptyHistogramBuffer;

		private bool m_FirstFrame = true;

		private const int k_HistogramBins = 64;

		private const int k_HistogramThreadX = 16;

		private const int k_HistogramThreadY = 16;

		public override bool active
		{
			get
			{
				if (base.model.enabled && SystemInfo.supportsComputeShaders)
				{
					return !context.interrupted;
				}
				return false;
			}
		}

		public void ResetHistory()
		{
			m_FirstFrame = true;
		}

		public override void OnEnable()
		{
			m_FirstFrame = true;
		}

		public override void OnDisable()
		{
			RenderTexture[] autoExposurePool = m_AutoExposurePool;
			for (int i = 0; i < autoExposurePool.Length; i++)
			{
				GraphicsUtils.Destroy(autoExposurePool[i]);
			}
			if (m_HistogramBuffer != null)
			{
				m_HistogramBuffer.Release();
			}
			m_HistogramBuffer = null;
			if (m_DebugHistogram != null)
			{
				m_DebugHistogram.Release();
			}
			m_DebugHistogram = null;
		}

		private Vector4 GetHistogramScaleOffsetRes()
		{
			EyeAdaptationModel.Settings settings = base.model.settings;
			float num = settings.logMax - settings.logMin;
			float num2 = 1f / num;
			float y = (float)(-settings.logMin) * num2;
			return new Vector4(num2, y, Mathf.Floor((float)context.width / 2f), Mathf.Floor((float)context.height / 2f));
		}

		public Texture Prepare(RenderTexture source, Material uberMaterial)
		{
			EyeAdaptationModel.Settings settings = base.model.settings;
			if (m_EyeCompute == null)
			{
				m_EyeCompute = Resources.Load<ComputeShader>("Shaders/EyeHistogram");
			}
			Material material = context.materialFactory.Get("Hidden/Post FX/Eye Adaptation");
			material.shaderKeywords = null;
			if (m_HistogramBuffer == null)
			{
				m_HistogramBuffer = new ComputeBuffer(64, 4);
			}
			if (s_EmptyHistogramBuffer == null)
			{
				s_EmptyHistogramBuffer = new uint[64];
			}
			Vector4 histogramScaleOffsetRes = GetHistogramScaleOffsetRes();
			RenderTexture renderTexture = context.renderTextureFactory.Get((int)histogramScaleOffsetRes.z, (int)histogramScaleOffsetRes.w, 0, source.format);
			Graphics.Blit(source, renderTexture);
			if (m_AutoExposurePool[0] == null || !m_AutoExposurePool[0].IsCreated())
			{
				m_AutoExposurePool[0] = new RenderTexture(1, 1, 0, RenderTextureFormat.RFloat);
			}
			if (m_AutoExposurePool[1] == null || !m_AutoExposurePool[1].IsCreated())
			{
				m_AutoExposurePool[1] = new RenderTexture(1, 1, 0, RenderTextureFormat.RFloat);
			}
			m_HistogramBuffer.SetData(s_EmptyHistogramBuffer);
			int kernelIndex = m_EyeCompute.FindKernel("KEyeHistogram");
			m_EyeCompute.SetBuffer(kernelIndex, "_Histogram", m_HistogramBuffer);
			m_EyeCompute.SetTexture(kernelIndex, "_Source", renderTexture);
			m_EyeCompute.SetVector("_ScaleOffsetRes", histogramScaleOffsetRes);
			m_EyeCompute.Dispatch(kernelIndex, Mathf.CeilToInt((float)renderTexture.width / 16f), Mathf.CeilToInt((float)renderTexture.height / 16f), 1);
			context.renderTextureFactory.Release(renderTexture);
			settings.highPercent = Mathf.Clamp(settings.highPercent, 1.01f, 99f);
			settings.lowPercent = Mathf.Clamp(settings.lowPercent, 1f, settings.highPercent - 0.01f);
			material.SetBuffer("_Histogram", m_HistogramBuffer);
			material.SetVector(Uniforms._Params, new Vector4(settings.lowPercent * 0.01f, settings.highPercent * 0.01f, Mathf.Exp(settings.minLuminance * 0.6931472f), Mathf.Exp(settings.maxLuminance * 0.6931472f)));
			material.SetVector(Uniforms._Speed, new Vector2(settings.speedDown, settings.speedUp));
			material.SetVector(Uniforms._ScaleOffsetRes, histogramScaleOffsetRes);
			material.SetFloat(Uniforms._ExposureCompensation, settings.keyValue);
			if (settings.dynamicKeyValue)
			{
				material.EnableKeyword("AUTO_KEY_VALUE");
			}
			if (m_FirstFrame || !Application.isPlaying)
			{
				m_CurrentAutoExposure = m_AutoExposurePool[0];
				Graphics.Blit(null, m_CurrentAutoExposure, material, 1);
				Graphics.Blit(m_AutoExposurePool[0], m_AutoExposurePool[1]);
			}
			else
			{
				int autoExposurePingPing = m_AutoExposurePingPing;
				RenderTexture source2 = m_AutoExposurePool[++autoExposurePingPing % 2];
				RenderTexture renderTexture2 = m_AutoExposurePool[++autoExposurePingPing % 2];
				Graphics.Blit(source2, renderTexture2, material, (int)settings.adaptationType);
				m_AutoExposurePingPing = ++autoExposurePingPing % 2;
				m_CurrentAutoExposure = renderTexture2;
			}
			if (context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation))
			{
				if (m_DebugHistogram == null || !m_DebugHistogram.IsCreated())
				{
					m_DebugHistogram = new RenderTexture(256, 128, 0, RenderTextureFormat.ARGB32)
					{
						filterMode = FilterMode.Point,
						wrapMode = TextureWrapMode.Clamp
					};
				}
				material.SetFloat(Uniforms._DebugWidth, m_DebugHistogram.width);
				Graphics.Blit(null, m_DebugHistogram, material, 2);
			}
			m_FirstFrame = false;
			return m_CurrentAutoExposure;
		}

		public void OnGUI()
		{
			if (!(m_DebugHistogram == null) && m_DebugHistogram.IsCreated())
			{
				GUI.DrawTexture(new Rect(context.viewport.x * (float)Screen.width + 8f, 8f, m_DebugHistogram.width, m_DebugHistogram.height), m_DebugHistogram);
			}
		}
	}
}
