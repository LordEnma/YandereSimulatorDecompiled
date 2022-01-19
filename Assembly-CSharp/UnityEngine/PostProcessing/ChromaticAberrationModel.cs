using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06002327 RID: 8999 RVA: 0x001F29AB File Offset: 0x001F0BAB
		// (set) Token: 0x06002328 RID: 9000 RVA: 0x001F29B3 File Offset: 0x001F0BB3
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

		// Token: 0x06002329 RID: 9001 RVA: 0x001F29BC File Offset: 0x001F0BBC
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004ADF RID: 19167
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006BA RID: 1722
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002737 RID: 10039 RVA: 0x00201340 File Offset: 0x001FF540
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

			// Token: 0x04005113 RID: 20755
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x04005114 RID: 20756
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
