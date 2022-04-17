using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x0600239A RID: 9114 RVA: 0x001F9A94 File Offset: 0x001F7C94
		// (set) Token: 0x0600239B RID: 9115 RVA: 0x001F9A9C File Offset: 0x001F7C9C
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

		// Token: 0x0600239C RID: 9116 RVA: 0x001F9AA5 File Offset: 0x001F7CA5
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004BD8 RID: 19416
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006D4 RID: 1748
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x0600278F RID: 10127 RVA: 0x00208400 File Offset: 0x00206600
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

			// Token: 0x04005229 RID: 21033
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x0400522A RID: 21034
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x0400522B RID: 21035
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x0400522C RID: 21036
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
