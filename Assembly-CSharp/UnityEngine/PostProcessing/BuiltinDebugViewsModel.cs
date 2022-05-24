using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600238C RID: 9100 RVA: 0x001FCA03 File Offset: 0x001FAC03
		// (set) Token: 0x0600238D RID: 9101 RVA: 0x001FCA0B File Offset: 0x001FAC0B
		public BuiltinDebugViewsModel.Settings settings
		{
			get
			{
				return this.m_Settings;
			}
			set
			{
				this.m_Settings = value;
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x001FCA14 File Offset: 0x001FAC14
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x0600238F RID: 9103 RVA: 0x001FCA47 File Offset: 0x001FAC47
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002390 RID: 9104 RVA: 0x001FCA54 File Offset: 0x001FAC54
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004C15 RID: 19477
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06002794 RID: 10132 RVA: 0x0020AFC4 File Offset: 0x002091C4
			public static BuiltinDebugViewsModel.DepthSettings defaultSettings
			{
				get
				{
					return new BuiltinDebugViewsModel.DepthSettings
					{
						scale = 1f
					};
				}
			}

			// Token: 0x04005214 RID: 21012
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x06002795 RID: 10133 RVA: 0x0020AFE8 File Offset: 0x002091E8
			public static BuiltinDebugViewsModel.MotionVectorsSettings defaultSettings
			{
				get
				{
					return new BuiltinDebugViewsModel.MotionVectorsSettings
					{
						sourceOpacity = 1f,
						motionImageOpacity = 0f,
						motionImageAmplitude = 16f,
						motionVectorsOpacity = 1f,
						motionVectorsResolution = 24,
						motionVectorsAmplitude = 64f
					};
				}
			}

			// Token: 0x04005215 RID: 21013
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x04005216 RID: 21014
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x04005217 RID: 21015
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x04005218 RID: 21016
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x04005219 RID: 21017
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x0400521A RID: 21018
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006C3 RID: 1731
		public enum Mode
		{
			// Token: 0x0400521C RID: 21020
			None,
			// Token: 0x0400521D RID: 21021
			Depth,
			// Token: 0x0400521E RID: 21022
			Normals,
			// Token: 0x0400521F RID: 21023
			MotionVectors,
			// Token: 0x04005220 RID: 21024
			AmbientOcclusion,
			// Token: 0x04005221 RID: 21025
			EyeAdaptation,
			// Token: 0x04005222 RID: 21026
			FocusPlane,
			// Token: 0x04005223 RID: 21027
			PreGradingLog,
			// Token: 0x04005224 RID: 21028
			LogLut,
			// Token: 0x04005225 RID: 21029
			UserLut
		}

		// Token: 0x020006C4 RID: 1732
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x06002796 RID: 10134 RVA: 0x0020B044 File Offset: 0x00209244
			public static BuiltinDebugViewsModel.Settings defaultSettings
			{
				get
				{
					return new BuiltinDebugViewsModel.Settings
					{
						mode = BuiltinDebugViewsModel.Mode.None,
						depth = BuiltinDebugViewsModel.DepthSettings.defaultSettings,
						motionVectors = BuiltinDebugViewsModel.MotionVectorsSettings.defaultSettings
					};
				}
			}

			// Token: 0x04005226 RID: 21030
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x04005227 RID: 21031
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x04005228 RID: 21032
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
