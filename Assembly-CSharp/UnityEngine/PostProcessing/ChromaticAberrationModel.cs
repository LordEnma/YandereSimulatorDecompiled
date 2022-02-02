using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x0600232B RID: 9003 RVA: 0x001F324B File Offset: 0x001F144B
		// (set) Token: 0x0600232C RID: 9004 RVA: 0x001F3253 File Offset: 0x001F1453
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

		// Token: 0x0600232D RID: 9005 RVA: 0x001F325C File Offset: 0x001F145C
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004AEA RID: 19178
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002727 RID: 10023 RVA: 0x002014FC File Offset: 0x001FF6FC
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

			// Token: 0x040050F0 RID: 20720
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x040050F1 RID: 20721
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
