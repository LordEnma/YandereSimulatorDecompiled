using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002317 RID: 8983 RVA: 0x001EF6E1 File Offset: 0x001ED8E1
		// (set) Token: 0x06002318 RID: 8984 RVA: 0x001EF6E9 File Offset: 0x001ED8E9
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

		// Token: 0x06002319 RID: 8985 RVA: 0x001EF6F2 File Offset: 0x001ED8F2
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004A81 RID: 19073
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002720 RID: 10016 RVA: 0x001FE4C4 File Offset: 0x001FC6C4
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
