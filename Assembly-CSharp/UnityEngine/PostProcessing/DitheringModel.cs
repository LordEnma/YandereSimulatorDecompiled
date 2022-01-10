using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06002336 RID: 9014 RVA: 0x001F1DA5 File Offset: 0x001EFFA5
		// (set) Token: 0x06002337 RID: 9015 RVA: 0x001F1DAD File Offset: 0x001EFFAD
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

		// Token: 0x06002338 RID: 9016 RVA: 0x001F1DB6 File Offset: 0x001EFFB6
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004ADD RID: 19165
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x0600273F RID: 10047 RVA: 0x00200BAC File Offset: 0x001FEDAC
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
