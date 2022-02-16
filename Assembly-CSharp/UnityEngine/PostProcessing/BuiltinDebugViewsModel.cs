using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06002331 RID: 9009 RVA: 0x001F3BA7 File Offset: 0x001F1DA7
		// (set) Token: 0x06002332 RID: 9010 RVA: 0x001F3BAF File Offset: 0x001F1DAF
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
		// (get) Token: 0x06002333 RID: 9011 RVA: 0x001F3BB8 File Offset: 0x001F1DB8
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002334 RID: 9012 RVA: 0x001F3BEB File Offset: 0x001F1DEB
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002335 RID: 9013 RVA: 0x001F3BF8 File Offset: 0x001F1DF8
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004AFB RID: 19195
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002730 RID: 10032 RVA: 0x00201E14 File Offset: 0x00200014
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

			// Token: 0x040050ED RID: 20717
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B2 RID: 1714
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002731 RID: 10033 RVA: 0x00201E38 File Offset: 0x00200038
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

			// Token: 0x040050EE RID: 20718
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040050EF RID: 20719
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040050F0 RID: 20720
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040050F1 RID: 20721
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040050F2 RID: 20722
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040050F3 RID: 20723
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B3 RID: 1715
		public enum Mode
		{
			// Token: 0x040050F5 RID: 20725
			None,
			// Token: 0x040050F6 RID: 20726
			Depth,
			// Token: 0x040050F7 RID: 20727
			Normals,
			// Token: 0x040050F8 RID: 20728
			MotionVectors,
			// Token: 0x040050F9 RID: 20729
			AmbientOcclusion,
			// Token: 0x040050FA RID: 20730
			EyeAdaptation,
			// Token: 0x040050FB RID: 20731
			FocusPlane,
			// Token: 0x040050FC RID: 20732
			PreGradingLog,
			// Token: 0x040050FD RID: 20733
			LogLut,
			// Token: 0x040050FE RID: 20734
			UserLut
		}

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002732 RID: 10034 RVA: 0x00201E94 File Offset: 0x00200094
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

			// Token: 0x040050FF RID: 20735
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x04005100 RID: 20736
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x04005101 RID: 20737
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
