using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002362 RID: 9058 RVA: 0x001F716C File Offset: 0x001F536C
		// (set) Token: 0x06002363 RID: 9059 RVA: 0x001F7174 File Offset: 0x001F5374
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
		// (get) Token: 0x06002364 RID: 9060 RVA: 0x001F7183 File Offset: 0x001F5383
		// (set) Token: 0x06002365 RID: 9061 RVA: 0x001F718B File Offset: 0x001F538B
		public bool isDirty { get; internal set; }

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002366 RID: 9062 RVA: 0x001F7194 File Offset: 0x001F5394
		// (set) Token: 0x06002367 RID: 9063 RVA: 0x001F719C File Offset: 0x001F539C
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002368 RID: 9064 RVA: 0x001F71A5 File Offset: 0x001F53A5
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002369 RID: 9065 RVA: 0x001F71B8 File Offset: 0x001F53B8
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004B89 RID: 19337
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006BE RID: 1726
		public enum Tonemapper
		{
			// Token: 0x04005196 RID: 20886
			None,
			// Token: 0x04005197 RID: 20887
			ACES,
			// Token: 0x04005198 RID: 20888
			Neutral
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x06002764 RID: 10084 RVA: 0x002054E0 File Offset: 0x002036E0
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

			// Token: 0x04005199 RID: 20889
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x0400519A RID: 20890
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x0400519B RID: 20891
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x0400519C RID: 20892
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x0400519D RID: 20893
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x0400519E RID: 20894
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x0400519F RID: 20895
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x06002765 RID: 10085 RVA: 0x00205548 File Offset: 0x00203748
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

			// Token: 0x040051A0 RID: 20896
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x040051A1 RID: 20897
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x040051A2 RID: 20898
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x040051A3 RID: 20899
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x040051A4 RID: 20900
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x040051A5 RID: 20901
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x06002766 RID: 10086 RVA: 0x002055A8 File Offset: 0x002037A8
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

			// Token: 0x040051A6 RID: 20902
			public Vector3 red;

			// Token: 0x040051A7 RID: 20903
			public Vector3 green;

			// Token: 0x040051A8 RID: 20904
			public Vector3 blue;

			// Token: 0x040051A9 RID: 20905
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002767 RID: 10087 RVA: 0x00205618 File Offset: 0x00203818
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

			// Token: 0x040051AA RID: 20906
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x040051AB RID: 20907
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x040051AC RID: 20908
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006C3 RID: 1731
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002768 RID: 10088 RVA: 0x00205654 File Offset: 0x00203854
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

			// Token: 0x040051AD RID: 20909
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x040051AE RID: 20910
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x040051AF RID: 20911
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006C4 RID: 1732
		public enum ColorWheelMode
		{
			// Token: 0x040051B1 RID: 20913
			Linear,
			// Token: 0x040051B2 RID: 20914
			Log
		}

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002769 RID: 10089 RVA: 0x00205690 File Offset: 0x00203890
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

			// Token: 0x040051B3 RID: 20915
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x040051B4 RID: 20916
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x040051B5 RID: 20917
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x0600276A RID: 10090 RVA: 0x002056C8 File Offset: 0x002038C8
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

			// Token: 0x040051B6 RID: 20918
			public ColorGradingCurve master;

			// Token: 0x040051B7 RID: 20919
			public ColorGradingCurve red;

			// Token: 0x040051B8 RID: 20920
			public ColorGradingCurve green;

			// Token: 0x040051B9 RID: 20921
			public ColorGradingCurve blue;

			// Token: 0x040051BA RID: 20922
			public ColorGradingCurve hueVShue;

			// Token: 0x040051BB RID: 20923
			public ColorGradingCurve hueVSsat;

			// Token: 0x040051BC RID: 20924
			public ColorGradingCurve satVSsat;

			// Token: 0x040051BD RID: 20925
			public ColorGradingCurve lumVSsat;

			// Token: 0x040051BE RID: 20926
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x040051BF RID: 20927
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x040051C0 RID: 20928
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x040051C1 RID: 20929
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x040051C2 RID: 20930
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x0600276B RID: 10091 RVA: 0x00205950 File Offset: 0x00203B50
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

			// Token: 0x040051C3 RID: 20931
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x040051C4 RID: 20932
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x040051C5 RID: 20933
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x040051C6 RID: 20934
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x040051C7 RID: 20935
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
