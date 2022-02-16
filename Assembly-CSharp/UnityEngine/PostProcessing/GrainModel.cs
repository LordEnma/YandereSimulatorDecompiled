using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06002354 RID: 9044 RVA: 0x001F3D78 File Offset: 0x001F1F78
		// (set) Token: 0x06002355 RID: 9045 RVA: 0x001F3D80 File Offset: 0x001F1F80
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

		// Token: 0x06002356 RID: 9046 RVA: 0x001F3D89 File Offset: 0x001F1F89
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004B04 RID: 19204
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x06002740 RID: 10048 RVA: 0x002024CC File Offset: 0x002006CC
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

			// Token: 0x04005150 RID: 20816
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x04005151 RID: 20817
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x04005152 RID: 20818
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x04005153 RID: 20819
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
