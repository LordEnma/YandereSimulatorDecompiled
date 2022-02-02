using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600233C RID: 9020 RVA: 0x001F3315 File Offset: 0x001F1515
		// (set) Token: 0x0600233D RID: 9021 RVA: 0x001F331D File Offset: 0x001F151D
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

		// Token: 0x0600233E RID: 9022 RVA: 0x001F3326 File Offset: 0x001F1526
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004AEF RID: 19183
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002731 RID: 10033 RVA: 0x00201A38 File Offset: 0x001FFC38
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
