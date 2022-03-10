using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x0600235F RID: 9055 RVA: 0x001F52FF File Offset: 0x001F34FF
		// (set) Token: 0x06002360 RID: 9056 RVA: 0x001F5307 File Offset: 0x001F3507
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

		// Token: 0x06002361 RID: 9057 RVA: 0x001F5310 File Offset: 0x001F3510
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004B30 RID: 19248
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x06002757 RID: 10071 RVA: 0x00203B2C File Offset: 0x00201D2C
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

			// Token: 0x04005181 RID: 20865
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
