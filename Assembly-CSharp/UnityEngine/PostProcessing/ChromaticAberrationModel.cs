using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002386 RID: 9094 RVA: 0x001FADC3 File Offset: 0x001F8FC3
		// (set) Token: 0x06002387 RID: 9095 RVA: 0x001FADCB File Offset: 0x001F8FCB
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

		// Token: 0x06002388 RID: 9096 RVA: 0x001FADD4 File Offset: 0x001F8FD4
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004BE6 RID: 19430
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006C4 RID: 1732
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x0600278B RID: 10123 RVA: 0x002093A0 File Offset: 0x002075A0
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

			// Token: 0x040051F9 RID: 20985
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x040051FA RID: 20986
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
