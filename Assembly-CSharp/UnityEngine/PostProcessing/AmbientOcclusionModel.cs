using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055E RID: 1374
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06002305 RID: 8965 RVA: 0x001F0C44 File Offset: 0x001EEE44
		// (set) Token: 0x06002306 RID: 8966 RVA: 0x001F0C4C File Offset: 0x001EEE4C
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

		// Token: 0x06002307 RID: 8967 RVA: 0x001F0C55 File Offset: 0x001EEE55
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004AB7 RID: 19127
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A7 RID: 1703
		public enum SampleCount
		{
			// Token: 0x040050AC RID: 20652
			Lowest = 3,
			// Token: 0x040050AD RID: 20653
			Low = 6,
			// Token: 0x040050AE RID: 20654
			Medium = 10,
			// Token: 0x040050AF RID: 20655
			High = 16
		}

		// Token: 0x020006A8 RID: 1704
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002719 RID: 10009 RVA: 0x001FF1D0 File Offset: 0x001FD3D0
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

			// Token: 0x040050B0 RID: 20656
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050B1 RID: 20657
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050B2 RID: 20658
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050B3 RID: 20659
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050B4 RID: 20660
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050B5 RID: 20661
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050B6 RID: 20662
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
