using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000560 RID: 1376
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06002313 RID: 8979 RVA: 0x001F1BD4 File Offset: 0x001EFDD4
		// (set) Token: 0x06002314 RID: 8980 RVA: 0x001F1BDC File Offset: 0x001EFDDC
		public AmbientOcclusionModel.Settings settings
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

		// Token: 0x06002315 RID: 8981 RVA: 0x001F1BE5 File Offset: 0x001EFDE5
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004AD4 RID: 19156
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A9 RID: 1705
		public enum SampleCount
		{
			// Token: 0x040050C9 RID: 20681
			Lowest = 3,
			// Token: 0x040050CA RID: 20682
			Low = 6,
			// Token: 0x040050CB RID: 20683
			Medium = 10,
			// Token: 0x040050CC RID: 20684
			High = 16
		}

		// Token: 0x020006AA RID: 1706
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002727 RID: 10023 RVA: 0x00200184 File Offset: 0x001FE384
			public static AmbientOcclusionModel.Settings defaultSettings
			{
				get
				{
					return new AmbientOcclusionModel.Settings
					{
						intensity = 1f,
						radius = 0.3f,
						sampleCount = AmbientOcclusionModel.SampleCount.Medium,
						downsampling = true,
						forceForwardCompatibility = false,
						ambientOnly = false,
						highPrecision = false
					};
				}
			}

			// Token: 0x040050CD RID: 20685
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050CE RID: 20686
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050CF RID: 20687
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050D0 RID: 20688
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050D1 RID: 20689
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050D2 RID: 20690
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050D3 RID: 20691
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
