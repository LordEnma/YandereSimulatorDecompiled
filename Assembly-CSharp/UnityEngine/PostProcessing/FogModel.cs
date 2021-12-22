using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002330 RID: 9008 RVA: 0x001F0E77 File Offset: 0x001EF077
		// (set) Token: 0x06002331 RID: 9009 RVA: 0x001F0E7F File Offset: 0x001EF07F
		public FogModel.Settings settings
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

		// Token: 0x06002332 RID: 9010 RVA: 0x001F0E88 File Offset: 0x001EF088
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004AC2 RID: 19138
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002733 RID: 10035 RVA: 0x001FFC9C File Offset: 0x001FDE9C
			public static FogModel.Settings defaultSettings
			{
				get
				{
					return new FogModel.Settings
					{
						excludeSkybox = true
					};
				}
			}

			// Token: 0x0400513C RID: 20796
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
