using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002325 RID: 8997 RVA: 0x001F31D7 File Offset: 0x001F13D7
		// (set) Token: 0x06002326 RID: 8998 RVA: 0x001F31DF File Offset: 0x001F13DF
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
		// (get) Token: 0x06002327 RID: 8999 RVA: 0x001F31E8 File Offset: 0x001F13E8
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002328 RID: 9000 RVA: 0x001F321B File Offset: 0x001F141B
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002329 RID: 9001 RVA: 0x001F3228 File Offset: 0x001F1428
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004AE9 RID: 19177
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B0 RID: 1712
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002724 RID: 10020 RVA: 0x00201444 File Offset: 0x001FF644
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

			// Token: 0x040050DB RID: 20699
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002725 RID: 10021 RVA: 0x00201468 File Offset: 0x001FF668
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

			// Token: 0x040050DC RID: 20700
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040050DD RID: 20701
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040050DE RID: 20702
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040050DF RID: 20703
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040050E0 RID: 20704
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040050E1 RID: 20705
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B2 RID: 1714
		public enum Mode
		{
			// Token: 0x040050E3 RID: 20707
			None,
			// Token: 0x040050E4 RID: 20708
			Depth,
			// Token: 0x040050E5 RID: 20709
			Normals,
			// Token: 0x040050E6 RID: 20710
			MotionVectors,
			// Token: 0x040050E7 RID: 20711
			AmbientOcclusion,
			// Token: 0x040050E8 RID: 20712
			EyeAdaptation,
			// Token: 0x040050E9 RID: 20713
			FocusPlane,
			// Token: 0x040050EA RID: 20714
			PreGradingLog,
			// Token: 0x040050EB RID: 20715
			LogLut,
			// Token: 0x040050EC RID: 20716
			UserLut
		}

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002726 RID: 10022 RVA: 0x002014C4 File Offset: 0x001FF6C4
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

			// Token: 0x040050ED RID: 20717
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040050EE RID: 20718
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040050EF RID: 20719
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
