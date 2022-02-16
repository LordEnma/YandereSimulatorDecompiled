using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000569 RID: 1385
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002348 RID: 9032 RVA: 0x001F3CE5 File Offset: 0x001F1EE5
		// (set) Token: 0x06002349 RID: 9033 RVA: 0x001F3CED File Offset: 0x001F1EED
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

		// Token: 0x0600234A RID: 9034 RVA: 0x001F3CF6 File Offset: 0x001F1EF6
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004B01 RID: 19201
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C2 RID: 1730
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x0600273D RID: 10045 RVA: 0x00202408 File Offset: 0x00200608
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
