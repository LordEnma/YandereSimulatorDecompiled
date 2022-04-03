using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06002368 RID: 9064 RVA: 0x001F8937 File Offset: 0x001F6B37
		// (set) Token: 0x06002369 RID: 9065 RVA: 0x001F893F File Offset: 0x001F6B3F
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

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x0600236A RID: 9066 RVA: 0x001F8948 File Offset: 0x001F6B48
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x0600236B RID: 9067 RVA: 0x001F897B File Offset: 0x001F6B7B
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x0600236C RID: 9068 RVA: 0x001F8988 File Offset: 0x001F6B88
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004BB9 RID: 19385
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002770 RID: 10096 RVA: 0x00206DBC File Offset: 0x00204FBC
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

			// Token: 0x040051B0 RID: 20912
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06002771 RID: 10097 RVA: 0x00206DE0 File Offset: 0x00204FE0
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

			// Token: 0x040051B1 RID: 20913
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040051B2 RID: 20914
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040051B3 RID: 20915
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040051B4 RID: 20916
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040051B5 RID: 20917
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040051B6 RID: 20918
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006C0 RID: 1728
		public enum Mode
		{
			// Token: 0x040051B8 RID: 20920
			None,
			// Token: 0x040051B9 RID: 20921
			Depth,
			// Token: 0x040051BA RID: 20922
			Normals,
			// Token: 0x040051BB RID: 20923
			MotionVectors,
			// Token: 0x040051BC RID: 20924
			AmbientOcclusion,
			// Token: 0x040051BD RID: 20925
			EyeAdaptation,
			// Token: 0x040051BE RID: 20926
			FocusPlane,
			// Token: 0x040051BF RID: 20927
			PreGradingLog,
			// Token: 0x040051C0 RID: 20928
			LogLut,
			// Token: 0x040051C1 RID: 20929
			UserLut
		}

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06002772 RID: 10098 RVA: 0x00206E3C File Offset: 0x0020503C
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

			// Token: 0x040051C2 RID: 20930
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040051C3 RID: 20931
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040051C4 RID: 20932
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
