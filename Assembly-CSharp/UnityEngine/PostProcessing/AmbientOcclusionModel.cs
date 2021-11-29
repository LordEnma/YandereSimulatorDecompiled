using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	[Serializable]
	public class AmbientOcclusionModel : PostProcessingModel
	{
		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x060022F4 RID: 8948 RVA: 0x001EF510 File Offset: 0x001ED710
		// (set) Token: 0x060022F5 RID: 8949 RVA: 0x001EF518 File Offset: 0x001ED718
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

		// Token: 0x060022F6 RID: 8950 RVA: 0x001EF521 File Offset: 0x001ED721
		public override void Reset()
		{
			this.m_Settings = AmbientOcclusionModel.Settings.defaultSettings;
		}

		// Token: 0x04004A78 RID: 19064
		[SerializeField]
		private AmbientOcclusionModel.Settings m_Settings = AmbientOcclusionModel.Settings.defaultSettings;

		// Token: 0x020006A4 RID: 1700
		public enum SampleCount
		{
			// Token: 0x04005061 RID: 20577
			Lowest = 3,
			// Token: 0x04005062 RID: 20578
			Low = 6,
			// Token: 0x04005063 RID: 20579
			Medium = 10,
			// Token: 0x04005064 RID: 20580
			High = 16
		}

		// Token: 0x020006A5 RID: 1701
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000586 RID: 1414
			// (get) Token: 0x06002708 RID: 9992 RVA: 0x001FDA9C File Offset: 0x001FBC9C
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

			// Token: 0x04005065 RID: 20581
			[Range(0f, 4f)]
			[Tooltip("Degree of darkness produced by the effect.")]
			public float intensity;

			// Token: 0x04005066 RID: 20582
			[Min(0.0001f)]
			[Tooltip("Radius of sample points, which affects extent of darkened areas.")]
			public float radius;

			// Token: 0x04005067 RID: 20583
			[Tooltip("Number of sample points, which affects quality and performance.")]
			public AmbientOcclusionModel.SampleCount sampleCount;

			// Token: 0x04005068 RID: 20584
			[Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
			public bool downsampling;

			// Token: 0x04005069 RID: 20585
			[Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
			public bool forceForwardCompatibility;

			// Token: 0x0400506A RID: 20586
			[Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
			public bool ambientOnly;

			// Token: 0x0400506B RID: 20587
			[Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
			public bool highPrecision;
		}
	}
}
