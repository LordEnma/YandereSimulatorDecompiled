using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000561 RID: 1377
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002314 RID: 8980 RVA: 0x001F12C7 File Offset: 0x001EF4C7
		// (set) Token: 0x06002315 RID: 8981 RVA: 0x001F12CF File Offset: 0x001EF4CF
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
		// (get) Token: 0x06002316 RID: 8982 RVA: 0x001F12D8 File Offset: 0x001EF4D8
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002317 RID: 8983 RVA: 0x001F130B File Offset: 0x001EF50B
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002318 RID: 8984 RVA: 0x001F1318 File Offset: 0x001EF518
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004AC3 RID: 19139
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002727 RID: 10023 RVA: 0x001FFC18 File Offset: 0x001FDE18
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

			// Token: 0x040050E3 RID: 20707
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002728 RID: 10024 RVA: 0x001FFC3C File Offset: 0x001FDE3C
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

			// Token: 0x040050E4 RID: 20708
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040050E5 RID: 20709
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040050E6 RID: 20710
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040050E7 RID: 20711
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040050E8 RID: 20712
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040050E9 RID: 20713
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B5 RID: 1717
		public enum Mode
		{
			// Token: 0x040050EB RID: 20715
			None,
			// Token: 0x040050EC RID: 20716
			Depth,
			// Token: 0x040050ED RID: 20717
			Normals,
			// Token: 0x040050EE RID: 20718
			MotionVectors,
			// Token: 0x040050EF RID: 20719
			AmbientOcclusion,
			// Token: 0x040050F0 RID: 20720
			EyeAdaptation,
			// Token: 0x040050F1 RID: 20721
			FocusPlane,
			// Token: 0x040050F2 RID: 20722
			PreGradingLog,
			// Token: 0x040050F3 RID: 20723
			LogLut,
			// Token: 0x040050F4 RID: 20724
			UserLut
		}

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002729 RID: 10025 RVA: 0x001FFC98 File Offset: 0x001FDE98
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

			// Token: 0x040050F5 RID: 20725
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040050F6 RID: 20726
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040050F7 RID: 20727
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
