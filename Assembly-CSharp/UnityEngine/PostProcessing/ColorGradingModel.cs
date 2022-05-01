using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600238A RID: 9098 RVA: 0x001FADF4 File Offset: 0x001F8FF4
		// (set) Token: 0x0600238B RID: 9099 RVA: 0x001FADFC File Offset: 0x001F8FFC
		public ColorGradingModel.Settings settings
		{
			get
			{
				return this.m_Settings;
			}
			set
			{
				this.m_Settings = value;
				this.OnValidate();
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x0600238C RID: 9100 RVA: 0x001FAE0B File Offset: 0x001F900B
		// (set) Token: 0x0600238D RID: 9101 RVA: 0x001FAE13 File Offset: 0x001F9013
		public bool isDirty { get; internal set; }

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x001FAE1C File Offset: 0x001F901C
		// (set) Token: 0x0600238F RID: 9103 RVA: 0x001FAE24 File Offset: 0x001F9024
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002390 RID: 9104 RVA: 0x001FAE2D File Offset: 0x001F902D
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002391 RID: 9105 RVA: 0x001FAE40 File Offset: 0x001F9040
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004BE7 RID: 19431
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006C5 RID: 1733
		public enum Tonemapper
		{
			// Token: 0x040051FC RID: 20988
			None,
			// Token: 0x040051FD RID: 20989
			ACES,
			// Token: 0x040051FE RID: 20990
			Neutral
		}

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x0600278C RID: 10124 RVA: 0x002093CC File Offset: 0x002075CC
			public static ColorGradingModel.TonemappingSettings defaultSettings
			{
				get
				{
					return new ColorGradingModel.TonemappingSettings
					{
						tonemapper = ColorGradingModel.Tonemapper.Neutral,
						neutralBlackIn = 0.02f,
						neutralWhiteIn = 10f,
						neutralBlackOut = 0f,
						neutralWhiteOut = 10f,
						neutralWhiteLevel = 5.3f,
						neutralWhiteClip = 10f
					};
				}
			}

			// Token: 0x040051FF RID: 20991
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x04005200 RID: 20992
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x04005201 RID: 20993
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x04005202 RID: 20994
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x04005203 RID: 20995
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x04005204 RID: 20996
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x04005205 RID: 20997
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x0600278D RID: 10125 RVA: 0x00209434 File Offset: 0x00207634
			public static ColorGradingModel.BasicSettings defaultSettings
			{
				get
				{
					return new ColorGradingModel.BasicSettings
					{
						postExposure = 0f,
						temperature = 0f,
						tint = 0f,
						hueShift = 0f,
						saturation = 1f,
						contrast = 1f
					};
				}
			}

			// Token: 0x04005206 RID: 20998
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x04005207 RID: 20999
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x04005208 RID: 21000
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x04005209 RID: 21001
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x0400520A RID: 21002
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x0400520B RID: 21003
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006C8 RID: 1736
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x0600278E RID: 10126 RVA: 0x00209494 File Offset: 0x00207694
			public static ColorGradingModel.ChannelMixerSettings defaultSettings
			{
				get
				{
					return new ColorGradingModel.ChannelMixerSettings
					{
						red = new Vector3(1f, 0f, 0f),
						green = new Vector3(0f, 1f, 0f),
						blue = new Vector3(0f, 0f, 1f),
						currentEditingChannel = 0
					};
				}
			}

			// Token: 0x0400520C RID: 21004
			public Vector3 red;

			// Token: 0x0400520D RID: 21005
			public Vector3 green;

			// Token: 0x0400520E RID: 21006
			public Vector3 blue;

			// Token: 0x0400520F RID: 21007
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x0600278F RID: 10127 RVA: 0x00209504 File Offset: 0x00207704
			public static ColorGradingModel.LogWheelsSettings defaultSettings
			{
				get
				{
					return new ColorGradingModel.LogWheelsSettings
					{
						slope = Color.clear,
						power = Color.clear,
						offset = Color.clear
					};
				}
			}

			// Token: 0x04005210 RID: 21008
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x04005211 RID: 21009
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x04005212 RID: 21010
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006CA RID: 1738
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002790 RID: 10128 RVA: 0x00209540 File Offset: 0x00207740
			public static ColorGradingModel.LinearWheelsSettings defaultSettings
			{
				get
				{
					return new ColorGradingModel.LinearWheelsSettings
					{
						lift = Color.clear,
						gamma = Color.clear,
						gain = Color.clear
					};
				}
			}

			// Token: 0x04005213 RID: 21011
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x04005214 RID: 21012
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x04005215 RID: 21013
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006CB RID: 1739
		public enum ColorWheelMode
		{
			// Token: 0x04005217 RID: 21015
			Linear,
			// Token: 0x04005218 RID: 21016
			Log
		}

		// Token: 0x020006CC RID: 1740
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002791 RID: 10129 RVA: 0x0020957C File Offset: 0x0020777C
			public static ColorGradingModel.ColorWheelsSettings defaultSettings
			{
				get
				{
					return new ColorGradingModel.ColorWheelsSettings
					{
						mode = ColorGradingModel.ColorWheelMode.Log,
						log = ColorGradingModel.LogWheelsSettings.defaultSettings,
						linear = ColorGradingModel.LinearWheelsSettings.defaultSettings
					};
				}
			}

			// Token: 0x04005219 RID: 21017
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x0400521A RID: 21018
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x0400521B RID: 21019
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006CD RID: 1741
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002792 RID: 10130 RVA: 0x002095B4 File Offset: 0x002077B4
			public static ColorGradingModel.CurvesSettings defaultSettings
			{
				get
				{
					return new ColorGradingModel.CurvesSettings
					{
						master = new ColorGradingCurve(new AnimationCurve(new Keyframe[]
						{
							new Keyframe(0f, 0f, 1f, 1f),
							new Keyframe(1f, 1f, 1f, 1f)
						}), 0f, false, new Vector2(0f, 1f)),
						red = new ColorGradingCurve(new AnimationCurve(new Keyframe[]
						{
							new Keyframe(0f, 0f, 1f, 1f),
							new Keyframe(1f, 1f, 1f, 1f)
						}), 0f, false, new Vector2(0f, 1f)),
						green = new ColorGradingCurve(new AnimationCurve(new Keyframe[]
						{
							new Keyframe(0f, 0f, 1f, 1f),
							new Keyframe(1f, 1f, 1f, 1f)
						}), 0f, false, new Vector2(0f, 1f)),
						blue = new ColorGradingCurve(new AnimationCurve(new Keyframe[]
						{
							new Keyframe(0f, 0f, 1f, 1f),
							new Keyframe(1f, 1f, 1f, 1f)
						}), 0f, false, new Vector2(0f, 1f)),
						hueVShue = new ColorGradingCurve(new AnimationCurve(), 0.5f, true, new Vector2(0f, 1f)),
						hueVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, true, new Vector2(0f, 1f)),
						satVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, false, new Vector2(0f, 1f)),
						lumVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, false, new Vector2(0f, 1f)),
						e_CurrentEditingCurve = 0,
						e_CurveY = true,
						e_CurveR = false,
						e_CurveG = false,
						e_CurveB = false
					};
				}
			}

			// Token: 0x0400521C RID: 21020
			public ColorGradingCurve master;

			// Token: 0x0400521D RID: 21021
			public ColorGradingCurve red;

			// Token: 0x0400521E RID: 21022
			public ColorGradingCurve green;

			// Token: 0x0400521F RID: 21023
			public ColorGradingCurve blue;

			// Token: 0x04005220 RID: 21024
			public ColorGradingCurve hueVShue;

			// Token: 0x04005221 RID: 21025
			public ColorGradingCurve hueVSsat;

			// Token: 0x04005222 RID: 21026
			public ColorGradingCurve satVSsat;

			// Token: 0x04005223 RID: 21027
			public ColorGradingCurve lumVSsat;

			// Token: 0x04005224 RID: 21028
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x04005225 RID: 21029
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x04005226 RID: 21030
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x04005227 RID: 21031
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x04005228 RID: 21032
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006CE RID: 1742
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x06002793 RID: 10131 RVA: 0x0020983C File Offset: 0x00207A3C
			public static ColorGradingModel.Settings defaultSettings
			{
				get
				{
					return new ColorGradingModel.Settings
					{
						tonemapping = ColorGradingModel.TonemappingSettings.defaultSettings,
						basic = ColorGradingModel.BasicSettings.defaultSettings,
						channelMixer = ColorGradingModel.ChannelMixerSettings.defaultSettings,
						colorWheels = ColorGradingModel.ColorWheelsSettings.defaultSettings,
						curves = ColorGradingModel.CurvesSettings.defaultSettings
					};
				}
			}

			// Token: 0x04005229 RID: 21033
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x0400522A RID: 21034
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x0400522B RID: 21035
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x0400522C RID: 21036
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x0400522D RID: 21037
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
