using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06002340 RID: 9024 RVA: 0x001F47FB File Offset: 0x001F29FB
		// (set) Token: 0x06002341 RID: 9025 RVA: 0x001F4803 File Offset: 0x001F2A03
		public ChromaticAberrationModel.Settings settings
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

		// Token: 0x06002342 RID: 9026 RVA: 0x001F480C File Offset: 0x001F2A0C
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004B0C RID: 19212
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006B8 RID: 1720
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x06002745 RID: 10053 RVA: 0x00202B74 File Offset: 0x00200D74
			public static ChromaticAberrationModel.Settings defaultSettings
			{
				get
				{
					return new ChromaticAberrationModel.Settings
					{
						spectralTexture = null,
						intensity = 0.1f
					};
				}
			}

			// Token: 0x04005117 RID: 20759
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x04005118 RID: 20760
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
