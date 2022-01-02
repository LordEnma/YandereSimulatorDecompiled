using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055E RID: 1374
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06002308 RID: 8968 RVA: 0x001F1234 File Offset: 0x001EF434
		// (set) Token: 0x06002309 RID: 8969 RVA: 0x001F123C File Offset: 0x001EF43C
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

		// Token: 0x0600230A RID: 8970 RVA: 0x001F1245 File Offset: 0x001EF445
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004AC0 RID: 19136
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A7 RID: 1703
		public enum SampleCount
		{
			// Token: 0x040050B5 RID: 20661
			Lowest = 3,
			// Token: 0x040050B6 RID: 20662
			Low = 6,
			// Token: 0x040050B7 RID: 20663
			Medium = 10,
			// Token: 0x040050B8 RID: 20664
			High = 16
		}

		// Token: 0x020006A8 RID: 1704
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x0600271C RID: 10012 RVA: 0x001FF7E4 File Offset: 0x001FD9E4
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

			// Token: 0x040050B9 RID: 20665
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050BA RID: 20666
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050BB RID: 20667
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050BC RID: 20668
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050BD RID: 20669
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050BE RID: 20670
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050BF RID: 20671
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
