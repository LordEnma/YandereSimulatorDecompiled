using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056B RID: 1387
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06002348 RID: 9032 RVA: 0x001F33A8 File Offset: 0x001F15A8
		// (set) Token: 0x06002349 RID: 9033 RVA: 0x001F33B0 File Offset: 0x001F15B0
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

		// Token: 0x0600234A RID: 9034 RVA: 0x001F33B9 File Offset: 0x001F15B9
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF2 RID: 19186
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002734 RID: 10036 RVA: 0x00201AFC File Offset: 0x001FFCFC
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

			// Token: 0x0400513E RID: 20798
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x0400513F RID: 20799
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x04005140 RID: 20800
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x04005141 RID: 20801
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
