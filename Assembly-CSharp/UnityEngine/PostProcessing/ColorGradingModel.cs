using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x0600237A RID: 9082 RVA: 0x001F8F0C File Offset: 0x001F710C
		// (set) Token: 0x0600237B RID: 9083 RVA: 0x001F8F14 File Offset: 0x001F7114
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

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600237C RID: 9084 RVA: 0x001F8F23 File Offset: 0x001F7123
		// (set) Token: 0x0600237D RID: 9085 RVA: 0x001F8F2B File Offset: 0x001F712B
		public bool isDirty { get; internal set; }

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x0600237E RID: 9086 RVA: 0x001F8F34 File Offset: 0x001F7134
		// (set) Token: 0x0600237F RID: 9087 RVA: 0x001F8F3C File Offset: 0x001F713C
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002380 RID: 9088 RVA: 0x001F8F45 File Offset: 0x001F7145
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002381 RID: 9089 RVA: 0x001F8F58 File Offset: 0x001F7158
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004BBF RID: 19391
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006C4 RID: 1732
		public enum Tonemapper
		{
			// Token: 0x040051CC RID: 20940
			None,
			// Token: 0x040051CD RID: 20941
			ACES,
			// Token: 0x040051CE RID: 20942
			Neutral
		}

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x0600277C RID: 10108 RVA: 0x002073D0 File Offset: 0x002055D0
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

			// Token: 0x040051CF RID: 20943
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x040051D0 RID: 20944
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x040051D1 RID: 20945
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x040051D2 RID: 20946
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x040051D3 RID: 20947
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x040051D4 RID: 20948
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x040051D5 RID: 20949
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x0600277D RID: 10109 RVA: 0x00207438 File Offset: 0x00205638
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

			// Token: 0x040051D6 RID: 20950
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x040051D7 RID: 20951
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x040051D8 RID: 20952
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x040051D9 RID: 20953
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x040051DA RID: 20954
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x040051DB RID: 20955
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x0600277E RID: 10110 RVA: 0x00207498 File Offset: 0x00205698
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

			// Token: 0x040051DC RID: 20956
			public Vector3 red;

			// Token: 0x040051DD RID: 20957
			public Vector3 green;

			// Token: 0x040051DE RID: 20958
			public Vector3 blue;

			// Token: 0x040051DF RID: 20959
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006C8 RID: 1736
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x0600277F RID: 10111 RVA: 0x00207508 File Offset: 0x00205708
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

			// Token: 0x040051E0 RID: 20960
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x040051E1 RID: 20961
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x040051E2 RID: 20962
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002780 RID: 10112 RVA: 0x00207544 File Offset: 0x00205744
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

			// Token: 0x040051E3 RID: 20963
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x040051E4 RID: 20964
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x040051E5 RID: 20965
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006CA RID: 1738
		public enum ColorWheelMode
		{
			// Token: 0x040051E7 RID: 20967
			Linear,
			// Token: 0x040051E8 RID: 20968
			Log
		}

		// Token: 0x020006CB RID: 1739
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002781 RID: 10113 RVA: 0x00207580 File Offset: 0x00205780
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

			// Token: 0x040051E9 RID: 20969
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x040051EA RID: 20970
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x040051EB RID: 20971
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006CC RID: 1740
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002782 RID: 10114 RVA: 0x002075B8 File Offset: 0x002057B8
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

			// Token: 0x040051EC RID: 20972
			public ColorGradingCurve master;

			// Token: 0x040051ED RID: 20973
			public ColorGradingCurve red;

			// Token: 0x040051EE RID: 20974
			public ColorGradingCurve green;

			// Token: 0x040051EF RID: 20975
			public ColorGradingCurve blue;

			// Token: 0x040051F0 RID: 20976
			public ColorGradingCurve hueVShue;

			// Token: 0x040051F1 RID: 20977
			public ColorGradingCurve hueVSsat;

			// Token: 0x040051F2 RID: 20978
			public ColorGradingCurve satVSsat;

			// Token: 0x040051F3 RID: 20979
			public ColorGradingCurve lumVSsat;

			// Token: 0x040051F4 RID: 20980
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x040051F5 RID: 20981
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x040051F6 RID: 20982
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x040051F7 RID: 20983
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x040051F8 RID: 20984
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006CD RID: 1741
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002783 RID: 10115 RVA: 0x00207840 File Offset: 0x00205A40
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

			// Token: 0x040051F9 RID: 20985
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x040051FA RID: 20986
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x040051FB RID: 20987
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x040051FC RID: 20988
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x040051FD RID: 20989
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
