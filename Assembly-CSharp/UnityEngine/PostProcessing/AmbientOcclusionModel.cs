using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x0600235C RID: 9052 RVA: 0x001F88A4 File Offset: 0x001F6AA4
		// (set) Token: 0x0600235D RID: 9053 RVA: 0x001F88AC File Offset: 0x001F6AAC
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

		// Token: 0x0600235E RID: 9054 RVA: 0x001F88B5 File Offset: 0x001F6AB5
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004BB6 RID: 19382
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006B2 RID: 1714
		public enum SampleCount
		{
			// Token: 0x04005182 RID: 20866
			Lowest = 3,
			// Token: 0x04005183 RID: 20867
			Low = 6,
			// Token: 0x04005184 RID: 20868
			Medium = 10,
			// Token: 0x04005185 RID: 20869
			High = 16
		}

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06002765 RID: 10085 RVA: 0x00206988 File Offset: 0x00204B88
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

			// Token: 0x04005186 RID: 20870
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x04005187 RID: 20871
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x04005188 RID: 20872
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x04005189 RID: 20873
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x0400518A RID: 20874
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x0400518B RID: 20875
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x0400518C RID: 20876
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
