using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000561 RID: 1377
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x0600231E RID: 8990 RVA: 0x001F3660 File Offset: 0x001F1860
		// (set) Token: 0x0600231F RID: 8991 RVA: 0x001F3668 File Offset: 0x001F1868
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

		// Token: 0x06002320 RID: 8992 RVA: 0x001F3671 File Offset: 0x001F1871
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004AEF RID: 19183
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A4 RID: 1700
		public enum SampleCount
		{
			// Token: 0x040050B6 RID: 20662
			Lowest = 3,
			// Token: 0x040050B7 RID: 20663
			Low = 6,
			// Token: 0x040050B8 RID: 20664
			Medium = 10,
			// Token: 0x040050B9 RID: 20665
			High = 16
		}

		// Token: 0x020006A5 RID: 1701
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600271E RID: 10014 RVA: 0x0020152C File Offset: 0x001FF72C
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

			// Token: 0x040050BA RID: 20666
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050BB RID: 20667
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050BC RID: 20668
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050BD RID: 20669
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050BE RID: 20670
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050BF RID: 20671
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050C0 RID: 20672
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
