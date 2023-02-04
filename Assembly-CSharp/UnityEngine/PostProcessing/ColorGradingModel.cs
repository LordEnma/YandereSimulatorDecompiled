using System;

namespace UnityEngine.PostProcessing
{
	[Serializable]
	public class ColorGradingModel : PostProcessingModel
	{
		public enum Tonemapper
		{
			None = 0,
			ACES = 1,
			Neutral = 2
		}

		[Serializable]
		public struct TonemappingSettings
		{
			[Tooltip("Tonemapping algorithm to use at the end of the color grading process. Use \"Neutral\" if you need a customizable tonemapper or \"Filmic\" to give a standard filmic look to your scenes.")]
			public Tonemapper tonemapper;

			[Range(-0.1f, 0.1f)]
			public float neutralBlackIn;

			[Range(1f, 20f)]
			public float neutralWhiteIn;

			[Range(-0.09f, 0.1f)]
			public float neutralBlackOut;

			[Range(1f, 19f)]
			public float neutralWhiteOut;

			[Range(0.1f, 20f)]
			public float neutralWhiteLevel;

			[Range(1f, 10f)]
			public float neutralWhiteClip;

			public static TonemappingSettings defaultSettings
			{
				get
				{
					TonemappingSettings result = default(TonemappingSettings);
					result.tonemapper = Tonemapper.Neutral;
					result.neutralBlackIn = 0.02f;
					result.neutralWhiteIn = 10f;
					result.neutralBlackOut = 0f;
					result.neutralWhiteOut = 10f;
					result.neutralWhiteLevel = 5.3f;
					result.neutralWhiteClip = 10f;
					return result;
				}
			}
		}

		[Serializable]
		public struct BasicSettings
		{
			[Tooltip("Adjusts the overall exposure of the scene in EV units. This is applied after HDR effect and right before tonemapping so it won't affect previous effects in the chain.")]
			public float postExposure;

			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to a custom color temperature.")]
			public float temperature;

			[Range(-100f, 100f)]
			[Tooltip("Sets the white balance to compensate for a green or magenta tint.")]
			public float tint;

			[Range(-180f, 180f)]
			[Tooltip("Shift the hue of all colors.")]
			public float hueShift;

			[Range(0f, 2f)]
			[Tooltip("Pushes the intensity of all colors.")]
			public float saturation;

			[Range(0f, 2f)]
			[Tooltip("Expands or shrinks the overall range of tonal values.")]
			public float contrast;

			public static BasicSettings defaultSettings
			{
				get
				{
					BasicSettings result = default(BasicSettings);
					result.postExposure = 0f;
					result.temperature = 0f;
					result.tint = 0f;
					result.hueShift = 0f;
					result.saturation = 1f;
					result.contrast = 1f;
					return result;
				}
			}
		}

		[Serializable]
		public struct ChannelMixerSettings
		{
			public Vector3 red;

			public Vector3 green;

			public Vector3 blue;

			[HideInInspector]
			public int currentEditingChannel;

			public static ChannelMixerSettings defaultSettings
			{
				get
				{
					ChannelMixerSettings result = default(ChannelMixerSettings);
					result.red = new Vector3(1f, 0f, 0f);
					result.green = new Vector3(0f, 1f, 0f);
					result.blue = new Vector3(0f, 0f, 1f);
					result.currentEditingChannel = 0;
					return result;
				}
			}
		}

		[Serializable]
		public struct LogWheelsSettings
		{
			[Trackball("GetSlopeValue")]
			public Color slope;

			[Trackball("GetPowerValue")]
			public Color power;

			[Trackball("GetOffsetValue")]
			public Color offset;

			public static LogWheelsSettings defaultSettings
			{
				get
				{
					LogWheelsSettings result = default(LogWheelsSettings);
					result.slope = Color.clear;
					result.power = Color.clear;
					result.offset = Color.clear;
					return result;
				}
			}
		}

		[Serializable]
		public struct LinearWheelsSettings
		{
			[Trackball("GetLiftValue")]
			public Color lift;

			[Trackball("GetGammaValue")]
			public Color gamma;

			[Trackball("GetGainValue")]
			public Color gain;

			public static LinearWheelsSettings defaultSettings
			{
				get
				{
					LinearWheelsSettings result = default(LinearWheelsSettings);
					result.lift = Color.clear;
					result.gamma = Color.clear;
					result.gain = Color.clear;
					return result;
				}
			}
		}

		public enum ColorWheelMode
		{
			Linear = 0,
			Log = 1
		}

		[Serializable]
		public struct ColorWheelsSettings
		{
			public ColorWheelMode mode;

			[TrackballGroup]
			public LogWheelsSettings log;

			[TrackballGroup]
			public LinearWheelsSettings linear;

			public static ColorWheelsSettings defaultSettings
			{
				get
				{
					ColorWheelsSettings result = default(ColorWheelsSettings);
					result.mode = ColorWheelMode.Log;
					result.log = LogWheelsSettings.defaultSettings;
					result.linear = LinearWheelsSettings.defaultSettings;
					return result;
				}
			}
		}

		[Serializable]
		public struct CurvesSettings
		{
			public ColorGradingCurve master;

			public ColorGradingCurve red;

			public ColorGradingCurve green;

			public ColorGradingCurve blue;

			public ColorGradingCurve hueVShue;

			public ColorGradingCurve hueVSsat;

			public ColorGradingCurve satVSsat;

			public ColorGradingCurve lumVSsat;

			[HideInInspector]
			public int e_CurrentEditingCurve;

			[HideInInspector]
			public bool e_CurveY;

			[HideInInspector]
			public bool e_CurveR;

			[HideInInspector]
			public bool e_CurveG;

			[HideInInspector]
			public bool e_CurveB;

			public static CurvesSettings defaultSettings
			{
				get
				{
					CurvesSettings result = default(CurvesSettings);
					result.master = new ColorGradingCurve(new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f)), 0f, loop: false, new Vector2(0f, 1f));
					result.red = new ColorGradingCurve(new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f)), 0f, loop: false, new Vector2(0f, 1f));
					result.green = new ColorGradingCurve(new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f)), 0f, loop: false, new Vector2(0f, 1f));
					result.blue = new ColorGradingCurve(new AnimationCurve(new Keyframe(0f, 0f, 1f, 1f), new Keyframe(1f, 1f, 1f, 1f)), 0f, loop: false, new Vector2(0f, 1f));
					result.hueVShue = new ColorGradingCurve(new AnimationCurve(), 0.5f, loop: true, new Vector2(0f, 1f));
					result.hueVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, loop: true, new Vector2(0f, 1f));
					result.satVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, loop: false, new Vector2(0f, 1f));
					result.lumVSsat = new ColorGradingCurve(new AnimationCurve(), 0.5f, loop: false, new Vector2(0f, 1f));
					result.e_CurrentEditingCurve = 0;
					result.e_CurveY = true;
					result.e_CurveR = false;
					result.e_CurveG = false;
					result.e_CurveB = false;
					return result;
				}
			}
		}

		[Serializable]
		public struct Settings
		{
			public TonemappingSettings tonemapping;

			public BasicSettings basic;

			public ChannelMixerSettings channelMixer;

			public ColorWheelsSettings colorWheels;

			public CurvesSettings curves;

			public static Settings defaultSettings
			{
				get
				{
					Settings result = default(Settings);
					result.tonemapping = TonemappingSettings.defaultSettings;
					result.basic = BasicSettings.defaultSettings;
					result.channelMixer = ChannelMixerSettings.defaultSettings;
					result.colorWheels = ColorWheelsSettings.defaultSettings;
					result.curves = CurvesSettings.defaultSettings;
					return result;
				}
			}
		}

		[SerializeField]
		private Settings m_Settings = Settings.defaultSettings;

		public Settings settings
		{
			get
			{
				return m_Settings;
			}
			set
			{
				m_Settings = value;
				OnValidate();
			}
		}

		public bool isDirty { get; internal set; }

		public RenderTexture bakedLut { get; internal set; }

		public override void Reset()
		{
			m_Settings = Settings.defaultSettings;
			OnValidate();
		}

		public override void OnValidate()
		{
			isDirty = true;
		}
	}
}
