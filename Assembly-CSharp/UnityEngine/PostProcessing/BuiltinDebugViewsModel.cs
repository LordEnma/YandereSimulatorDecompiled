using System;

namespace UnityEngine.PostProcessing
{
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		[Serializable]
		public struct DepthSettings
		{
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;

			public static DepthSettings defaultSettings
			{
				get
				{
					DepthSettings result = default(DepthSettings);
					result.scale = 1f;
					return result;
				}
			}
		}

		[Serializable]
		public struct MotionVectorsSettings
		{
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;

			public static MotionVectorsSettings defaultSettings
			{
				get
				{
					MotionVectorsSettings result = default(MotionVectorsSettings);
					result.sourceOpacity = 1f;
					result.motionImageOpacity = 0f;
					result.motionImageAmplitude = 16f;
					result.motionVectorsOpacity = 1f;
					result.motionVectorsResolution = 24;
					result.motionVectorsAmplitude = 64f;
					return result;
				}
			}
		}

		public enum Mode
		{
			None = 0,
			Depth = 1,
			Normals = 2,
			MotionVectors = 3,
			AmbientOcclusion = 4,
			EyeAdaptation = 5,
			FocusPlane = 6,
			PreGradingLog = 7,
			LogLut = 8,
			UserLut = 9
		}

		[Serializable]
		public struct Settings
		{
			public Mode mode;

			public DepthSettings depth;

			public MotionVectorsSettings motionVectors;

			public static Settings defaultSettings
			{
				get
				{
					Settings result = default(Settings);
					result.mode = Mode.None;
					result.depth = DepthSettings.defaultSettings;
					result.motionVectors = MotionVectorsSettings.defaultSettings;
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
			}
		}

		public bool willInterrupt
		{
			get
			{
				if (!IsModeActive(Mode.None) && !IsModeActive(Mode.EyeAdaptation) && !IsModeActive(Mode.PreGradingLog) && !IsModeActive(Mode.LogLut))
				{
					return !IsModeActive(Mode.UserLut);
				}
				return false;
			}
		}

		public override void Reset()
		{
			settings = Settings.defaultSettings;
		}

		public bool IsModeActive(Mode mode)
		{
			return m_Settings.mode == mode;
		}
	}
}
