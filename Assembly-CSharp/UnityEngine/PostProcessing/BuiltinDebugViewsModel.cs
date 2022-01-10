using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x0600231F RID: 8991 RVA: 0x001F1C67 File Offset: 0x001EFE67
		// (set) Token: 0x06002320 RID: 8992 RVA: 0x001F1C6F File Offset: 0x001EFE6F
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

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06002321 RID: 8993 RVA: 0x001F1C78 File Offset: 0x001EFE78
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002322 RID: 8994 RVA: 0x001F1CAB File Offset: 0x001EFEAB
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002323 RID: 8995 RVA: 0x001F1CB8 File Offset: 0x001EFEB8
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004AD7 RID: 19159
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B5 RID: 1717
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002732 RID: 10034 RVA: 0x002005B8 File Offset: 0x001FE7B8
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

			// Token: 0x040050F7 RID: 20727
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002733 RID: 10035 RVA: 0x002005DC File Offset: 0x001FE7DC
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

			// Token: 0x040050F8 RID: 20728
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040050F9 RID: 20729
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040050FA RID: 20730
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040050FB RID: 20731
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040050FC RID: 20732
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040050FD RID: 20733
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B7 RID: 1719
		public enum Mode
		{
			// Token: 0x040050FF RID: 20735
			None,
			// Token: 0x04005100 RID: 20736
			Depth,
			// Token: 0x04005101 RID: 20737
			Normals,
			// Token: 0x04005102 RID: 20738
			MotionVectors,
			// Token: 0x04005103 RID: 20739
			AmbientOcclusion,
			// Token: 0x04005104 RID: 20740
			EyeAdaptation,
			// Token: 0x04005105 RID: 20741
			FocusPlane,
			// Token: 0x04005106 RID: 20742
			PreGradingLog,
			// Token: 0x04005107 RID: 20743
			LogLut,
			// Token: 0x04005108 RID: 20744
			UserLut
		}

		// Token: 0x020006B8 RID: 1720
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002734 RID: 10036 RVA: 0x00200638 File Offset: 0x001FE838
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

			// Token: 0x04005109 RID: 20745
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x0400510A RID: 20746
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x0400510B RID: 20747
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
