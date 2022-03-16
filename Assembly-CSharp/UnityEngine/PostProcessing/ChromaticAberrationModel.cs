using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600235E RID: 9054 RVA: 0x001F713B File Offset: 0x001F533B
		// (set) Token: 0x0600235F RID: 9055 RVA: 0x001F7143 File Offset: 0x001F5343
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

		// Token: 0x06002360 RID: 9056 RVA: 0x001F714C File Offset: 0x001F534C
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004B88 RID: 19336
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000597 RID: 1431
			// (get) Token: 0x06002763 RID: 10083 RVA: 0x002054B4 File Offset: 0x002036B4
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

			// Token: 0x04005193 RID: 20883
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x04005194 RID: 20884
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
