using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000579 RID: 1401
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x060023A3 RID: 9123 RVA: 0x001FAF20 File Offset: 0x001F9120
		// (set) Token: 0x060023A4 RID: 9124 RVA: 0x001FAF28 File Offset: 0x001F9128
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

		// Token: 0x060023A5 RID: 9125 RVA: 0x001FAF31 File Offset: 0x001F9131
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004BEE RID: 19438
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006D5 RID: 1749
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x06002798 RID: 10136 RVA: 0x002099A0 File Offset: 0x00207BA0
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

			// Token: 0x04005247 RID: 21063
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x04005248 RID: 21064
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x04005249 RID: 21065
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x0400524A RID: 21066
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
