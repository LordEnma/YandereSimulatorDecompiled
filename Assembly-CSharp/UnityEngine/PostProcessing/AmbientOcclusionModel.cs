using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000562 RID: 1378
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002325 RID: 8997 RVA: 0x001F3B14 File Offset: 0x001F1D14
		// (set) Token: 0x06002326 RID: 8998 RVA: 0x001F3B1C File Offset: 0x001F1D1C
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

		// Token: 0x06002327 RID: 8999 RVA: 0x001F3B25 File Offset: 0x001F1D25
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF8 RID: 19192
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A5 RID: 1701
		public enum SampleCount
		{
			// Token: 0x040050BF RID: 20671
			Lowest = 3,
			// Token: 0x040050C0 RID: 20672
			Low = 6,
			// Token: 0x040050C1 RID: 20673
			Medium = 10,
			// Token: 0x040050C2 RID: 20674
			High = 16
		}

		// Token: 0x020006A6 RID: 1702
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x06002725 RID: 10021 RVA: 0x002019E0 File Offset: 0x001FFBE0
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

			// Token: 0x040050C3 RID: 20675
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x040050C4 RID: 20676
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x040050C5 RID: 20677
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x040050C6 RID: 20678
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x040050C7 RID: 20679
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x040050C8 RID: 20680
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x040050C9 RID: 20681
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
