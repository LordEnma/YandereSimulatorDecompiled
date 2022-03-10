using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06002363 RID: 9059 RVA: 0x001F5330 File Offset: 0x001F3530
		// (set) Token: 0x06002364 RID: 9060 RVA: 0x001F5338 File Offset: 0x001F3538
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

		// Token: 0x06002365 RID: 9061 RVA: 0x001F5341 File Offset: 0x001F3541
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004B31 RID: 19249
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006CA RID: 1738
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x06002758 RID: 10072 RVA: 0x00203B4C File Offset: 0x00201D4C
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

			// Token: 0x04005182 RID: 20866
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x04005183 RID: 20867
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x04005184 RID: 20868
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x04005185 RID: 20869
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
