using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056B RID: 1387
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06002358 RID: 9048 RVA: 0x001F70C7 File Offset: 0x001F52C7
		// (set) Token: 0x06002359 RID: 9049 RVA: 0x001F70CF File Offset: 0x001F52CF
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
		// (get) Token: 0x0600235A RID: 9050 RVA: 0x001F70D8 File Offset: 0x001F52D8
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x0600235B RID: 9051 RVA: 0x001F710B File Offset: 0x001F530B
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x001F7118 File Offset: 0x001F5318
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004B87 RID: 19335
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002760 RID: 10080 RVA: 0x002053FC File Offset: 0x002035FC
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

			// Token: 0x0400517E RID: 20862
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006BA RID: 1722
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06002761 RID: 10081 RVA: 0x00205420 File Offset: 0x00203620
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

			// Token: 0x0400517F RID: 20863
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x04005180 RID: 20864
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x04005181 RID: 20865
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x04005182 RID: 20866
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x04005183 RID: 20867
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x04005184 RID: 20868
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006BB RID: 1723
		public enum Mode
		{
			// Token: 0x04005186 RID: 20870
			None,
			// Token: 0x04005187 RID: 20871
			Depth,
			// Token: 0x04005188 RID: 20872
			Normals,
			// Token: 0x04005189 RID: 20873
			MotionVectors,
			// Token: 0x0400518A RID: 20874
			AmbientOcclusion,
			// Token: 0x0400518B RID: 20875
			EyeAdaptation,
			// Token: 0x0400518C RID: 20876
			FocusPlane,
			// Token: 0x0400518D RID: 20877
			PreGradingLog,
			// Token: 0x0400518E RID: 20878
			LogLut,
			// Token: 0x0400518F RID: 20879
			UserLut
		}

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06002762 RID: 10082 RVA: 0x0020547C File Offset: 0x0020367C
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

			// Token: 0x04005190 RID: 20880
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x04005191 RID: 20881
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x04005192 RID: 20882
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
