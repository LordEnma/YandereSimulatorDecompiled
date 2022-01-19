using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06002338 RID: 9016 RVA: 0x001F2A75 File Offset: 0x001F0C75
		// (set) Token: 0x06002339 RID: 9017 RVA: 0x001F2A7D File Offset: 0x001F0C7D
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

		// Token: 0x0600233A RID: 9018 RVA: 0x001F2A86 File Offset: 0x001F0C86
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE4 RID: 19172
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002741 RID: 10049 RVA: 0x0020187C File Offset: 0x001FFA7C
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
