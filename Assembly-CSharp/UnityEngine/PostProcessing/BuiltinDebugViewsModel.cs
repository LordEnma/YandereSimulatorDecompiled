using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055F RID: 1375
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002300 RID: 8960 RVA: 0x001EF5A3 File Offset: 0x001ED7A3
		// (set) Token: 0x06002301 RID: 8961 RVA: 0x001EF5AB File Offset: 0x001ED7AB
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
		// (get) Token: 0x06002302 RID: 8962 RVA: 0x001EF5B4 File Offset: 0x001ED7B4
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002303 RID: 8963 RVA: 0x001EF5E7 File Offset: 0x001ED7E7
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002304 RID: 8964 RVA: 0x001EF5F4 File Offset: 0x001ED7F4
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004A7B RID: 19067
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B0 RID: 1712
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002713 RID: 10003 RVA: 0x001FDED0 File Offset: 0x001FC0D0
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

			// Token: 0x0400508F RID: 20623
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002714 RID: 10004 RVA: 0x001FDEF4 File Offset: 0x001FC0F4
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

			// Token: 0x04005090 RID: 20624
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x04005091 RID: 20625
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x04005092 RID: 20626
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x04005093 RID: 20627
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x04005094 RID: 20628
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x04005095 RID: 20629
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B2 RID: 1714
		public enum Mode
		{
			// Token: 0x04005097 RID: 20631
			None,
			// Token: 0x04005098 RID: 20632
			Depth,
			// Token: 0x04005099 RID: 20633
			Normals,
			// Token: 0x0400509A RID: 20634
			MotionVectors,
			// Token: 0x0400509B RID: 20635
			AmbientOcclusion,
			// Token: 0x0400509C RID: 20636
			EyeAdaptation,
			// Token: 0x0400509D RID: 20637
			FocusPlane,
			// Token: 0x0400509E RID: 20638
			PreGradingLog,
			// Token: 0x0400509F RID: 20639
			LogLut,
			// Token: 0x040050A0 RID: 20640
			UserLut
		}

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002715 RID: 10005 RVA: 0x001FDF50 File Offset: 0x001FC150
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

			// Token: 0x040050A1 RID: 20641
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040050A2 RID: 20642
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040050A3 RID: 20643
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
