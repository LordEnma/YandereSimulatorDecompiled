using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056B RID: 1387
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x0600234D RID: 9037 RVA: 0x001F38C4 File Offset: 0x001F1AC4
		// (set) Token: 0x0600234E RID: 9038 RVA: 0x001F38CC File Offset: 0x001F1ACC
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

		// Token: 0x0600234F RID: 9039 RVA: 0x001F38D5 File Offset: 0x001F1AD5
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004AFB RID: 19195
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x06002739 RID: 10041 RVA: 0x00202018 File Offset: 0x00200218
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

			// Token: 0x04005147 RID: 20807
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x04005148 RID: 20808
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x04005149 RID: 20809
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x0400514A RID: 20810
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
