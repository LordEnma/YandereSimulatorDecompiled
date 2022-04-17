using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x0600237D RID: 9085 RVA: 0x001F9937 File Offset: 0x001F7B37
		// (set) Token: 0x0600237E RID: 9086 RVA: 0x001F993F File Offset: 0x001F7B3F
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

		// Token: 0x0600237F RID: 9087 RVA: 0x001F9948 File Offset: 0x001F7B48
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004BD0 RID: 19408
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006C3 RID: 1731
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000598 RID: 1432
			// (get) Token: 0x06002782 RID: 10114 RVA: 0x00207E00 File Offset: 0x00206000
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

			// Token: 0x040051DB RID: 20955
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x040051DC RID: 20956
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
