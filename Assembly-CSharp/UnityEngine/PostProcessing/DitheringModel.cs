using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056B RID: 1387
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002357 RID: 9047 RVA: 0x001F529D File Offset: 0x001F349D
		// (set) Token: 0x06002358 RID: 9048 RVA: 0x001F52A5 File Offset: 0x001F34A5
		public DitheringModel.Settings settings
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

		// Token: 0x06002359 RID: 9049 RVA: 0x001F52AE File Offset: 0x001F34AE
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004B2E RID: 19246
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x06002755 RID: 10069 RVA: 0x00203A88 File Offset: 0x00201C88
			public static DitheringModel.Settings defaultSettings
			{
				get
				{
					return default(DitheringModel.Settings);
				}
			}
		}
	}
}
