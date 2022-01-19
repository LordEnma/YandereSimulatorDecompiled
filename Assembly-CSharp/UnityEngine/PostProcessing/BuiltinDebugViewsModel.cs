using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	[Serializable]
	public class BuiltinDebugViewsModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002321 RID: 8993 RVA: 0x001F2937 File Offset: 0x001F0B37
		// (set) Token: 0x06002322 RID: 8994 RVA: 0x001F293F File Offset: 0x001F0B3F
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
		// (get) Token: 0x06002323 RID: 8995 RVA: 0x001F2948 File Offset: 0x001F0B48
		public bool willInterrupt
		{
			get
			{
				return !this.IsModeActive(BuiltinDebugViewsModel.Mode.None) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.PreGradingLog) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut) && !this.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut);
			}
		}

		// Token: 0x06002324 RID: 8996 RVA: 0x001F297B File Offset: 0x001F0B7B
		public override void Reset()
		{
			this.settings = BuiltinDebugViewsModel.Settings.defaultSettings;
		}

		// Token: 0x06002325 RID: 8997 RVA: 0x001F2988 File Offset: 0x001F0B88
		public bool IsModeActive(BuiltinDebugViewsModel.Mode mode)
		{
			return this.m_Settings.mode == mode;
		}

		// Token: 0x04004ADE RID: 19166
		[SerializeField]
		private BuiltinDebugViewsModel.Settings m_Settings = BuiltinDebugViewsModel.Settings.defaultSettings;

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct DepthSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002734 RID: 10036 RVA: 0x00201288 File Offset: 0x001FF488
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

			// Token: 0x040050FE RID: 20734
			[Range(0f, 1f)]
			[Tooltip("Scales the camera far plane before displaying the depth map.")]
			public float scale;
		}

		// Token: 0x020006B7 RID: 1719
		[Serializable]
		public struct MotionVectorsSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002735 RID: 10037 RVA: 0x002012AC File Offset: 0x001FF4AC
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

			// Token: 0x040050FF RID: 20735
			[Range(0f, 1f)]
			[Tooltip("Opacity of the source render.")]
			public float sourceOpacity;

			// Token: 0x04005100 RID: 20736
			[Range(0f, 1f)]
			[Tooltip("Opacity of the per-pixel motion vector colors.")]
			public float motionImageOpacity;

			// Token: 0x04005101 RID: 20737
			[Min(0f)]
			[Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
			public float motionImageAmplitude;

			// Token: 0x04005102 RID: 20738
			[Range(0f, 1f)]
			[Tooltip("Opacity for the motion vector arrows.")]
			public float motionVectorsOpacity;

			// Token: 0x04005103 RID: 20739
			[Range(8f, 64f)]
			[Tooltip("The arrow density on screen.")]
			public int motionVectorsResolution;

			// Token: 0x04005104 RID: 20740
			[Min(0f)]
			[Tooltip("Tweaks the arrows length.")]
			public float motionVectorsAmplitude;
		}

		// Token: 0x020006B8 RID: 1720
		public enum Mode
		{
			// Token: 0x04005106 RID: 20742
			None,
			// Token: 0x04005107 RID: 20743
			Depth,
			// Token: 0x04005108 RID: 20744
			Normals,
			// Token: 0x04005109 RID: 20745
			MotionVectors,
			// Token: 0x0400510A RID: 20746
			AmbientOcclusion,
			// Token: 0x0400510B RID: 20747
			EyeAdaptation,
			// Token: 0x0400510C RID: 20748
			FocusPlane,
			// Token: 0x0400510D RID: 20749
			PreGradingLog,
			// Token: 0x0400510E RID: 20750
			LogLut,
			// Token: 0x0400510F RID: 20751
			UserLut
		}

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002736 RID: 10038 RVA: 0x00201308 File Offset: 0x001FF508
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

			// Token: 0x04005110 RID: 20752
			public BuiltinDebugViewsModel.Mode mode;

			// Token: 0x04005111 RID: 20753
			public BuiltinDebugViewsModel.DepthSettings depth;

			// Token: 0x04005112 RID: 20754
			public BuiltinDebugViewsModel.MotionVectorsSettings motionVectors;
		}
	}
}
