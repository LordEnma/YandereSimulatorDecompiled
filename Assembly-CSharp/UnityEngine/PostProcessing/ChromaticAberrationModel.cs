using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06002330 RID: 9008 RVA: 0x001F3767 File Offset: 0x001F1967
		// (set) Token: 0x06002331 RID: 9009 RVA: 0x001F376F File Offset: 0x001F196F
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

		// Token: 0x06002332 RID: 9010 RVA: 0x001F3778 File Offset: 0x001F1978
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF3 RID: 19187
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x0600272C RID: 10028 RVA: 0x00201A18 File Offset: 0x001FFC18
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

			// Token: 0x040050F9 RID: 20729
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x040050FA RID: 20730
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
