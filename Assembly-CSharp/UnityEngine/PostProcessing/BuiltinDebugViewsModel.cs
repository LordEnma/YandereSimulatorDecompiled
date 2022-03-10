using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06002340 RID: 9024 RVA: 0x001F515F File Offset: 0x001F335F
		// (set) Token: 0x06002341 RID: 9025 RVA: 0x001F5167 File Offset: 0x001F3367
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
		// (get) Token: 0x06002342 RID: 9026 RVA: 0x001F5170 File Offset: 0x001F3370
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002343 RID: 9027 RVA: 0x001F51A3 File Offset: 0x001F33A3
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002344 RID: 9028 RVA: 0x001F51B0 File Offset: 0x001F33B0
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004B28 RID: 19240
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B5 RID: 1717
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002748 RID: 10056 RVA: 0x00203494 File Offset: 0x00201694
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

			// Token: 0x0400511F RID: 20767
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002749 RID: 10057 RVA: 0x002034B8 File Offset: 0x002016B8
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

			// Token: 0x04005120 RID: 20768
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x04005121 RID: 20769
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x04005122 RID: 20770
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x04005123 RID: 20771
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x04005124 RID: 20772
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x04005125 RID: 20773
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B7 RID: 1719
		public enum Mode
		{
			// Token: 0x04005127 RID: 20775
			None,
			// Token: 0x04005128 RID: 20776
			Depth,
			// Token: 0x04005129 RID: 20777
			Normals,
			// Token: 0x0400512A RID: 20778
			MotionVectors,
			// Token: 0x0400512B RID: 20779
			AmbientOcclusion,
			// Token: 0x0400512C RID: 20780
			EyeAdaptation,
			// Token: 0x0400512D RID: 20781
			FocusPlane,
			// Token: 0x0400512E RID: 20782
			PreGradingLog,
			// Token: 0x0400512F RID: 20783
			LogLut,
			// Token: 0x04005130 RID: 20784
			UserLut
		}

		// Token: 0x020006B8 RID: 1720
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x0600274A RID: 10058 RVA: 0x00203514 File Offset: 0x00201714
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

			// Token: 0x04005131 RID: 20785
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x04005132 RID: 20786
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x04005133 RID: 20787
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
