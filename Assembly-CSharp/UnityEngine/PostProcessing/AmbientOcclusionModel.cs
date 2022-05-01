using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06002374 RID: 9076 RVA: 0x001FACBC File Offset: 0x001F8EBC
		// (set) Token: 0x06002375 RID: 9077 RVA: 0x001FACC4 File Offset: 0x001F8EC4
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

		// Token: 0x06002376 RID: 9078 RVA: 0x001FACCD File Offset: 0x001F8ECD
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004BE2 RID: 19426
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006B4 RID: 1716
		public enum SampleCount
		{
			// Token: 0x040051B6 RID: 20918
			Lowest = 3,
			// Token: 0x040051B7 RID: 20919
			Low = 6,
			// Token: 0x040051B8 RID: 20920
			Medium = 10,
			// Token: 0x040051B9 RID: 20921
			High = 16
		}

		// Token: 0x020006B5 RID: 1717
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x0600277D RID: 10109 RVA: 0x00208EB4 File Offset: 0x002070B4
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

			// Token: 0x040051BA RID: 20922
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040051BB RID: 20923
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040051BC RID: 20924
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040051BD RID: 20925
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040051BE RID: 20926
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040051BF RID: 20927
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040051C0 RID: 20928
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
