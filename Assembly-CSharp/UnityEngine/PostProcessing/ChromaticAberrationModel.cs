using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06002346 RID: 9030 RVA: 0x001F51D3 File Offset: 0x001F33D3
		// (set) Token: 0x06002347 RID: 9031 RVA: 0x001F51DB File Offset: 0x001F33DB
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

		// Token: 0x06002348 RID: 9032 RVA: 0x001F51E4 File Offset: 0x001F33E4
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004B29 RID: 19241
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000596 RID: 1430
			// (get) Token: 0x0600274B RID: 10059 RVA: 0x0020354C File Offset: 0x0020174C
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

			// Token: 0x04005134 RID: 20788
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x04005135 RID: 20789
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
