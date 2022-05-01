using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06002380 RID: 9088 RVA: 0x001FAD4F File Offset: 0x001F8F4F
		// (set) Token: 0x06002381 RID: 9089 RVA: 0x001FAD57 File Offset: 0x001F8F57
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

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06002382 RID: 9090 RVA: 0x001FAD60 File Offset: 0x001F8F60
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002383 RID: 9091 RVA: 0x001FAD93 File Offset: 0x001F8F93
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002384 RID: 9092 RVA: 0x001FADA0 File Offset: 0x001F8FA0
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004BE5 RID: 19429
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06002788 RID: 10120 RVA: 0x002092E8 File Offset: 0x002074E8
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

			// Token: 0x040051E4 RID: 20964
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06002789 RID: 10121 RVA: 0x0020930C File Offset: 0x0020750C
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

			// Token: 0x040051E5 RID: 20965
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040051E6 RID: 20966
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040051E7 RID: 20967
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040051E8 RID: 20968
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040051E9 RID: 20969
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040051EA RID: 20970
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006C2 RID: 1730
		public enum Mode
		{
			// Token: 0x040051EC RID: 20972
			None,
			// Token: 0x040051ED RID: 20973
			Depth,
			// Token: 0x040051EE RID: 20974
			Normals,
			// Token: 0x040051EF RID: 20975
			MotionVectors,
			// Token: 0x040051F0 RID: 20976
			AmbientOcclusion,
			// Token: 0x040051F1 RID: 20977
			EyeAdaptation,
			// Token: 0x040051F2 RID: 20978
			FocusPlane,
			// Token: 0x040051F3 RID: 20979
			PreGradingLog,
			// Token: 0x040051F4 RID: 20980
			LogLut,
			// Token: 0x040051F5 RID: 20981
			UserLut
		}

		// Token: 0x020006C3 RID: 1731
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x0600278A RID: 10122 RVA: 0x00209368 File Offset: 0x00207568
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

			// Token: 0x040051F6 RID: 20982
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040051F7 RID: 20983
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040051F8 RID: 20984
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
