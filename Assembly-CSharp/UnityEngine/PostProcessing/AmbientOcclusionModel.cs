using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x0600234C RID: 9036 RVA: 0x001F7034 File Offset: 0x001F5234
		// (set) Token: 0x0600234D RID: 9037 RVA: 0x001F703C File Offset: 0x001F523C
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

		// Token: 0x0600234E RID: 9038 RVA: 0x001F7045 File Offset: 0x001F5245
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004B84 RID: 19332
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006AD RID: 1709
		public enum SampleCount
		{
			// Token: 0x04005150 RID: 20816
			Lowest = 3,
			// Token: 0x04005151 RID: 20817
			Low = 6,
			// Token: 0x04005152 RID: 20818
			Medium = 10,
			// Token: 0x04005153 RID: 20819
			High = 16
		}

		// Token: 0x020006AE RID: 1710
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06002755 RID: 10069 RVA: 0x00204FC8 File Offset: 0x002031C8
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

			// Token: 0x04005154 RID: 20820
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x04005155 RID: 20821
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x04005156 RID: 20822
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x04005157 RID: 20823
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x04005158 RID: 20824
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x04005159 RID: 20825
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x0400515A RID: 20826
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
