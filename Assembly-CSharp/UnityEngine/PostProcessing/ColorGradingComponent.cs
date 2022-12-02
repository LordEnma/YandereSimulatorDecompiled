namespace UnityEngine.PostProcessing
{
	public sealed class ColorGradingComponent : PostProcessingComponentRenderTexture<ColorGradingModel>
	{
		private static class Uniforms
		{
			internal static readonly int _LutParams = Shader.PropertyToID("_LutParams");

			internal static readonly int _NeutralTonemapperParams1 = Shader.PropertyToID("_NeutralTonemapperParams1");

			internal static readonly int _NeutralTonemapperParams2 = Shader.PropertyToID("_NeutralTonemapperParams2");

			internal static readonly int _HueShift = Shader.PropertyToID("_HueShift");

			internal static readonly int _Saturation = Shader.PropertyToID("_Saturation");

			internal static readonly int _Contrast = Shader.PropertyToID("_Contrast");

			internal static readonly int _Balance = Shader.PropertyToID("_Balance");

			internal static readonly int _Lift = Shader.PropertyToID("_Lift");

			internal static readonly int _InvGamma = Shader.PropertyToID("_InvGamma");

			internal static readonly int _Gain = Shader.PropertyToID("_Gain");

			internal static readonly int _Slope = Shader.PropertyToID("_Slope");

			internal static readonly int _Power = Shader.PropertyToID("_Power");

			internal static readonly int _Offset = Shader.PropertyToID("_Offset");

			internal static readonly int _ChannelMixerRed = Shader.PropertyToID("_ChannelMixerRed");

			internal static readonly int _ChannelMixerGreen = Shader.PropertyToID("_ChannelMixerGreen");

			internal static readonly int _ChannelMixerBlue = Shader.PropertyToID("_ChannelMixerBlue");

			internal static readonly int _Curves = Shader.PropertyToID("_Curves");

			internal static readonly int _LogLut = Shader.PropertyToID("_LogLut");

			internal static readonly int _LogLut_Params = Shader.PropertyToID("_LogLut_Params");

			internal static readonly int _ExposureEV = Shader.PropertyToID("_ExposureEV");
		}

		private const int k_InternalLogLutSize = 32;

		private const int k_CurvePrecision = 128;

		private const float k_CurveStep = 1f / 128f;

		private Texture2D m_GradingCurves;

		private Color[] m_pixels = new Color[256];

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

		private float StandardIlluminantY(float x)
		{
			return 2.87f * x - 3f * x * x - 0.27509508f;
		}

		private Vector3 CIExyToLMS(float x, float y)
		{
			float num = 1f;
			float num2 = num * x / y;
			float num3 = num * (1f - x - y) / y;
			float x2 = 0.7328f * num2 + 0.4296f * num - 0.1624f * num3;
			float y2 = -0.7036f * num2 + 1.6975f * num + 0.0061f * num3;
			float z = 0.003f * num2 + 0.0136f * num + 0.9834f * num3;
			return new Vector3(x2, y2, z);
		}

		private Vector3 CalculateColorBalance(float temperature, float tint)
		{
			float num = temperature / 55f;
			float num2 = tint / 55f;
			float x = 0.31271f - num * ((num < 0f) ? 0.1f : 0.05f);
			float y = StandardIlluminantY(x) + num2 * 0.05f;
			Vector3 vector = new Vector3(0.949237f, 1.03542f, 1.08728f);
			Vector3 vector2 = CIExyToLMS(x, y);
			return new Vector3(vector.x / vector2.x, vector.y / vector2.y, vector.z / vector2.z);
		}

		private static Color NormalizeColor(Color c)
		{
			float num = (c.r + c.g + c.b) / 3f;
			if (Mathf.Approximately(num, 0f))
			{
				return new Color(1f, 1f, 1f, c.a);
			}
			Color result = default(Color);
			result.r = c.r / num;
			result.g = c.g / num;
			result.b = c.b / num;
			result.a = c.a;
			return result;
		}

		private static Vector3 ClampVector(Vector3 v, float min, float max)
		{
			return new Vector3(Mathf.Clamp(v.x, min, max), Mathf.Clamp(v.y, min, max), Mathf.Clamp(v.z, min, max));
		}

		public static Vector3 GetLiftValue(Color lift)
		{
			Color color = NormalizeColor(lift);
			float num = (color.r + color.g + color.b) / 3f;
			float x = (color.r - num) * 0.1f + lift.a;
			float y = (color.g - num) * 0.1f + lift.a;
			float z = (color.b - num) * 0.1f + lift.a;
			return ClampVector(new Vector3(x, y, z), -1f, 1f);
		}

		public static Vector3 GetGammaValue(Color gamma)
		{
			Color color = NormalizeColor(gamma);
			float num = (color.r + color.g + color.b) / 3f;
			gamma.a *= ((gamma.a < 0f) ? 0.8f : 5f);
			float b = Mathf.Pow(2f, (color.r - num) * 0.5f) + gamma.a;
			float b2 = Mathf.Pow(2f, (color.g - num) * 0.5f) + gamma.a;
			float b3 = Mathf.Pow(2f, (color.b - num) * 0.5f) + gamma.a;
			float x = 1f / Mathf.Max(0.01f, b);
			float y = 1f / Mathf.Max(0.01f, b2);
			float z = 1f / Mathf.Max(0.01f, b3);
			return ClampVector(new Vector3(x, y, z), 0f, 5f);
		}

		public static Vector3 GetGainValue(Color gain)
		{
			Color color = NormalizeColor(gain);
			float num = (color.r + color.g + color.b) / 3f;
			gain.a *= ((gain.a > 0f) ? 3f : 1f);
			float x = Mathf.Pow(2f, (color.r - num) * 0.5f) + gain.a;
			float y = Mathf.Pow(2f, (color.g - num) * 0.5f) + gain.a;
			float z = Mathf.Pow(2f, (color.b - num) * 0.5f) + gain.a;
			return ClampVector(new Vector3(x, y, z), 0f, 4f);
		}

		public static void CalculateLiftGammaGain(Color lift, Color gamma, Color gain, out Vector3 outLift, out Vector3 outGamma, out Vector3 outGain)
		{
			outLift = GetLiftValue(lift);
			outGamma = GetGammaValue(gamma);
			outGain = GetGainValue(gain);
		}

		public static Vector3 GetSlopeValue(Color slope)
		{
			Color color = NormalizeColor(slope);
			float num = (color.r + color.g + color.b) / 3f;
			slope.a *= 0.5f;
			float x = (color.r - num) * 0.1f + slope.a + 1f;
			float y = (color.g - num) * 0.1f + slope.a + 1f;
			float z = (color.b - num) * 0.1f + slope.a + 1f;
			return ClampVector(new Vector3(x, y, z), 0f, 2f);
		}

		public static Vector3 GetPowerValue(Color power)
		{
			Color color = NormalizeColor(power);
			float num = (color.r + color.g + color.b) / 3f;
			power.a *= 0.5f;
			float b = (color.r - num) * 0.1f + power.a + 1f;
			float b2 = (color.g - num) * 0.1f + power.a + 1f;
			float b3 = (color.b - num) * 0.1f + power.a + 1f;
			float x = 1f / Mathf.Max(0.01f, b);
			float y = 1f / Mathf.Max(0.01f, b2);
			float z = 1f / Mathf.Max(0.01f, b3);
			return ClampVector(new Vector3(x, y, z), 0.5f, 2.5f);
		}

		public static Vector3 GetOffsetValue(Color offset)
		{
			Color color = NormalizeColor(offset);
			float num = (color.r + color.g + color.b) / 3f;
			offset.a *= 0.5f;
			float x = (color.r - num) * 0.05f + offset.a;
			float y = (color.g - num) * 0.05f + offset.a;
			float z = (color.b - num) * 0.05f + offset.a;
			return ClampVector(new Vector3(x, y, z), -0.8f, 0.8f);
		}

		public static void CalculateSlopePowerOffset(Color slope, Color power, Color offset, out Vector3 outSlope, out Vector3 outPower, out Vector3 outOffset)
		{
			outSlope = GetSlopeValue(slope);
			outPower = GetPowerValue(power);
			outOffset = GetOffsetValue(offset);
		}

		private TextureFormat GetCurveFormat()
		{
			if (SystemInfo.SupportsTextureFormat(TextureFormat.RGBAHalf))
			{
				return TextureFormat.RGBAHalf;
			}
			return TextureFormat.RGBA32;
		}

		private Texture2D GetCurveTexture()
		{
			if (m_GradingCurves == null)
			{
				m_GradingCurves = new Texture2D(128, 2, GetCurveFormat(), false, true)
				{
					name = "Internal Curves Texture",
					hideFlags = HideFlags.DontSave,
					anisoLevel = 0,
					wrapMode = TextureWrapMode.Clamp,
					filterMode = FilterMode.Bilinear
				};
			}
			ColorGradingModel.CurvesSettings curves = base.model.settings.curves;
			curves.hueVShue.Cache();
			curves.hueVSsat.Cache();
			for (int i = 0; i < 128; i++)
			{
				float t = (float)i * (1f / 128f);
				float r = curves.hueVShue.Evaluate(t);
				float g = curves.hueVSsat.Evaluate(t);
				float b = curves.satVSsat.Evaluate(t);
				float a = curves.lumVSsat.Evaluate(t);
				m_pixels[i] = new Color(r, g, b, a);
				float a2 = curves.master.Evaluate(t);
				float r2 = curves.red.Evaluate(t);
				float g2 = curves.green.Evaluate(t);
				float b2 = curves.blue.Evaluate(t);
				m_pixels[i + 128] = new Color(r2, g2, b2, a2);
			}
			m_GradingCurves.SetPixels(m_pixels);
			m_GradingCurves.Apply(false, false);
			return m_GradingCurves;
		}

		private bool IsLogLutValid(RenderTexture lut)
		{
			if (lut != null && lut.IsCreated())
			{
				return lut.height == 32;
			}
			return false;
		}

		private RenderTextureFormat GetLutFormat()
		{
			if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf))
			{
				return RenderTextureFormat.ARGBHalf;
			}
			return RenderTextureFormat.ARGB32;
		}

		private void GenerateLut()
		{
			ColorGradingModel.Settings settings = base.model.settings;
			if (!IsLogLutValid(base.model.bakedLut))
			{
				GraphicsUtils.Destroy(base.model.bakedLut);
				base.model.bakedLut = new RenderTexture(1024, 32, 0, GetLutFormat())
				{
					name = "Color Grading Log LUT",
					hideFlags = HideFlags.DontSave,
					filterMode = FilterMode.Bilinear,
					wrapMode = TextureWrapMode.Clamp,
					anisoLevel = 0
				};
			}
			Material material = context.materialFactory.Get("Hidden/Post FX/Lut Generator");
			material.SetVector(Uniforms._LutParams, new Vector4(32f, 0.00048828125f, 1f / 64f, 1.032258f));
			material.shaderKeywords = null;
			ColorGradingModel.TonemappingSettings tonemapping = settings.tonemapping;
			switch (tonemapping.tonemapper)
			{
			case ColorGradingModel.Tonemapper.Neutral:
			{
				material.EnableKeyword("TONEMAPPING_NEUTRAL");
				float num = tonemapping.neutralBlackIn * 20f + 1f;
				float num2 = tonemapping.neutralBlackOut * 10f + 1f;
				float num3 = tonemapping.neutralWhiteIn / 20f;
				float num4 = 1f - tonemapping.neutralWhiteOut / 20f;
				float t = num / num2;
				float t2 = num3 / num4;
				float y = Mathf.Max(0f, Mathf.LerpUnclamped(0.57f, 0.37f, t));
				float z = Mathf.LerpUnclamped(0.01f, 0.24f, t2);
				float w = Mathf.Max(0f, Mathf.LerpUnclamped(0.02f, 0.2f, t));
				material.SetVector(Uniforms._NeutralTonemapperParams1, new Vector4(0.2f, y, z, w));
				material.SetVector(Uniforms._NeutralTonemapperParams2, new Vector4(0.02f, 0.3f, tonemapping.neutralWhiteLevel, tonemapping.neutralWhiteClip / 10f));
				break;
			}
			case ColorGradingModel.Tonemapper.ACES:
				material.EnableKeyword("TONEMAPPING_FILMIC");
				break;
			}
			material.SetFloat(Uniforms._HueShift, settings.basic.hueShift / 360f);
			material.SetFloat(Uniforms._Saturation, settings.basic.saturation);
			material.SetFloat(Uniforms._Contrast, settings.basic.contrast);
			material.SetVector(Uniforms._Balance, CalculateColorBalance(settings.basic.temperature, settings.basic.tint));
			Vector3 outLift;
			Vector3 outGamma;
			Vector3 outGain;
			CalculateLiftGammaGain(settings.colorWheels.linear.lift, settings.colorWheels.linear.gamma, settings.colorWheels.linear.gain, out outLift, out outGamma, out outGain);
			material.SetVector(Uniforms._Lift, outLift);
			material.SetVector(Uniforms._InvGamma, outGamma);
			material.SetVector(Uniforms._Gain, outGain);
			Vector3 outSlope;
			Vector3 outPower;
			Vector3 outOffset;
			CalculateSlopePowerOffset(settings.colorWheels.log.slope, settings.colorWheels.log.power, settings.colorWheels.log.offset, out outSlope, out outPower, out outOffset);
			material.SetVector(Uniforms._Slope, outSlope);
			material.SetVector(Uniforms._Power, outPower);
			material.SetVector(Uniforms._Offset, outOffset);
			material.SetVector(Uniforms._ChannelMixerRed, settings.channelMixer.red);
			material.SetVector(Uniforms._ChannelMixerGreen, settings.channelMixer.green);
			material.SetVector(Uniforms._ChannelMixerBlue, settings.channelMixer.blue);
			material.SetTexture(Uniforms._Curves, GetCurveTexture());
			Graphics.Blit(null, base.model.bakedLut, material, 0);
		}

		public override void Prepare(Material uberMaterial)
		{
			if (base.model.isDirty || !IsLogLutValid(base.model.bakedLut))
			{
				GenerateLut();
				base.model.isDirty = false;
			}
			uberMaterial.EnableKeyword(context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) ? "COLOR_GRADING_LOG_VIEW" : "COLOR_GRADING");
			RenderTexture bakedLut = base.model.bakedLut;
			uberMaterial.SetTexture(Uniforms._LogLut, bakedLut);
			uberMaterial.SetVector(Uniforms._LogLut_Params, new Vector3(1f / (float)bakedLut.width, 1f / (float)bakedLut.height, (float)bakedLut.height - 1f));
			float value = Mathf.Exp(base.model.settings.basic.postExposure * 0.6931472f);
			uberMaterial.SetFloat(Uniforms._ExposureEV, value);
		}

		public void OnGUI()
		{
			RenderTexture bakedLut = base.model.bakedLut;
			GUI.DrawTexture(new Rect(context.viewport.x * (float)Screen.width + 8f, 8f, bakedLut.width, bakedLut.height), bakedLut);
		}

		public override void OnDisable()
		{
			GraphicsUtils.Destroy(m_GradingCurves);
			GraphicsUtils.Destroy(base.model.bakedLut);
			m_GradingCurves = null;
			base.model.bakedLut = null;
		}
	}
}
