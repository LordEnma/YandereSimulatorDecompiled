using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000561 RID: 1377
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06002315 RID: 8981 RVA: 0x001F28A4 File Offset: 0x001F0AA4
		// (set) Token: 0x06002316 RID: 8982 RVA: 0x001F28AC File Offset: 0x001F0AAC
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

		// Token: 0x06002317 RID: 8983 RVA: 0x001F28B5 File Offset: 0x001F0AB5
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004ADB RID: 19163
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006AA RID: 1706
		public enum SampleCount
		{
			// Token: 0x040050D0 RID: 20688
			Lowest = 3,
			// Token: 0x040050D1 RID: 20689
			Low = 6,
			// Token: 0x040050D2 RID: 20690
			Medium = 10,
			// Token: 0x040050D3 RID: 20691
			High = 16
		}

		// Token: 0x020006AB RID: 1707
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06002729 RID: 10025 RVA: 0x00200E54 File Offset: 0x001FF054
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

			// Token: 0x040050D4 RID: 20692
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050D5 RID: 20693
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050D6 RID: 20694
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050D7 RID: 20695
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050D8 RID: 20696
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050D9 RID: 20697
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050DA RID: 20698
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
