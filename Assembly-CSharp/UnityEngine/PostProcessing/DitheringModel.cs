using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06002397 RID: 9111 RVA: 0x001FAE8D File Offset: 0x001F908D
		// (set) Token: 0x06002398 RID: 9112 RVA: 0x001FAE95 File Offset: 0x001F9095
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

		// Token: 0x06002399 RID: 9113 RVA: 0x001FAE9E File Offset: 0x001F909E
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004BEB RID: 19435
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006D1 RID: 1745
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x06002795 RID: 10133 RVA: 0x002098DC File Offset: 0x00207ADC
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
