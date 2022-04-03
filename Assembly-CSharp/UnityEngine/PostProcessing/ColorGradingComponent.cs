using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000561 RID: 1377
	public sealed class ColorGradingComponent : PostProcessingComponentRenderTexture<ColorGradingModel>
	{
		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060022FC RID: 8956 RVA: 0x001F5794 File Offset: 0x001F3994
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x001F57B3 File Offset: 0x001F39B3
		private float StandardIlluminantY(float x)
		{
			return 2.87f * x - 3f * x * x - 0.27509508f;
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x001F57CC File Offset: 0x001F39CC
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

		// Token: 0x060022FF RID: 8959 RVA: 0x001F5844 File Offset: 0x001F3A44
		private Vector3 CalculateColorBalance(float temperature, float tint)
		{
			float num = temperature / 55f;
			float num2 = tint / 55f;
			float x = 0.31271f - num * ((num < 0f) ? 0.1f : 0.05f);
			float y = this.StandardIlluminantY(x) + num2 * 0.05f;
			Vector3 vector = new Vector3(0.949237f, 1.03542f, 1.08728f);
			Vector3 vector2 = this.CIExyToLMS(x, y);
			return new Vector3(vector.x / vector2.x, vector.y / vector2.y, vector.z / vector2.z);
		}

		// Token: 0x06002300 RID: 8960 RVA: 0x001F58E0 File Offset: 0x001F3AE0
		private static Color NormalizeColor(Color c)
		{
			float num = (c.r + c.g + c.b) / 3f;
			if (Mathf.Approximately(num, 0f))
			{
				return new Color(1f, 1f, 1f, c.a);
			}
			return new Color
			{
				r = c.r / num,
				g = c.g / num,
				b = c.b / num,
				a = c.a
			};
		}

		// Token: 0x06002301 RID: 8961 RVA: 0x001F5973 File Offset: 0x001F3B73
		private static Vector3 ClampVector(Vector3 v, float min, float max)
		{
			return new Vector3(Mathf.Clamp(v.x, min, max), Mathf.Clamp(v.y, min, max), Mathf.Clamp(v.z, min, max));
		}

		// Token: 0x06002302 RID: 8962 RVA: 0x001F59A4 File Offset: 0x001F3BA4
		public static Vector3 GetLiftValue(Color lift)
		{
			Color color = ColorGradingComponent.NormalizeColor(lift);
			float num = (color.r + color.g + color.b) / 3f;
			float x = (color.r - num) * 0.1f + lift.a;
			float y = (color.g - num) * 0.1f + lift.a;
			float z = (color.b - num) * 0.1f + lift.a;
			return ColorGradingComponent.ClampVector(new Vector3(x, y, z), -1f, 1f);
		}

		// Token: 0x06002303 RID: 8963 RVA: 0x001F5A2C File Offset: 0x001F3C2C
		public static Vector3 GetGammaValue(Color gamma)
		{
			Color color = ColorGradingComponent.NormalizeColor(gamma);
			float num = (color.r + color.g + color.b) / 3f;
			gamma.a *= ((gamma.a < 0f) ? 0.8f : 5f);
			float b = Mathf.Pow(2f, (color.r - num) * 0.5f) + gamma.a;
			float b2 = Mathf.Pow(2f, (color.g - num) * 0.5f) + gamma.a;
			float b3 = Mathf.Pow(2f, (color.b - num) * 0.5f) + gamma.a;
			float x = 1f / Mathf.Max(0.01f, b);
			float y = 1f / Mathf.Max(0.01f, b2);
			float z = 1f / Mathf.Max(0.01f, b3);
			return ColorGradingComponent.ClampVector(new Vector3(x, y, z), 0f, 5f);
		}

		// Token: 0x06002304 RID: 8964 RVA: 0x001F5B30 File Offset: 0x001F3D30
		public static Vector3 GetGainValue(Color gain)
		{
			Color color = ColorGradingComponent.NormalizeColor(gain);
			float num = (color.r + color.g + color.b) / 3f;
			gain.a *= ((gain.a > 0f) ? 3f : 1f);
			float x = Mathf.Pow(2f, (color.r - num) * 0.5f) + gain.a;
			float y = Mathf.Pow(2f, (color.g - num) * 0.5f) + gain.a;
			float z = Mathf.Pow(2f, (color.b - num) * 0.5f) + gain.a;
			return ColorGradingComponent.ClampVector(new Vector3(x, y, z), 0f, 4f);
		}

		// Token: 0x06002305 RID: 8965 RVA: 0x001F5BF8 File Offset: 0x001F3DF8
		public static void CalculateLiftGammaGain(Color lift, Color gamma, Color gain, out Vector3 outLift, out Vector3 outGamma, out Vector3 outGain)
		{
			outLift = ColorGradingComponent.GetLiftValue(lift);
			outGamma = ColorGradingComponent.GetGammaValue(gamma);
			outGain = ColorGradingComponent.GetGainValue(gain);
		}

		// Token: 0x06002306 RID: 8966 RVA: 0x001F5C20 File Offset: 0x001F3E20
		public static Vector3 GetSlopeValue(Color slope)
		{
			Color color = ColorGradingComponent.NormalizeColor(slope);
			float num = (color.r + color.g + color.b) / 3f;
			slope.a *= 0.5f;
			float x = (color.r - num) * 0.1f + slope.a + 1f;
			float y = (color.g - num) * 0.1f + slope.a + 1f;
			float z = (color.b - num) * 0.1f + slope.a + 1f;
			return ColorGradingComponent.ClampVector(new Vector3(x, y, z), 0f, 2f);
		}

		// Token: 0x06002307 RID: 8967 RVA: 0x001F5CC8 File Offset: 0x001F3EC8
		public static Vector3 GetPowerValue(Color power)
		{
			Color color = ColorGradingComponent.NormalizeColor(power);
			float num = (color.r + color.g + color.b) / 3f;
			power.a *= 0.5f;
			float b = (color.r - num) * 0.1f + power.a + 1f;
			float b2 = (color.g - num) * 0.1f + power.a + 1f;
			float b3 = (color.b - num) * 0.1f + power.a + 1f;
			float x = 1f / Mathf.Max(0.01f, b);
			float y = 1f / Mathf.Max(0.01f, b2);
			float z = 1f / Mathf.Max(0.01f, b3);
			return ColorGradingComponent.ClampVector(new Vector3(x, y, z), 0.5f, 2.5f);
		}

		// Token: 0x06002308 RID: 8968 RVA: 0x001F5DAC File Offset: 0x001F3FAC
		public static Vector3 GetOffsetValue(Color offset)
		{
			Color color = ColorGradingComponent.NormalizeColor(offset);
			float num = (color.r + color.g + color.b) / 3f;
			offset.a *= 0.5f;
			float x = (color.r - num) * 0.05f + offset.a;
			float y = (color.g - num) * 0.05f + offset.a;
			float z = (color.b - num) * 0.05f + offset.a;
			return ColorGradingComponent.ClampVector(new Vector3(x, y, z), -0.8f, 0.8f);
		}

		// Token: 0x06002309 RID: 8969 RVA: 0x001F5E42 File Offset: 0x001F4042
		public static void CalculateSlopePowerOffset(Color slope, Color power, Color offset, out Vector3 outSlope, out Vector3 outPower, out Vector3 outOffset)
		{
			outSlope = ColorGradingComponent.GetSlopeValue(slope);
			outPower = ColorGradingComponent.GetPowerValue(power);
			outOffset = ColorGradingComponent.GetOffsetValue(offset);
		}

		// Token: 0x0600230A RID: 8970 RVA: 0x001F5E6A File Offset: 0x001F406A
		private TextureFormat GetCurveFormat()
		{
			if (SystemInfo.SupportsTextureFormat(TextureFormat.RGBAHalf))
			{
				return TextureFormat.RGBAHalf;
			}
			return TextureFormat.RGBA32;
		}

		// Token: 0x0600230B RID: 8971 RVA: 0x001F5E7C File Offset: 0x001F407C
		private Texture2D GetCurveTexture()
		{
			if (this.m_GradingCurves == null)
			{
				this.m_GradingCurves = new Texture2D(128, 2, this.GetCurveFormat(), false, true)
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
				float t = (float)i * 0.0078125f;
				float r = curves.hueVShue.Evaluate(t);
				float g = curves.hueVSsat.Evaluate(t);
				float b = curves.satVSsat.Evaluate(t);
				float a = curves.lumVSsat.Evaluate(t);
				this.m_pixels[i] = new Color(r, g, b, a);
				float a2 = curves.master.Evaluate(t);
				float r2 = curves.red.Evaluate(t);
				float g2 = curves.green.Evaluate(t);
				float b2 = curves.blue.Evaluate(t);
				this.m_pixels[i + 128] = new Color(r2, g2, b2, a2);
			}
			this.m_GradingCurves.SetPixels(this.m_pixels);
			this.m_GradingCurves.Apply(false, false);
			return this.m_GradingCurves;
		}

		// Token: 0x0600230C RID: 8972 RVA: 0x001F5FE8 File Offset: 0x001F41E8
		private bool IsLogLutValid(RenderTexture lut)
		{
			return lut != null && lut.IsCreated() && lut.height == 32;
		}

		// Token: 0x0600230D RID: 8973 RVA: 0x001F6007 File Offset: 0x001F4207
		private RenderTextureFormat GetLutFormat()
		{
			if (SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf))
			{
				return RenderTextureFormat.ARGBHalf;
			}
			return RenderTextureFormat.ARGB32;
		}

		// Token: 0x0600230E RID: 8974 RVA: 0x001F6014 File Offset: 0x001F4214
		private void GenerateLut()
		{
			ColorGradingModel.Settings settings = base.model.settings;
			if (!this.IsLogLutValid(base.model.bakedLut))
			{
				GraphicsUtils.Destroy(base.model.bakedLut);
				base.model.bakedLut = new RenderTexture(1024, 32, 0, this.GetLutFormat())
				{
					name = "Color Grading Log LUT",
					hideFlags = HideFlags.DontSave,
					filterMode = FilterMode.Bilinear,
					wrapMode = TextureWrapMode.Clamp,
					anisoLevel = 0
				};
			}
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Lut Generator");
			material.SetVector(ColorGradingComponent.Uniforms._LutParams, new Vector4(32f, 0.00048828125f, 0.015625f, 1.032258f));
			material.shaderKeywords = null;
			ColorGradingModel.TonemappingSettings tonemapping = settings.tonemapping;
			ColorGradingModel.Tonemapper tonemapper = tonemapping.tonemapper;
			if (tonemapper != ColorGradingModel.Tonemapper.ACES)
			{
				if (tonemapper == ColorGradingModel.Tonemapper.Neutral)
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
					material.SetVector(ColorGradingComponent.Uniforms._NeutralTonemapperParams1, new Vector4(0.2f, y, z, w));
					material.SetVector(ColorGradingComponent.Uniforms._NeutralTonemapperParams2, new Vector4(0.02f, 0.3f, tonemapping.neutralWhiteLevel, tonemapping.neutralWhiteClip / 10f));
				}
			}
			else
			{
				material.EnableKeyword("TONEMAPPING_FILMIC");
			}
			material.SetFloat(ColorGradingComponent.Uniforms._HueShift, settings.basic.hueShift / 360f);
			material.SetFloat(ColorGradingComponent.Uniforms._Saturation, settings.basic.saturation);
			material.SetFloat(ColorGradingComponent.Uniforms._Contrast, settings.basic.contrast);
			material.SetVector(ColorGradingComponent.Uniforms._Balance, this.CalculateColorBalance(settings.basic.temperature, settings.basic.tint));
			Vector3 v;
			Vector3 v2;
			Vector3 v3;
			ColorGradingComponent.CalculateLiftGammaGain(settings.colorWheels.linear.lift, settings.colorWheels.linear.gamma, settings.colorWheels.linear.gain, out v, out v2, out v3);
			material.SetVector(ColorGradingComponent.Uniforms._Lift, v);
			material.SetVector(ColorGradingComponent.Uniforms._InvGamma, v2);
			material.SetVector(ColorGradingComponent.Uniforms._Gain, v3);
			Vector3 v4;
			Vector3 v5;
			Vector3 v6;
			ColorGradingComponent.CalculateSlopePowerOffset(settings.colorWheels.log.slope, settings.colorWheels.log.power, settings.colorWheels.log.offset, out v4, out v5, out v6);
			material.SetVector(ColorGradingComponent.Uniforms._Slope, v4);
			material.SetVector(ColorGradingComponent.Uniforms._Power, v5);
			material.SetVector(ColorGradingComponent.Uniforms._Offset, v6);
			material.SetVector(ColorGradingComponent.Uniforms._ChannelMixerRed, settings.channelMixer.red);
			material.SetVector(ColorGradingComponent.Uniforms._ChannelMixerGreen, settings.channelMixer.green);
			material.SetVector(ColorGradingComponent.Uniforms._ChannelMixerBlue, settings.channelMixer.blue);
			material.SetTexture(ColorGradingComponent.Uniforms._Curves, this.GetCurveTexture());
			Graphics.Blit(null, base.model.bakedLut, material, 0);
		}

		// Token: 0x0600230F RID: 8975 RVA: 0x001F63C0 File Offset: 0x001F45C0
		public override void Prepare(Material uberMaterial)
		{
			if (base.model.isDirty || !this.IsLogLutValid(base.model.bakedLut))
			{
				this.GenerateLut();
				base.model.isDirty = false;
			}
			uberMaterial.EnableKeyword(this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) ? "COLOR_GRADING_LOG_VIEW" : "COLOR_GRADING");
			RenderTexture bakedLut = base.model.bakedLut;
			uberMaterial.SetTexture(ColorGradingComponent.Uniforms._LogLut, bakedLut);
			uberMaterial.SetVector(ColorGradingComponent.Uniforms._LogLut_Params, new Vector3(1f / (float)bakedLut.width, 1f / (float)bakedLut.height, (float)bakedLut.height - 1f));
			float value = Mathf.Exp(base.model.settings.basic.postExposure * 0.6931472f);
			uberMaterial.SetFloat(ColorGradingComponent.Uniforms._ExposureEV, value);
		}

		// Token: 0x06002310 RID: 8976 RVA: 0x001F64AC File Offset: 0x001F46AC
		public void OnGUI()
		{
			RenderTexture bakedLut = base.model.bakedLut;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)bakedLut.width, (float)bakedLut.height), bakedLut);
		}

		// Token: 0x06002311 RID: 8977 RVA: 0x001F6503 File Offset: 0x001F4703
		public override void OnDisable()
		{
			GraphicsUtils.Destroy(this.m_GradingCurves);
			GraphicsUtils.Destroy(base.model.bakedLut);
			this.m_GradingCurves = null;
			base.model.bakedLut = null;
		}

		// Token: 0x04004B8F RID: 19343
		private const int k_InternalLogLutSize = 32;

		// Token: 0x04004B90 RID: 19344
		private const int k_CurvePrecision = 128;

		// Token: 0x04004B91 RID: 19345
		private const float k_CurveStep = 0.0078125f;

		// Token: 0x04004B92 RID: 19346
		private Texture2D m_GradingCurves;

		// Token: 0x04004B93 RID: 19347
		private Color[] m_pixels = new Color[256];

		// Token: 0x020006A2 RID: 1698
		private static class Uniforms
		{
			// Token: 0x040050EC RID: 20716
			internal static readonly int _LutParams = Shader.PropertyToID("_LutParams");

			// Token: 0x040050ED RID: 20717
			internal static readonly int _NeutralTonemapperParams1 = Shader.PropertyToID("_NeutralTonemapperParams1");

			// Token: 0x040050EE RID: 20718
			internal static readonly int _NeutralTonemapperParams2 = Shader.PropertyToID("_NeutralTonemapperParams2");

			// Token: 0x040050EF RID: 20719
			internal static readonly int _HueShift = Shader.PropertyToID("_HueShift");

			// Token: 0x040050F0 RID: 20720
			internal static readonly int _Saturation = Shader.PropertyToID("_Saturation");

			// Token: 0x040050F1 RID: 20721
			internal static readonly int _Contrast = Shader.PropertyToID("_Contrast");

			// Token: 0x040050F2 RID: 20722
			internal static readonly int _Balance = Shader.PropertyToID("_Balance");

			// Token: 0x040050F3 RID: 20723
			internal static readonly int _Lift = Shader.PropertyToID("_Lift");

			// Token: 0x040050F4 RID: 20724
			internal static readonly int _InvGamma = Shader.PropertyToID("_InvGamma");

			// Token: 0x040050F5 RID: 20725
			internal static readonly int _Gain = Shader.PropertyToID("_Gain");

			// Token: 0x040050F6 RID: 20726
			internal static readonly int _Slope = Shader.PropertyToID("_Slope");

			// Token: 0x040050F7 RID: 20727
			internal static readonly int _Power = Shader.PropertyToID("_Power");

			// Token: 0x040050F8 RID: 20728
			internal static readonly int _Offset = Shader.PropertyToID("_Offset");

			// Token: 0x040050F9 RID: 20729
			internal static readonly int _ChannelMixerRed = Shader.PropertyToID("_ChannelMixerRed");

			// Token: 0x040050FA RID: 20730
			internal static readonly int _ChannelMixerGreen = Shader.PropertyToID("_ChannelMixerGreen");

			// Token: 0x040050FB RID: 20731
			internal static readonly int _ChannelMixerBlue = Shader.PropertyToID("_ChannelMixerBlue");

			// Token: 0x040050FC RID: 20732
			internal static readonly int _Curves = Shader.PropertyToID("_Curves");

			// Token: 0x040050FD RID: 20733
			internal static readonly int _LogLut = Shader.PropertyToID("_LogLut");

			// Token: 0x040050FE RID: 20734
			internal static readonly int _LogLut_Params = Shader.PropertyToID("_LogLut_Params");

			// Token: 0x040050FF RID: 20735
			internal static readonly int _ExposureEV = Shader.PropertyToID("_ExposureEV");
		}
	}
}
