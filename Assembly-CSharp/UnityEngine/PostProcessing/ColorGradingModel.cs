using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x0600232B RID: 9003 RVA: 0x001F29DC File Offset: 0x001F0BDC
		// (set) Token: 0x0600232C RID: 9004 RVA: 0x001F29E4 File Offset: 0x001F0BE4
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
		// (get) Token: 0x0600232D RID: 9005 RVA: 0x001F29F3 File Offset: 0x001F0BF3
		// (set) Token: 0x0600232E RID: 9006 RVA: 0x001F29FB File Offset: 0x001F0BFB
		public bool isDirty { get; internal set; }

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600232F RID: 9007 RVA: 0x001F2A04 File Offset: 0x001F0C04
		// (set) Token: 0x06002330 RID: 9008 RVA: 0x001F2A0C File Offset: 0x001F0C0C
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002331 RID: 9009 RVA: 0x001F2A15 File Offset: 0x001F0C15
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002332 RID: 9010 RVA: 0x001F2A28 File Offset: 0x001F0C28
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004AE0 RID: 19168
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006BB RID: 1723
		public enum Tonemapper
		{
			// Token: 0x04005116 RID: 20758
			None,
			// Token: 0x04005117 RID: 20759
			ACES,
			// Token: 0x04005118 RID: 20760
			Neutral
		}

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002738 RID: 10040 RVA: 0x0020136C File Offset: 0x001FF56C
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

			// Token: 0x04005119 RID: 20761
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x0400511A RID: 20762
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x0400511B RID: 20763
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x0400511C RID: 20764
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x0400511D RID: 20765
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x0400511E RID: 20766
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x0400511F RID: 20767
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002739 RID: 10041 RVA: 0x002013D4 File Offset: 0x001FF5D4
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

			// Token: 0x04005120 RID: 20768
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x04005121 RID: 20769
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x04005122 RID: 20770
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x04005123 RID: 20771
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x04005124 RID: 20772
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x04005125 RID: 20773
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x0600273A RID: 10042 RVA: 0x00201434 File Offset: 0x001FF634
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

			// Token: 0x04005126 RID: 20774
			public Vector3 red;

			// Token: 0x04005127 RID: 20775
			public Vector3 green;

			// Token: 0x04005128 RID: 20776
			public Vector3 blue;

			// Token: 0x04005129 RID: 20777
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x0600273B RID: 10043 RVA: 0x002014A4 File Offset: 0x001FF6A4
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

			// Token: 0x0400512A RID: 20778
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x0400512B RID: 20779
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x0400512C RID: 20780
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x0600273C RID: 10044 RVA: 0x002014E0 File Offset: 0x001FF6E0
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

			// Token: 0x0400512D RID: 20781
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x0400512E RID: 20782
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x0400512F RID: 20783
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006C1 RID: 1729
		public enum ColorWheelMode
		{
			// Token: 0x04005131 RID: 20785
			Linear,
			// Token: 0x04005132 RID: 20786
			Log
		}

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x0600273D RID: 10045 RVA: 0x0020151C File Offset: 0x001FF71C
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

			// Token: 0x04005133 RID: 20787
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x04005134 RID: 20788
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x04005135 RID: 20789
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006C3 RID: 1731
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x0600273E RID: 10046 RVA: 0x00201554 File Offset: 0x001FF754
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

			// Token: 0x04005136 RID: 20790
			public ColorGradingCurve master;

			// Token: 0x04005137 RID: 20791
			public ColorGradingCurve red;

			// Token: 0x04005138 RID: 20792
			public ColorGradingCurve green;

			// Token: 0x04005139 RID: 20793
			public ColorGradingCurve blue;

			// Token: 0x0400513A RID: 20794
			public ColorGradingCurve hueVShue;

			// Token: 0x0400513B RID: 20795
			public ColorGradingCurve hueVSsat;

			// Token: 0x0400513C RID: 20796
			public ColorGradingCurve satVSsat;

			// Token: 0x0400513D RID: 20797
			public ColorGradingCurve lumVSsat;

			// Token: 0x0400513E RID: 20798
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x0400513F RID: 20799
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x04005140 RID: 20800
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x04005141 RID: 20801
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x04005142 RID: 20802
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006C4 RID: 1732
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x0600273F RID: 10047 RVA: 0x002017DC File Offset: 0x001FF9DC
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

			// Token: 0x04005143 RID: 20803
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x04005144 RID: 20804
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x04005145 RID: 20805
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x04005146 RID: 20806
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x04005147 RID: 20807
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
