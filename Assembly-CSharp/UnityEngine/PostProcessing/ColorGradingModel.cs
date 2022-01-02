using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x0600231E RID: 8990 RVA: 0x001F136C File Offset: 0x001EF56C
		// (set) Token: 0x0600231F RID: 8991 RVA: 0x001F1374 File Offset: 0x001EF574
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

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06002320 RID: 8992 RVA: 0x001F1383 File Offset: 0x001EF583
		// (set) Token: 0x06002321 RID: 8993 RVA: 0x001F138B File Offset: 0x001EF58B
		public bool isDirty { get; internal set; }

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06002322 RID: 8994 RVA: 0x001F1394 File Offset: 0x001EF594
		// (set) Token: 0x06002323 RID: 8995 RVA: 0x001F139C File Offset: 0x001EF59C
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002324 RID: 8996 RVA: 0x001F13A5 File Offset: 0x001EF5A5
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002325 RID: 8997 RVA: 0x001F13B8 File Offset: 0x001EF5B8
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004AC5 RID: 19141
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006B8 RID: 1720
		public enum Tonemapper
		{
			// Token: 0x040050FB RID: 20731
			None,
			// Token: 0x040050FC RID: 20732
			ACES,
			// Token: 0x040050FD RID: 20733
			Neutral
		}

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x0600272B RID: 10027 RVA: 0x001FFCFC File Offset: 0x001FDEFC
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

			// Token: 0x040050FE RID: 20734
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x040050FF RID: 20735
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x04005100 RID: 20736
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x04005101 RID: 20737
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x04005102 RID: 20738
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x04005103 RID: 20739
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x04005104 RID: 20740
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006BA RID: 1722
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x0600272C RID: 10028 RVA: 0x001FFD64 File Offset: 0x001FDF64
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

			// Token: 0x04005105 RID: 20741
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x04005106 RID: 20742
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x04005107 RID: 20743
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x04005108 RID: 20744
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x04005109 RID: 20745
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x0400510A RID: 20746
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006BB RID: 1723
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x0600272D RID: 10029 RVA: 0x001FFDC4 File Offset: 0x001FDFC4
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

			// Token: 0x0400510B RID: 20747
			public Vector3 red;

			// Token: 0x0400510C RID: 20748
			public Vector3 green;

			// Token: 0x0400510D RID: 20749
			public Vector3 blue;

			// Token: 0x0400510E RID: 20750
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x0600272E RID: 10030 RVA: 0x001FFE34 File Offset: 0x001FE034
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

			// Token: 0x0400510F RID: 20751
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x04005110 RID: 20752
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x04005111 RID: 20753
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x0600272F RID: 10031 RVA: 0x001FFE70 File Offset: 0x001FE070
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

			// Token: 0x04005112 RID: 20754
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x04005113 RID: 20755
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x04005114 RID: 20756
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006BE RID: 1726
		public enum ColorWheelMode
		{
			// Token: 0x04005116 RID: 20758
			Linear,
			// Token: 0x04005117 RID: 20759
			Log
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x06002730 RID: 10032 RVA: 0x001FFEAC File Offset: 0x001FE0AC
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

			// Token: 0x04005118 RID: 20760
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x04005119 RID: 20761
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x0400511A RID: 20762
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x06002731 RID: 10033 RVA: 0x001FFEE4 File Offset: 0x001FE0E4
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

			// Token: 0x0400511B RID: 20763
			public ColorGradingCurve master;

			// Token: 0x0400511C RID: 20764
			public ColorGradingCurve red;

			// Token: 0x0400511D RID: 20765
			public ColorGradingCurve green;

			// Token: 0x0400511E RID: 20766
			public ColorGradingCurve blue;

			// Token: 0x0400511F RID: 20767
			public ColorGradingCurve hueVShue;

			// Token: 0x04005120 RID: 20768
			public ColorGradingCurve hueVSsat;

			// Token: 0x04005121 RID: 20769
			public ColorGradingCurve satVSsat;

			// Token: 0x04005122 RID: 20770
			public ColorGradingCurve lumVSsat;

			// Token: 0x04005123 RID: 20771
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x04005124 RID: 20772
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x04005125 RID: 20773
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x04005126 RID: 20774
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x04005127 RID: 20775
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x06002732 RID: 10034 RVA: 0x0020016C File Offset: 0x001FE36C
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

			// Token: 0x04005128 RID: 20776
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x04005129 RID: 20777
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x0400512A RID: 20778
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x0400512B RID: 20779
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x0400512C RID: 20780
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
