using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x001F9A01 File Offset: 0x001F7C01
		// (set) Token: 0x0600238F RID: 9103 RVA: 0x001F9A09 File Offset: 0x001F7C09
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

		// Token: 0x06002390 RID: 9104 RVA: 0x001F9A12 File Offset: 0x001F7C12
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004BD5 RID: 19413
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006D0 RID: 1744
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x0600278C RID: 10124 RVA: 0x0020833C File Offset: 0x0020653C
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
