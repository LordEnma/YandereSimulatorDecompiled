using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056A RID: 1386
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06002342 RID: 9026 RVA: 0x001F1E38 File Offset: 0x001F0038
		// (set) Token: 0x06002343 RID: 9027 RVA: 0x001F1E40 File Offset: 0x001F0040
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

		// Token: 0x06002344 RID: 9028 RVA: 0x001F1E49 File Offset: 0x001F0049
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE0 RID: 19168
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006CA RID: 1738
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002742 RID: 10050 RVA: 0x00200C70 File Offset: 0x001FEE70
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

			// Token: 0x0400515A RID: 20826
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x0400515B RID: 20827
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x0400515C RID: 20828
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x0400515D RID: 20829
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
