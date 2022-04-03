using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x0600237F RID: 9087 RVA: 0x001F8A75 File Offset: 0x001F6C75
		// (set) Token: 0x06002380 RID: 9088 RVA: 0x001F8A7D File Offset: 0x001F6C7D
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

		// Token: 0x06002381 RID: 9089 RVA: 0x001F8A86 File Offset: 0x001F6C86
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004BBF RID: 19391
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x0600277D RID: 10109 RVA: 0x002073B0 File Offset: 0x002055B0
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
