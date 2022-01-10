using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	[Serializable]
	public class ChromaticAberrationModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06002325 RID: 8997 RVA: 0x001F1CDB File Offset: 0x001EFEDB
		// (set) Token: 0x06002326 RID: 8998 RVA: 0x001F1CE3 File Offset: 0x001EFEE3
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

		// Token: 0x06002327 RID: 8999 RVA: 0x001F1CEC File Offset: 0x001EFEEC
		public override void Reset()
		{
			this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;
		}

		// Token: 0x04004AD8 RID: 19160
		[SerializeField]
		private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002735 RID: 10037 RVA: 0x00200670 File Offset: 0x001FE870
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

			// Token: 0x0400510C RID: 20748
			[Tooltip("Shift the hue of chromatic aberrations.")]
			public Texture2D spectralTexture;

			// Token: 0x0400510D RID: 20749
			[Range(0f, 1f)]
			[Tooltip("Amount of tangential distortion.")]
			public float intensity;
		}
	}
}
