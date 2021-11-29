using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000561 RID: 1377
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x0600230A RID: 8970 RVA: 0x001EF648 File Offset: 0x001ED848
		// (set) Token: 0x0600230B RID: 8971 RVA: 0x001EF650 File Offset: 0x001ED850
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

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x0600230C RID: 8972 RVA: 0x001EF65F File Offset: 0x001ED85F
		// (set) Token: 0x0600230D RID: 8973 RVA: 0x001EF667 File Offset: 0x001ED867
		public bool isDirty { get; internal set; }

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x0600230E RID: 8974 RVA: 0x001EF670 File Offset: 0x001ED870
		// (set) Token: 0x0600230F RID: 8975 RVA: 0x001EF678 File Offset: 0x001ED878
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002310 RID: 8976 RVA: 0x001EF681 File Offset: 0x001ED881
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002311 RID: 8977 RVA: 0x001EF694 File Offset: 0x001ED894
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004A7D RID: 19069
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006B5 RID: 1717
		public enum Tonemapper
		{
			// Token: 0x040050A7 RID: 20647
			None,
			// Token: 0x040050A8 RID: 20648
			ACES,
			// Token: 0x040050A9 RID: 20649
			Neutral
		}

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002717 RID: 10007 RVA: 0x001FDFB4 File Offset: 0x001FC1B4
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

			// Token: 0x040050AA RID: 20650
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x040050AB RID: 20651
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x040050AC RID: 20652
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x040050AD RID: 20653
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x040050AE RID: 20654
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x040050AF RID: 20655
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x040050B0 RID: 20656
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006B7 RID: 1719
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002718 RID: 10008 RVA: 0x001FE01C File Offset: 0x001FC21C
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

			// Token: 0x040050B1 RID: 20657
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x040050B2 RID: 20658
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x040050B3 RID: 20659
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x040050B4 RID: 20660
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x040050B5 RID: 20661
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x040050B6 RID: 20662
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006B8 RID: 1720
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002719 RID: 10009 RVA: 0x001FE07C File Offset: 0x001FC27C
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

			// Token: 0x040050B7 RID: 20663
			public Vector3 red;

			// Token: 0x040050B8 RID: 20664
			public Vector3 green;

			// Token: 0x040050B9 RID: 20665
			public Vector3 blue;

			// Token: 0x040050BA RID: 20666
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x0600271A RID: 10010 RVA: 0x001FE0EC File Offset: 0x001FC2EC
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

			// Token: 0x040050BB RID: 20667
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x040050BC RID: 20668
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x040050BD RID: 20669
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006BA RID: 1722
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x0600271B RID: 10011 RVA: 0x001FE128 File Offset: 0x001FC328
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

			// Token: 0x040050BE RID: 20670
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x040050BF RID: 20671
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x040050C0 RID: 20672
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006BB RID: 1723
		public enum ColorWheelMode
		{
			// Token: 0x040050C2 RID: 20674
			Linear,
			// Token: 0x040050C3 RID: 20675
			Log
		}

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x0600271C RID: 10012 RVA: 0x001FE164 File Offset: 0x001FC364
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

			// Token: 0x040050C4 RID: 20676
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x040050C5 RID: 20677
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x040050C6 RID: 20678
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x0600271D RID: 10013 RVA: 0x001FE19C File Offset: 0x001FC39C
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

			// Token: 0x040050C7 RID: 20679
			public ColorGradingCurve master;

			// Token: 0x040050C8 RID: 20680
			public ColorGradingCurve red;

			// Token: 0x040050C9 RID: 20681
			public ColorGradingCurve green;

			// Token: 0x040050CA RID: 20682
			public ColorGradingCurve blue;

			// Token: 0x040050CB RID: 20683
			public ColorGradingCurve hueVShue;

			// Token: 0x040050CC RID: 20684
			public ColorGradingCurve hueVSsat;

			// Token: 0x040050CD RID: 20685
			public ColorGradingCurve satVSsat;

			// Token: 0x040050CE RID: 20686
			public ColorGradingCurve lumVSsat;

			// Token: 0x040050CF RID: 20687
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x040050D0 RID: 20688
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x040050D1 RID: 20689
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x040050D2 RID: 20690
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x040050D3 RID: 20691
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x0600271E RID: 10014 RVA: 0x001FE424 File Offset: 0x001FC624
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

			// Token: 0x040050D4 RID: 20692
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x040050D5 RID: 20693
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x040050D6 RID: 20694
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x040050D7 RID: 20695
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x040050D8 RID: 20696
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
