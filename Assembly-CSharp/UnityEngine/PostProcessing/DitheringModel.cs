using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002328 RID: 9000 RVA: 0x001F0E15 File Offset: 0x001EF015
		// (set) Token: 0x06002329 RID: 9001 RVA: 0x001F0E1D File Offset: 0x001EF01D
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

		// Token: 0x0600232A RID: 9002 RVA: 0x001F0E26 File Offset: 0x001EF026
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004AC0 RID: 19136
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C4 RID: 1732
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002731 RID: 10033 RVA: 0x001FFBF8 File Offset: 0x001FDDF8
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
