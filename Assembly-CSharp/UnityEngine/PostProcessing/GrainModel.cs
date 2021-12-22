using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class GrainModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002334 RID: 9012 RVA: 0x001F0EA8 File Offset: 0x001EF0A8
		// (set) Token: 0x06002335 RID: 9013 RVA: 0x001F0EB0 File Offset: 0x001EF0B0
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

		// Token: 0x06002336 RID: 9014 RVA: 0x001F0EB9 File Offset: 0x001EF0B9
		public override void Reset()
		{
			this.m_Settings = GrainModel.Settings.defaultSettings;
		}

		// Token: 0x04004AC3 RID: 19139
		[SerializeField]
		private GrainModel.Settings m_Settings = GrainModel.Settings.defaultSettings;

		// Token: 0x020006C8 RID: 1736
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002734 RID: 10036 RVA: 0x001FFCBC File Offset: 0x001FDEBC
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

			// Token: 0x0400513D RID: 20797
			[Tooltip("Enable the use of colored grain.")]
			public bool colored;

			// Token: 0x0400513E RID: 20798
			[Range(0f, 1f)]
			[Tooltip("Grain strength. Higher means more visible grain.")]
			public float intensity;

			// Token: 0x0400513F RID: 20799
			[Range(0.3f, 3f)]
			[Tooltip("Grain particle size.")]
			public float size;

			// Token: 0x04005140 RID: 20800
			[Range(0f, 1f)]
			[Tooltip("Controls the noisiness response curve based on scene luminance. Lower values mean less noise in dark areas.")]
			public float luminanceContribution;
		}
	}
}
