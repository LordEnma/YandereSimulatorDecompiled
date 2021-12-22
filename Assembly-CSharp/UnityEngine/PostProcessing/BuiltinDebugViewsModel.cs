using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000561 RID: 1377
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002311 RID: 8977 RVA: 0x001F0CD7 File Offset: 0x001EEED7
		// (set) Token: 0x06002312 RID: 8978 RVA: 0x001F0CDF File Offset: 0x001EEEDF
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

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002313 RID: 8979 RVA: 0x001F0CE8 File Offset: 0x001EEEE8
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002314 RID: 8980 RVA: 0x001F0D1B File Offset: 0x001EEF1B
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002315 RID: 8981 RVA: 0x001F0D28 File Offset: 0x001EEF28
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004ABA RID: 19130
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002724 RID: 10020 RVA: 0x001FF604 File Offset: 0x001FD804
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

			// Token: 0x040050DA RID: 20698
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002725 RID: 10021 RVA: 0x001FF628 File Offset: 0x001FD828
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

			// Token: 0x040050DB RID: 20699
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040050DC RID: 20700
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040050DD RID: 20701
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040050DE RID: 20702
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040050DF RID: 20703
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040050E0 RID: 20704
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B5 RID: 1717
		public enum Mode
		{
			// Token: 0x040050E2 RID: 20706
			None,
			// Token: 0x040050E3 RID: 20707
			Depth,
			// Token: 0x040050E4 RID: 20708
			Normals,
			// Token: 0x040050E5 RID: 20709
			MotionVectors,
			// Token: 0x040050E6 RID: 20710
			AmbientOcclusion,
			// Token: 0x040050E7 RID: 20711
			EyeAdaptation,
			// Token: 0x040050E8 RID: 20712
			FocusPlane,
			// Token: 0x040050E9 RID: 20713
			PreGradingLog,
			// Token: 0x040050EA RID: 20714
			LogLut,
			// Token: 0x040050EB RID: 20715
			UserLut
		}

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002726 RID: 10022 RVA: 0x001FF684 File Offset: 0x001FD884
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

			// Token: 0x040050EC RID: 20716
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040050ED RID: 20717
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040050EE RID: 20718
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
