using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002323 RID: 8995 RVA: 0x001EF774 File Offset: 0x001ED974
		// (set) Token: 0x06002324 RID: 8996 RVA: 0x001EF77C File Offset: 0x001ED97C
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

		// Token: 0x06002325 RID: 8997 RVA: 0x001EF785 File Offset: 0x001ED985
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004A84 RID: 19076
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002723 RID: 10019 RVA: 0x001FE588 File Offset: 0x001FC788
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

			// Token: 0x040050F2 RID: 20722
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x040050F3 RID: 20723
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x040050F4 RID: 20724
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x040050F5 RID: 20725
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
