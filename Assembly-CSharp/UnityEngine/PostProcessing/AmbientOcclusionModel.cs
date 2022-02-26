using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x0600232E RID: 9006 RVA: 0x001F46F4 File Offset: 0x001F28F4
		// (set) Token: 0x0600232F RID: 9007 RVA: 0x001F46FC File Offset: 0x001F28FC
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

		// Token: 0x06002330 RID: 9008 RVA: 0x001F4705 File Offset: 0x001F2905
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004B08 RID: 19208
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A8 RID: 1704
		public enum SampleCount
		{
			// Token: 0x040050D4 RID: 20692
			Lowest = 3,
			// Token: 0x040050D5 RID: 20693
			Low = 6,
			// Token: 0x040050D6 RID: 20694
			Medium = 10,
			// Token: 0x040050D7 RID: 20695
			High = 16
		}

		// Token: 0x020006A9 RID: 1705
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002737 RID: 10039 RVA: 0x00202688 File Offset: 0x00200888
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

			// Token: 0x040050D8 RID: 20696
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050D9 RID: 20697
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050DA RID: 20698
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050DB RID: 20699
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050DC RID: 20700
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050DD RID: 20701
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050DE RID: 20702
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
