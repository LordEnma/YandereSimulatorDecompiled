using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002372 RID: 9074 RVA: 0x001F89DC File Offset: 0x001F6BDC
		// (set) Token: 0x06002373 RID: 9075 RVA: 0x001F89E4 File Offset: 0x001F6BE4
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
		// (get) Token: 0x06002374 RID: 9076 RVA: 0x001F89F3 File Offset: 0x001F6BF3
		// (set) Token: 0x06002375 RID: 9077 RVA: 0x001F89FB File Offset: 0x001F6BFB
		public bool isDirty { get; internal set; }

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002376 RID: 9078 RVA: 0x001F8A04 File Offset: 0x001F6C04
		// (set) Token: 0x06002377 RID: 9079 RVA: 0x001F8A0C File Offset: 0x001F6C0C
		public RenderTexture bakedLut { get; internal set; }

		// Token: 0x06002378 RID: 9080 RVA: 0x001F8A15 File Offset: 0x001F6C15
		public override void Reset()
		{
			this.m_Settings = ColorGradingModel.Settings.defaultSettings;
			this.OnValidate();
		}

		// Token: 0x06002379 RID: 9081 RVA: 0x001F8A28 File Offset: 0x001F6C28
		public override void OnValidate()
		{
			this.isDirty = true;
		}

		// Token: 0x04004BBB RID: 19387
		[SerializeField]
		private ColorGradingModel.Settings m_Settings = ColorGradingModel.Settings.defaultSettings;

		// Token: 0x020006C3 RID: 1731
		public enum Tonemapper
		{
			// Token: 0x040051C8 RID: 20936
			None,
			// Token: 0x040051C9 RID: 20937
			ACES,
			// Token: 0x040051CA RID: 20938
			Neutral
		}

		// Token: 0x020006C4 RID: 1732
		[Serializable]
		public struct TonemappingSettings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x06002774 RID: 10100 RVA: 0x00206EA0 File Offset: 0x002050A0
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

			// Token: 0x040051CB RID: 20939
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public ColorGradingModel.Tonemapper tonemapper;

			// Token: 0x040051CC RID: 20940
			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			// Token: 0x040051CD RID: 20941
			[Range(1f, 20f)]
			public float neutralWhiteIn;

			// Token: 0x040051CE RID: 20942
			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			// Token: 0x040051CF RID: 20943
			[Range(1f, 19f)]
			public float neutralWhiteOut;

			// Token: 0x040051D0 RID: 20944
			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			// Token: 0x040051D1 RID: 20945
			[Range(1f, 10f)]
			public float neutralWhiteClip;
		}

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct BasicSettings
		{
			// Token: 0x17000599 RID: 1433
			// (get) Token: 0x06002775 RID: 10101 RVA: 0x00206F08 File Offset: 0x00205108
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

			// Token: 0x040051D2 RID: 20946
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			// Token: 0x040051D3 RID: 20947
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			// Token: 0x040051D4 RID: 20948
			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			// Token: 0x040051D5 RID: 20949
			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			// Token: 0x040051D6 RID: 20950
			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			// Token: 0x040051D7 RID: 20951
			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;
		}

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct ChannelMixerSettings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x06002776 RID: 10102 RVA: 0x00206F68 File Offset: 0x00205168
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

			// Token: 0x040051D8 RID: 20952
			public Vector3 red;

			// Token: 0x040051D9 RID: 20953
			public Vector3 green;

			// Token: 0x040051DA RID: 20954
			public Vector3 blue;

			// Token: 0x040051DB RID: 20955
			[HideInInspector]
			public int currentEditingChannel;
		}

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct LogWheelsSettings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002777 RID: 10103 RVA: 0x00206FD8 File Offset: 0x002051D8
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

			// Token: 0x040051DC RID: 20956
			[Trackball("GetSlopeValue")]
			public Color slope;

			// Token: 0x040051DD RID: 20957
			[Trackball("GetPowerValue")]
			public Color power;

			// Token: 0x040051DE RID: 20958
			[Trackball("GetOffsetValue")]
			public Color offset;
		}

		// Token: 0x020006C8 RID: 1736
		[Serializable]
		public struct LinearWheelsSettings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002778 RID: 10104 RVA: 0x00207014 File Offset: 0x00205214
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

			// Token: 0x040051DF RID: 20959
			[Trackball("GetLiftValue")]
			public Color lift;

			// Token: 0x040051E0 RID: 20960
			[Trackball("GetGammaValue")]
			public Color gamma;

			// Token: 0x040051E1 RID: 20961
			[Trackball("GetGainValue")]
			public Color gain;
		}

		// Token: 0x020006C9 RID: 1737
		public enum ColorWheelMode
		{
			// Token: 0x040051E3 RID: 20963
			Linear,
			// Token: 0x040051E4 RID: 20964
			Log
		}

		// Token: 0x020006CA RID: 1738
		[Serializable]
		public struct ColorWheelsSettings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002779 RID: 10105 RVA: 0x00207050 File Offset: 0x00205250
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

			// Token: 0x040051E5 RID: 20965
			public ColorGradingModel.ColorWheelMode mode;

			// Token: 0x040051E6 RID: 20966
			[TrackballGroup]
			public ColorGradingModel.LogWheelsSettings log;

			// Token: 0x040051E7 RID: 20967
			[TrackballGroup]
			public ColorGradingModel.LinearWheelsSettings linear;
		}

		// Token: 0x020006CB RID: 1739
		[Serializable]
		public struct CurvesSettings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x0600277A RID: 10106 RVA: 0x00207088 File Offset: 0x00205288
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

			// Token: 0x040051E8 RID: 20968
			public ColorGradingCurve master;

			// Token: 0x040051E9 RID: 20969
			public ColorGradingCurve red;

			// Token: 0x040051EA RID: 20970
			public ColorGradingCurve green;

			// Token: 0x040051EB RID: 20971
			public ColorGradingCurve blue;

			// Token: 0x040051EC RID: 20972
			public ColorGradingCurve hueVShue;

			// Token: 0x040051ED RID: 20973
			public ColorGradingCurve hueVSsat;

			// Token: 0x040051EE RID: 20974
			public ColorGradingCurve satVSsat;

			// Token: 0x040051EF RID: 20975
			public ColorGradingCurve lumVSsat;

			// Token: 0x040051F0 RID: 20976
			[HideInInspector]
			public int e_CurrentEditingCurve;

			// Token: 0x040051F1 RID: 20977
			[HideInInspector]
			public bool e_CurveY;

			// Token: 0x040051F2 RID: 20978
			[HideInInspector]
			public bool e_CurveR;

			// Token: 0x040051F3 RID: 20979
			[HideInInspector]
			public bool e_CurveG;

			// Token: 0x040051F4 RID: 20980
			[HideInInspector]
			public bool e_CurveB;
		}

		// Token: 0x020006CC RID: 1740
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x0600277B RID: 10107 RVA: 0x00207310 File Offset: 0x00205510
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

			// Token: 0x040051F5 RID: 20981
			public ColorGradingModel.TonemappingSettings tonemapping;

			// Token: 0x040051F6 RID: 20982
			public ColorGradingModel.BasicSettings basic;

			// Token: 0x040051F7 RID: 20983
			public ColorGradingModel.ChannelMixerSettings channelMixer;

			// Token: 0x040051F8 RID: 20984
			public ColorGradingModel.ColorWheelsSettings colorWheels;

			// Token: 0x040051F9 RID: 20985
			public ColorGradingModel.CurvesSettings curves;
		}
	}
}
