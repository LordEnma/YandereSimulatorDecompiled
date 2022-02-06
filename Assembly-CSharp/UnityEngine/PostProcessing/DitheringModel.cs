using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000568 RID: 1384
	[Serializable]
	public class DitheringModel : PostProcessingModel
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002341 RID: 9025 RVA: 0x001F3831 File Offset: 0x001F1A31
		// (set) Token: 0x06002342 RID: 9026 RVA: 0x001F3839 File Offset: 0x001F1A39
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

		// Token: 0x06002343 RID: 9027 RVA: 0x001F3842 File Offset: 0x001F1A42
		public override void Reset()
		{
			this.m_Settings = DitheringModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF8 RID: 19192
		[SerializeField]
		private DitheringModel.Settings m_Settings = DitheringModel.Settings.defaultSettings;

		// Token: 0x020006C1 RID: 1729
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002736 RID: 10038 RVA: 0x00201F54 File Offset: 0x00200154
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
