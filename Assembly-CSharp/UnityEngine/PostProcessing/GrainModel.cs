using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056B RID: 1387
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06002344 RID: 9028 RVA: 0x001F2B08 File Offset: 0x001F0D08
		// (set) Token: 0x06002345 RID: 9029 RVA: 0x001F2B10 File Offset: 0x001F0D10
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

		// Token: 0x06002346 RID: 9030 RVA: 0x001F2B19 File Offset: 0x001F0D19
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE7 RID: 19175
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006CB RID: 1739
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002744 RID: 10052 RVA: 0x00201940 File Offset: 0x001FFB40
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

			// Token: 0x04005161 RID: 20833
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x04005162 RID: 20834
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x04005163 RID: 20835
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x04005164 RID: 20836
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
