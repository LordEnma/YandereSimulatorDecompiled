using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x060023A2 RID: 9122 RVA: 0x001FC5D9 File Offset: 0x001FA7D9
		// (set) Token: 0x060023A3 RID: 9123 RVA: 0x001FC5E1 File Offset: 0x001FA7E1
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

		// Token: 0x060023A4 RID: 9124 RVA: 0x001FC5EA File Offset: 0x001FA7EA
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004C12 RID: 19474
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006D2 RID: 1746
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x060027A0 RID: 10144 RVA: 0x0020B028 File Offset: 0x00209228
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
