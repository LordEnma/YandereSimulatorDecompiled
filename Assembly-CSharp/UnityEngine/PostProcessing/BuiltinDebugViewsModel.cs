using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x0600233A RID: 9018 RVA: 0x001F4787 File Offset: 0x001F2987
		// (set) Token: 0x0600233B RID: 9019 RVA: 0x001F478F File Offset: 0x001F298F
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

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x0600233C RID: 9020 RVA: 0x001F4798 File Offset: 0x001F2998
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x0600233D RID: 9021 RVA: 0x001F47CB File Offset: 0x001F29CB
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x0600233E RID: 9022 RVA: 0x001F47D8 File Offset: 0x001F29D8
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004B0B RID: 19211
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002742 RID: 10050 RVA: 0x00202ABC File Offset: 0x00200CBC
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

			// Token: 0x04005102 RID: 20738
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B5 RID: 1717
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002743 RID: 10051 RVA: 0x00202AE0 File Offset: 0x00200CE0
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

			// Token: 0x04005103 RID: 20739
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x04005104 RID: 20740
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x04005105 RID: 20741
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x04005106 RID: 20742
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x04005107 RID: 20743
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x04005108 RID: 20744
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B6 RID: 1718
		public enum Mode
		{
			// Token: 0x0400510A RID: 20746
			None,
			// Token: 0x0400510B RID: 20747
			Depth,
			// Token: 0x0400510C RID: 20748
			Normals,
			// Token: 0x0400510D RID: 20749
			MotionVectors,
			// Token: 0x0400510E RID: 20750
			AmbientOcclusion,
			// Token: 0x0400510F RID: 20751
			EyeAdaptation,
			// Token: 0x04005110 RID: 20752
			FocusPlane,
			// Token: 0x04005111 RID: 20753
			PreGradingLog,
			// Token: 0x04005112 RID: 20754
			LogLut,
			// Token: 0x04005113 RID: 20755
			UserLut
		}

		// Token: 0x020006B7 RID: 1719
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06002744 RID: 10052 RVA: 0x00202B3C File Offset: 0x00200D3C
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

			// Token: 0x04005114 RID: 20756
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x04005115 RID: 20757
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x04005116 RID: 20758
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
