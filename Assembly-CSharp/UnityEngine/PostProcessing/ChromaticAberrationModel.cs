using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06002337 RID: 9015 RVA: 0x001F3C1B File Offset: 0x001F1E1B
		// (set) Token: 0x06002338 RID: 9016 RVA: 0x001F3C23 File Offset: 0x001F1E23
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

		// Token: 0x06002339 RID: 9017 RVA: 0x001F3C2C File Offset: 0x001F1E2C
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004AFC RID: 19196
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006B5 RID: 1717
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002733 RID: 10035 RVA: 0x00201ECC File Offset: 0x002000CC
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

			// Token: 0x04005102 RID: 20738
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x04005103 RID: 20739
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
