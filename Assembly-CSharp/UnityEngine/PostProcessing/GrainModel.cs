using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x0600238B RID: 9099 RVA: 0x001F8B08 File Offset: 0x001F6D08
		// (set) Token: 0x0600238C RID: 9100 RVA: 0x001F8B10 File Offset: 0x001F6D10
		public GrainModel.Settings settings
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

		// Token: 0x0600238D RID: 9101 RVA: 0x001F8B19 File Offset: 0x001F6D19
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004BC2 RID: 19394
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006D3 RID: 1747
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A4 RID: 1444
			// (get) Token: 0x06002780 RID: 10112 RVA: 0x00207474 File Offset: 0x00205674
			public static GrainModel.Settings defaultSettings
			{
				get
				{
					return new GrainModel.Settings
					{
						colored = true,
						intensity = 0.5f,
						size = 1f,
						luminanceContribution = 0.8f
					};
				}
			}

			// Token: 0x04005213 RID: 21011
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x04005214 RID: 21012
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x04005215 RID: 21013
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x04005216 RID: 21014
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
