using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600233B RID: 9019 RVA: 0x001F3C4C File Offset: 0x001F1E4C
		// (set) Token: 0x0600233C RID: 9020 RVA: 0x001F3C54 File Offset: 0x001F1E54
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

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x0600233D RID: 9021 RVA: 0x001F3C63 File Offset: 0x001F1E63
		// (set) Token: 0x0600233E RID: 9022 RVA: 0x001F3C6B File Offset: 0x001F1E6B
		public bool isDirty { get; internal set; }

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600233F RID: 9023 RVA: 0x001F3C74 File Offset: 0x001F1E74
		// (set) Token: 0x06002340 RID: 9024 RVA: 0x001F3C7C File Offset: 0x001F1E7C
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002341 RID: 9025 RVA: 0x001F3C85 File Offset: 0x001F1E85
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002342 RID: 9026 RVA: 0x001F3C98 File Offset: 0x001F1E98
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004AFD RID: 19197
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006B6 RID: 1718
		public enum Tonemapper
		{
			// Token: 0x04005105 RID: 20741
			None,
			// Token: 0x04005106 RID: 20742
			ACES,
			// Token: 0x04005107 RID: 20743
			Neutral
		}

		// Token: 0x020006B7 RID: 1719
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06002734 RID: 10036 RVA: 0x00201EF8 File Offset: 0x002000F8
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

			// Token: 0x04005108 RID: 20744
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x04005109 RID: 20745
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x0400510A RID: 20746
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x0400510B RID: 20747
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x0400510C RID: 20748
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x0400510D RID: 20749
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x0400510E RID: 20750
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006B8 RID: 1720
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06002735 RID: 10037 RVA: 0x00201F60 File Offset: 0x00200160
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

			// Token: 0x0400510F RID: 20751
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x04005110 RID: 20752
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x04005111 RID: 20753
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x04005112 RID: 20754
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x04005113 RID: 20755
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x04005114 RID: 20756
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x06002736 RID: 10038 RVA: 0x00201FC0 File Offset: 0x002001C0
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

			// Token: 0x04005115 RID: 20757
			public Vector3 red;

			// Token: 0x04005116 RID: 20758
			public Vector3 green;

			// Token: 0x04005117 RID: 20759
			public Vector3 blue;

			// Token: 0x04005118 RID: 20760
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006BA RID: 1722
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x06002737 RID: 10039 RVA: 0x00202030 File Offset: 0x00200230
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

			// Token: 0x04005119 RID: 20761
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x0400511A RID: 20762
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x0400511B RID: 20763
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006BB RID: 1723
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x06002738 RID: 10040 RVA: 0x0020206C File Offset: 0x0020026C
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

			// Token: 0x0400511C RID: 20764
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x0400511D RID: 20765
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x0400511E RID: 20766
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006BC RID: 1724
		public enum ColorWheelMode
		{
			// Token: 0x04005120 RID: 20768
			Linear,
			// Token: 0x04005121 RID: 20769
			Log
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x06002739 RID: 10041 RVA: 0x002020A8 File Offset: 0x002002A8
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

			// Token: 0x04005122 RID: 20770
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x04005123 RID: 20771
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x04005124 RID: 20772
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x0600273A RID: 10042 RVA: 0x002020E0 File Offset: 0x002002E0
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

			// Token: 0x04005125 RID: 20773
			public ColorGradingCurve master;

			// Token: 0x04005126 RID: 20774
			public ColorGradingCurve red;

			// Token: 0x04005127 RID: 20775
			public ColorGradingCurve green;

			// Token: 0x04005128 RID: 20776
			public ColorGradingCurve blue;

			// Token: 0x04005129 RID: 20777
			public ColorGradingCurve hueVShue;

			// Token: 0x0400512A RID: 20778
			public ColorGradingCurve hueVSsat;

			// Token: 0x0400512B RID: 20779
			public ColorGradingCurve satVSsat;

			// Token: 0x0400512C RID: 20780
			public ColorGradingCurve lumVSsat;

			// Token: 0x0400512D RID: 20781
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x0400512E RID: 20782
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x0400512F RID: 20783
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x04005130 RID: 20784
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x04005131 RID: 20785
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x0600273B RID: 10043 RVA: 0x00202368 File Offset: 0x00200568
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

			// Token: 0x04005132 RID: 20786
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x04005133 RID: 20787
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x04005134 RID: 20788
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x04005135 RID: 20789
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x04005136 RID: 20790
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
