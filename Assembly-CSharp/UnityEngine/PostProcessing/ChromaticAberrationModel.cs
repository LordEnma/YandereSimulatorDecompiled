using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000560 RID: 1376
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06002306 RID: 8966 RVA: 0x001EF617 File Offset: 0x001ED817
		// (set) Token: 0x06002307 RID: 8967 RVA: 0x001EF61F File Offset: 0x001ED81F
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

		// Token: 0x06002308 RID: 8968 RVA: 0x001EF628 File Offset: 0x001ED828
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004A7C RID: 19068
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002716 RID: 10006 RVA: 0x001FDF88 File Offset: 0x001FC188
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

			// Token: 0x040050A4 RID: 20644
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x040050A5 RID: 20645
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
