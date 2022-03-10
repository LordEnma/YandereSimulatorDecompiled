using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002334 RID: 9012 RVA: 0x001F50CC File Offset: 0x001F32CC
		// (set) Token: 0x06002335 RID: 9013 RVA: 0x001F50D4 File Offset: 0x001F32D4
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

		// Token: 0x06002336 RID: 9014 RVA: 0x001F50DD File Offset: 0x001F32DD
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004B25 RID: 19237
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A9 RID: 1705
		public enum SampleCount
		{
			// Token: 0x040050F1 RID: 20721
			Lowest = 3,
			// Token: 0x040050F2 RID: 20722
			Low = 6,
			// Token: 0x040050F3 RID: 20723
			Medium = 10,
			// Token: 0x040050F4 RID: 20724
			High = 16
		}

		// Token: 0x020006AA RID: 1706
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x0600273D RID: 10045 RVA: 0x00203060 File Offset: 0x00201260
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

			// Token: 0x040050F5 RID: 20725
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050F6 RID: 20726
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050F7 RID: 20727
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050F8 RID: 20728
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050F9 RID: 20729
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050FA RID: 20730
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050FB RID: 20731
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
