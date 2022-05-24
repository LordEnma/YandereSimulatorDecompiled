using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x060023A3 RID: 9123 RVA: 0x001FCB41 File Offset: 0x001FAD41
		// (set) Token: 0x060023A4 RID: 9124 RVA: 0x001FCB49 File Offset: 0x001FAD49
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

		// Token: 0x060023A5 RID: 9125 RVA: 0x001FCB52 File Offset: 0x001FAD52
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004C1B RID: 19483
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006D2 RID: 1746
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x060027A1 RID: 10145 RVA: 0x0020B5B8 File Offset: 0x002097B8
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
