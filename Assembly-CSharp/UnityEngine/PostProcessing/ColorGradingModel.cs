using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002395 RID: 9109 RVA: 0x001FC540 File Offset: 0x001FA740
		// (set) Token: 0x06002396 RID: 9110 RVA: 0x001FC548 File Offset: 0x001FA748
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

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002397 RID: 9111 RVA: 0x001FC557 File Offset: 0x001FA757
		// (set) Token: 0x06002398 RID: 9112 RVA: 0x001FC55F File Offset: 0x001FA75F
		public bool isDirty { get; internal set; }

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06002399 RID: 9113 RVA: 0x001FC568 File Offset: 0x001FA768
		// (set) Token: 0x0600239A RID: 9114 RVA: 0x001FC570 File Offset: 0x001FA770
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x0600239B RID: 9115 RVA: 0x001FC579 File Offset: 0x001FA779
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x0600239C RID: 9116 RVA: 0x001FC58C File Offset: 0x001FA78C
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004C0E RID: 19470
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006C6 RID: 1734
		public enum Tonemapper
		{
			// Token: 0x04005223 RID: 21027
			None,
			// Token: 0x04005224 RID: 21028
			ACES,
			// Token: 0x04005225 RID: 21029
			Neutral
		}

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x06002797 RID: 10135 RVA: 0x0020AB18 File Offset: 0x00208D18
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

			// Token: 0x04005226 RID: 21030
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x04005227 RID: 21031
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x04005228 RID: 21032
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x04005229 RID: 21033
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x0400522A RID: 21034
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x0400522B RID: 21035
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x0400522C RID: 21036
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006C8 RID: 1736
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002798 RID: 10136 RVA: 0x0020AB80 File Offset: 0x00208D80
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

			// Token: 0x0400522D RID: 21037
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x0400522E RID: 21038
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x0400522F RID: 21039
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x04005230 RID: 21040
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x04005231 RID: 21041
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x04005232 RID: 21042
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002799 RID: 10137 RVA: 0x0020ABE0 File Offset: 0x00208DE0
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

			// Token: 0x04005233 RID: 21043
			public Vector3 red;

			// Token: 0x04005234 RID: 21044
			public Vector3 green;

			// Token: 0x04005235 RID: 21045
			public Vector3 blue;

			// Token: 0x04005236 RID: 21046
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006CA RID: 1738
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x0600279A RID: 10138 RVA: 0x0020AC50 File Offset: 0x00208E50
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

			// Token: 0x04005237 RID: 21047
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x04005238 RID: 21048
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x04005239 RID: 21049
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006CB RID: 1739
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x0600279B RID: 10139 RVA: 0x0020AC8C File Offset: 0x00208E8C
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

			// Token: 0x0400523A RID: 21050
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x0400523B RID: 21051
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x0400523C RID: 21052
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006CC RID: 1740
		public enum ColorWheelMode
		{
			// Token: 0x0400523E RID: 21054
			Linear,
			// Token: 0x0400523F RID: 21055
			Log
		}

		// Token: 0x020006CD RID: 1741
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x0600279C RID: 10140 RVA: 0x0020ACC8 File Offset: 0x00208EC8
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

			// Token: 0x04005240 RID: 21056
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x04005241 RID: 21057
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x04005242 RID: 21058
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006CE RID: 1742
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x0600279D RID: 10141 RVA: 0x0020AD00 File Offset: 0x00208F00
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

			// Token: 0x04005243 RID: 21059
			public ColorGradingCurve master;

			// Token: 0x04005244 RID: 21060
			public ColorGradingCurve red;

			// Token: 0x04005245 RID: 21061
			public ColorGradingCurve green;

			// Token: 0x04005246 RID: 21062
			public ColorGradingCurve blue;

			// Token: 0x04005247 RID: 21063
			public ColorGradingCurve hueVShue;

			// Token: 0x04005248 RID: 21064
			public ColorGradingCurve hueVSsat;

			// Token: 0x04005249 RID: 21065
			public ColorGradingCurve satVSsat;

			// Token: 0x0400524A RID: 21066
			public ColorGradingCurve lumVSsat;

			// Token: 0x0400524B RID: 21067
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x0400524C RID: 21068
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x0400524D RID: 21069
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x0400524E RID: 21070
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x0400524F RID: 21071
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x0600279E RID: 10142 RVA: 0x0020AF88 File Offset: 0x00209188
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

			// Token: 0x04005250 RID: 21072
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x04005251 RID: 21073
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x04005252 RID: 21074
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x04005253 RID: 21075
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x04005254 RID: 21076
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
