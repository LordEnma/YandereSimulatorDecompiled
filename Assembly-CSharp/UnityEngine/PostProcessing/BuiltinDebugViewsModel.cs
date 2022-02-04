using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002327 RID: 8999 RVA: 0x001F34EF File Offset: 0x001F16EF
		// (set) Token: 0x06002328 RID: 9000 RVA: 0x001F34F7 File Offset: 0x001F16F7
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
		// (get) Token: 0x06002329 RID: 9001 RVA: 0x001F3500 File Offset: 0x001F1700
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x0600232A RID: 9002 RVA: 0x001F3533 File Offset: 0x001F1733
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x0600232B RID: 9003 RVA: 0x001F3540 File Offset: 0x001F1740
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004AEF RID: 19183
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B0 RID: 1712
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002726 RID: 10022 RVA: 0x0020175C File Offset: 0x001FF95C
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

			// Token: 0x040050E1 RID: 20705
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002727 RID: 10023 RVA: 0x00201780 File Offset: 0x001FF980
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

			// Token: 0x040050E2 RID: 20706
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040050E3 RID: 20707
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040050E4 RID: 20708
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040050E5 RID: 20709
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040050E6 RID: 20710
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040050E7 RID: 20711
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B2 RID: 1714
		public enum Mode
		{
			// Token: 0x040050E9 RID: 20713
			None,
			// Token: 0x040050EA RID: 20714
			Depth,
			// Token: 0x040050EB RID: 20715
			Normals,
			// Token: 0x040050EC RID: 20716
			MotionVectors,
			// Token: 0x040050ED RID: 20717
			AmbientOcclusion,
			// Token: 0x040050EE RID: 20718
			EyeAdaptation,
			// Token: 0x040050EF RID: 20719
			FocusPlane,
			// Token: 0x040050F0 RID: 20720
			PreGradingLog,
			// Token: 0x040050F1 RID: 20721
			LogLut,
			// Token: 0x040050F2 RID: 20722
			UserLut
		}

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002728 RID: 10024 RVA: 0x002017DC File Offset: 0x001FF9DC
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

			// Token: 0x040050F3 RID: 20723
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040050F4 RID: 20724
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040050F5 RID: 20725
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
