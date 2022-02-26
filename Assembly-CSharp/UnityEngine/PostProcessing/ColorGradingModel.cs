using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06002344 RID: 9028 RVA: 0x001F482C File Offset: 0x001F2A2C
		// (set) Token: 0x06002345 RID: 9029 RVA: 0x001F4834 File Offset: 0x001F2A34
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
		// (get) Token: 0x06002346 RID: 9030 RVA: 0x001F4843 File Offset: 0x001F2A43
		// (set) Token: 0x06002347 RID: 9031 RVA: 0x001F484B File Offset: 0x001F2A4B
		public bool isDirty { get; internal set; }

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06002348 RID: 9032 RVA: 0x001F4854 File Offset: 0x001F2A54
		// (set) Token: 0x06002349 RID: 9033 RVA: 0x001F485C File Offset: 0x001F2A5C
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x0600234A RID: 9034 RVA: 0x001F4865 File Offset: 0x001F2A65
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x0600234B RID: 9035 RVA: 0x001F4878 File Offset: 0x001F2A78
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004B0D RID: 19213
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006B9 RID: 1721
		public enum Tonemapper
		{
			// Token: 0x0400511A RID: 20762
			None,
			// Token: 0x0400511B RID: 20763
			ACES,
			// Token: 0x0400511C RID: 20764
			Neutral
		}

		// Token: 0x020006BA RID: 1722
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x06002746 RID: 10054 RVA: 0x00202BA0 File Offset: 0x00200DA0
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

			// Token: 0x0400511D RID: 20765
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x0400511E RID: 20766
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x0400511F RID: 20767
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x04005120 RID: 20768
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x04005121 RID: 20769
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x04005122 RID: 20770
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x04005123 RID: 20771
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006BB RID: 1723
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x06002747 RID: 10055 RVA: 0x00202C08 File Offset: 0x00200E08
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

			// Token: 0x04005124 RID: 20772
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x04005125 RID: 20773
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x04005126 RID: 20774
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x04005127 RID: 20775
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x04005128 RID: 20776
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x04005129 RID: 20777
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x06002748 RID: 10056 RVA: 0x00202C68 File Offset: 0x00200E68
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

			// Token: 0x0400512A RID: 20778
			public Vector3 red;

			// Token: 0x0400512B RID: 20779
			public Vector3 green;

			// Token: 0x0400512C RID: 20780
			public Vector3 blue;

			// Token: 0x0400512D RID: 20781
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x06002749 RID: 10057 RVA: 0x00202CD8 File Offset: 0x00200ED8
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

			// Token: 0x0400512E RID: 20782
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x0400512F RID: 20783
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x04005130 RID: 20784
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x0600274A RID: 10058 RVA: 0x00202D14 File Offset: 0x00200F14
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

			// Token: 0x04005131 RID: 20785
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x04005132 RID: 20786
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x04005133 RID: 20787
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006BF RID: 1727
		public enum ColorWheelMode
		{
			// Token: 0x04005135 RID: 20789
			Linear,
			// Token: 0x04005136 RID: 20790
			Log
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x0600274B RID: 10059 RVA: 0x00202D50 File Offset: 0x00200F50
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

			// Token: 0x04005137 RID: 20791
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x04005138 RID: 20792
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x04005139 RID: 20793
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x0600274C RID: 10060 RVA: 0x00202D88 File Offset: 0x00200F88
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

			// Token: 0x0400513A RID: 20794
			public ColorGradingCurve master;

			// Token: 0x0400513B RID: 20795
			public ColorGradingCurve red;

			// Token: 0x0400513C RID: 20796
			public ColorGradingCurve green;

			// Token: 0x0400513D RID: 20797
			public ColorGradingCurve blue;

			// Token: 0x0400513E RID: 20798
			public ColorGradingCurve hueVShue;

			// Token: 0x0400513F RID: 20799
			public ColorGradingCurve hueVSsat;

			// Token: 0x04005140 RID: 20800
			public ColorGradingCurve satVSsat;

			// Token: 0x04005141 RID: 20801
			public ColorGradingCurve lumVSsat;

			// Token: 0x04005142 RID: 20802
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x04005143 RID: 20803
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x04005144 RID: 20804
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x04005145 RID: 20805
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x04005146 RID: 20806
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x0600274D RID: 10061 RVA: 0x00203010 File Offset: 0x00201210
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

			// Token: 0x04005147 RID: 20807
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x04005148 RID: 20808
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x04005149 RID: 20809
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x0400514A RID: 20810
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x0400514B RID: 20811
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
