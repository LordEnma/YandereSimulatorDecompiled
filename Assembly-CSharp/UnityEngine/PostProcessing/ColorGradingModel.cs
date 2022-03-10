using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000569 RID: 1385
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600234A RID: 9034 RVA: 0x001F5204 File Offset: 0x001F3404
		// (set) Token: 0x0600234B RID: 9035 RVA: 0x001F520C File Offset: 0x001F340C
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
		// (get) Token: 0x0600234C RID: 9036 RVA: 0x001F521B File Offset: 0x001F341B
		// (set) Token: 0x0600234D RID: 9037 RVA: 0x001F5223 File Offset: 0x001F3423
		public bool isDirty { get; internal set; }

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600234E RID: 9038 RVA: 0x001F522C File Offset: 0x001F342C
		// (set) Token: 0x0600234F RID: 9039 RVA: 0x001F5234 File Offset: 0x001F3434
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002350 RID: 9040 RVA: 0x001F523D File Offset: 0x001F343D
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002351 RID: 9041 RVA: 0x001F5250 File Offset: 0x001F3450
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004B2A RID: 19242
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006BA RID: 1722
		public enum Tonemapper
		{
			// Token: 0x04005137 RID: 20791
			None,
			// Token: 0x04005138 RID: 20792
			ACES,
			// Token: 0x04005139 RID: 20793
			Neutral
		}

		// Token: 0x020006BB RID: 1723
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x0600274C RID: 10060 RVA: 0x00203578 File Offset: 0x00201778
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

			// Token: 0x0400513A RID: 20794
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x0400513B RID: 20795
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x0400513C RID: 20796
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x0400513D RID: 20797
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x0400513E RID: 20798
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x0400513F RID: 20799
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x04005140 RID: 20800
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x0600274D RID: 10061 RVA: 0x002035E0 File Offset: 0x002017E0
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

			// Token: 0x04005141 RID: 20801
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x04005142 RID: 20802
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x04005143 RID: 20803
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x04005144 RID: 20804
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x04005145 RID: 20805
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x04005146 RID: 20806
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x0600274E RID: 10062 RVA: 0x00203640 File Offset: 0x00201840
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

			// Token: 0x04005147 RID: 20807
			public Vector3 red;

			// Token: 0x04005148 RID: 20808
			public Vector3 green;

			// Token: 0x04005149 RID: 20809
			public Vector3 blue;

			// Token: 0x0400514A RID: 20810
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x0600274F RID: 10063 RVA: 0x002036B0 File Offset: 0x002018B0
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

			// Token: 0x0400514B RID: 20811
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x0400514C RID: 20812
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x0400514D RID: 20813
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002750 RID: 10064 RVA: 0x002036EC File Offset: 0x002018EC
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

			// Token: 0x0400514E RID: 20814
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x0400514F RID: 20815
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x04005150 RID: 20816
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006C0 RID: 1728
		public enum ColorWheelMode
		{
			// Token: 0x04005152 RID: 20818
			Linear,
			// Token: 0x04005153 RID: 20819
			Log
		}

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002751 RID: 10065 RVA: 0x00203728 File Offset: 0x00201928
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

			// Token: 0x04005154 RID: 20820
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x04005155 RID: 20821
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x04005156 RID: 20822
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002752 RID: 10066 RVA: 0x00203760 File Offset: 0x00201960
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

			// Token: 0x04005157 RID: 20823
			public ColorGradingCurve master;

			// Token: 0x04005158 RID: 20824
			public ColorGradingCurve red;

			// Token: 0x04005159 RID: 20825
			public ColorGradingCurve green;

			// Token: 0x0400515A RID: 20826
			public ColorGradingCurve blue;

			// Token: 0x0400515B RID: 20827
			public ColorGradingCurve hueVShue;

			// Token: 0x0400515C RID: 20828
			public ColorGradingCurve hueVSsat;

			// Token: 0x0400515D RID: 20829
			public ColorGradingCurve satVSsat;

			// Token: 0x0400515E RID: 20830
			public ColorGradingCurve lumVSsat;

			// Token: 0x0400515F RID: 20831
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x04005160 RID: 20832
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x04005161 RID: 20833
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x04005162 RID: 20834
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x04005163 RID: 20835
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006C3 RID: 1731
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002753 RID: 10067 RVA: 0x002039E8 File Offset: 0x00201BE8
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

			// Token: 0x04005164 RID: 20836
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x04005165 RID: 20837
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x04005166 RID: 20838
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x04005167 RID: 20839
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x04005168 RID: 20840
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
