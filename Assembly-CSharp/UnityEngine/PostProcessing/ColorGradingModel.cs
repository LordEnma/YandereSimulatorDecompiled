using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06002381 RID: 9089 RVA: 0x001F9968 File Offset: 0x001F7B68
		// (set) Token: 0x06002382 RID: 9090 RVA: 0x001F9970 File Offset: 0x001F7B70
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
		// (get) Token: 0x06002383 RID: 9091 RVA: 0x001F997F File Offset: 0x001F7B7F
		// (set) Token: 0x06002384 RID: 9092 RVA: 0x001F9987 File Offset: 0x001F7B87
		public bool isDirty { get; internal set; }

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002385 RID: 9093 RVA: 0x001F9990 File Offset: 0x001F7B90
		// (set) Token: 0x06002386 RID: 9094 RVA: 0x001F9998 File Offset: 0x001F7B98
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002387 RID: 9095 RVA: 0x001F99A1 File Offset: 0x001F7BA1
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002388 RID: 9096 RVA: 0x001F99B4 File Offset: 0x001F7BB4
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004BD1 RID: 19409
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006C4 RID: 1732
		public enum Tonemapper
		{
			// Token: 0x040051DE RID: 20958
			None,
			// Token: 0x040051DF RID: 20959
			ACES,
			// Token: 0x040051E0 RID: 20960
			Neutral
		}

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x06002783 RID: 10115 RVA: 0x00207E2C File Offset: 0x0020602C
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

			// Token: 0x040051E1 RID: 20961
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x040051E2 RID: 20962
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x040051E3 RID: 20963
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x040051E4 RID: 20964
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x040051E5 RID: 20965
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x040051E6 RID: 20966
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x040051E7 RID: 20967
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x06002784 RID: 10116 RVA: 0x00207E94 File Offset: 0x00206094
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

			// Token: 0x040051E8 RID: 20968
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x040051E9 RID: 20969
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x040051EA RID: 20970
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x040051EB RID: 20971
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x040051EC RID: 20972
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x040051ED RID: 20973
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002785 RID: 10117 RVA: 0x00207EF4 File Offset: 0x002060F4
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

			// Token: 0x040051EE RID: 20974
			public Vector3 red;

			// Token: 0x040051EF RID: 20975
			public Vector3 green;

			// Token: 0x040051F0 RID: 20976
			public Vector3 blue;

			// Token: 0x040051F1 RID: 20977
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006C8 RID: 1736
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002786 RID: 10118 RVA: 0x00207F64 File Offset: 0x00206164
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

			// Token: 0x040051F2 RID: 20978
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x040051F3 RID: 20979
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x040051F4 RID: 20980
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002787 RID: 10119 RVA: 0x00207FA0 File Offset: 0x002061A0
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

			// Token: 0x040051F5 RID: 20981
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x040051F6 RID: 20982
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x040051F7 RID: 20983
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006CA RID: 1738
		public enum ColorWheelMode
		{
			// Token: 0x040051F9 RID: 20985
			Linear,
			// Token: 0x040051FA RID: 20986
			Log
		}

		// Token: 0x020006CB RID: 1739
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002788 RID: 10120 RVA: 0x00207FDC File Offset: 0x002061DC
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

			// Token: 0x040051FB RID: 20987
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x040051FC RID: 20988
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x040051FD RID: 20989
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006CC RID: 1740
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002789 RID: 10121 RVA: 0x00208014 File Offset: 0x00206214
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

			// Token: 0x040051FE RID: 20990
			public ColorGradingCurve master;

			// Token: 0x040051FF RID: 20991
			public ColorGradingCurve red;

			// Token: 0x04005200 RID: 20992
			public ColorGradingCurve green;

			// Token: 0x04005201 RID: 20993
			public ColorGradingCurve blue;

			// Token: 0x04005202 RID: 20994
			public ColorGradingCurve hueVShue;

			// Token: 0x04005203 RID: 20995
			public ColorGradingCurve hueVSsat;

			// Token: 0x04005204 RID: 20996
			public ColorGradingCurve satVSsat;

			// Token: 0x04005205 RID: 20997
			public ColorGradingCurve lumVSsat;

			// Token: 0x04005206 RID: 20998
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x04005207 RID: 20999
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x04005208 RID: 21000
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x04005209 RID: 21001
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x0400520A RID: 21002
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006CD RID: 1741
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x0600278A RID: 10122 RVA: 0x0020829C File Offset: 0x0020649C
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

			// Token: 0x0400520B RID: 21003
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x0400520C RID: 21004
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x0400520D RID: 21005
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x0400520E RID: 21006
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x0400520F RID: 21007
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
