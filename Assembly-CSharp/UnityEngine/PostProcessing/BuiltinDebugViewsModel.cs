using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06002370 RID: 9072 RVA: 0x001F8E67 File Offset: 0x001F7067
		// (set) Token: 0x06002371 RID: 9073 RVA: 0x001F8E6F File Offset: 0x001F706F
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
		// (get) Token: 0x06002372 RID: 9074 RVA: 0x001F8E78 File Offset: 0x001F7078
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002373 RID: 9075 RVA: 0x001F8EAB File Offset: 0x001F70AB
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002374 RID: 9076 RVA: 0x001F8EB8 File Offset: 0x001F70B8
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004BBD RID: 19389
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002778 RID: 10104 RVA: 0x002072EC File Offset: 0x002054EC
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

			// Token: 0x040051B4 RID: 20916
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06002779 RID: 10105 RVA: 0x00207310 File Offset: 0x00205510
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

			// Token: 0x040051B5 RID: 20917
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040051B6 RID: 20918
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040051B7 RID: 20919
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040051B8 RID: 20920
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040051B9 RID: 20921
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040051BA RID: 20922
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006C1 RID: 1729
		public enum Mode
		{
			// Token: 0x040051BC RID: 20924
			None,
			// Token: 0x040051BD RID: 20925
			Depth,
			// Token: 0x040051BE RID: 20926
			Normals,
			// Token: 0x040051BF RID: 20927
			MotionVectors,
			// Token: 0x040051C0 RID: 20928
			AmbientOcclusion,
			// Token: 0x040051C1 RID: 20929
			EyeAdaptation,
			// Token: 0x040051C2 RID: 20930
			FocusPlane,
			// Token: 0x040051C3 RID: 20931
			PreGradingLog,
			// Token: 0x040051C4 RID: 20932
			LogLut,
			// Token: 0x040051C5 RID: 20933
			UserLut
		}

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x0600277A RID: 10106 RVA: 0x0020736C File Offset: 0x0020556C
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

			// Token: 0x040051C6 RID: 20934
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040051C7 RID: 20935
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040051C8 RID: 20936
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
