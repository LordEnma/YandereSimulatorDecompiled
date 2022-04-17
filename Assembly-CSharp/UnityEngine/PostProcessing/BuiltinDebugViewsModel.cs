using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06002377 RID: 9079 RVA: 0x001F98C3 File Offset: 0x001F7AC3
		// (set) Token: 0x06002378 RID: 9080 RVA: 0x001F98CB File Offset: 0x001F7ACB
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
		// (get) Token: 0x06002379 RID: 9081 RVA: 0x001F98D4 File Offset: 0x001F7AD4
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x0600237A RID: 9082 RVA: 0x001F9907 File Offset: 0x001F7B07
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x0600237B RID: 9083 RVA: 0x001F9914 File Offset: 0x001F7B14
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004BCF RID: 19407
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x0600277F RID: 10111 RVA: 0x00207D48 File Offset: 0x00205F48
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

			// Token: 0x040051C6 RID: 20934
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06002780 RID: 10112 RVA: 0x00207D6C File Offset: 0x00205F6C
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

			// Token: 0x040051C7 RID: 20935
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x040051C8 RID: 20936
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x040051C9 RID: 20937
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x040051CA RID: 20938
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x040051CB RID: 20939
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x040051CC RID: 20940
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006C1 RID: 1729
		public enum Mode
		{
			// Token: 0x040051CE RID: 20942
			None,
			// Token: 0x040051CF RID: 20943
			Depth,
			// Token: 0x040051D0 RID: 20944
			Normals,
			// Token: 0x040051D1 RID: 20945
			MotionVectors,
			// Token: 0x040051D2 RID: 20946
			AmbientOcclusion,
			// Token: 0x040051D3 RID: 20947
			EyeAdaptation,
			// Token: 0x040051D4 RID: 20948
			FocusPlane,
			// Token: 0x040051D5 RID: 20949
			PreGradingLog,
			// Token: 0x040051D6 RID: 20950
			LogLut,
			// Token: 0x040051D7 RID: 20951
			UserLut
		}

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x06002781 RID: 10113 RVA: 0x00207DC8 File Offset: 0x00205FC8
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

			// Token: 0x040051D8 RID: 20952
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x040051D9 RID: 20953
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x040051DA RID: 20954
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
