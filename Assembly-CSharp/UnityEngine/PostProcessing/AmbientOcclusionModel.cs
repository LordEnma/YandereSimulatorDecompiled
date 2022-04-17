using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x0600236B RID: 9067 RVA: 0x001F9830 File Offset: 0x001F7A30
		// (set) Token: 0x0600236C RID: 9068 RVA: 0x001F9838 File Offset: 0x001F7A38
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

		// Token: 0x0600236D RID: 9069 RVA: 0x001F9841 File Offset: 0x001F7A41
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004BCC RID: 19404
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006B3 RID: 1715
		public enum SampleCount
		{
			// Token: 0x04005198 RID: 20888
			Lowest = 3,
			// Token: 0x04005199 RID: 20889
			Low = 6,
			// Token: 0x0400519A RID: 20890
			Medium = 10,
			// Token: 0x0400519B RID: 20891
			High = 16
		}

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002774 RID: 10100 RVA: 0x00207914 File Offset: 0x00205B14
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

			// Token: 0x0400519C RID: 20892
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x0400519D RID: 20893
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x0400519E RID: 20894
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x0400519F RID: 20895
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040051A0 RID: 20896
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040051A1 RID: 20897
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040051A2 RID: 20898
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
