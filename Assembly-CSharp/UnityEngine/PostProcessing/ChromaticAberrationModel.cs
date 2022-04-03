using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600236E RID: 9070 RVA: 0x001F89AB File Offset: 0x001F6BAB
		// (set) Token: 0x0600236F RID: 9071 RVA: 0x001F89B3 File Offset: 0x001F6BB3
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

		// Token: 0x06002370 RID: 9072 RVA: 0x001F89BC File Offset: 0x001F6BBC
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004BBA RID: 19386
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x06002773 RID: 10099 RVA: 0x00206E74 File Offset: 0x00205074
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

			// Token: 0x040051C5 RID: 20933
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x040051C6 RID: 20934
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
