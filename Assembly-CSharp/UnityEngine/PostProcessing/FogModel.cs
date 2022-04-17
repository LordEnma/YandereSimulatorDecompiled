using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06002396 RID: 9110 RVA: 0x001F9A63 File Offset: 0x001F7C63
		// (set) Token: 0x06002397 RID: 9111 RVA: 0x001F9A6B File Offset: 0x001F7C6B
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

		// Token: 0x06002398 RID: 9112 RVA: 0x001F9A74 File Offset: 0x001F7C74
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004BD7 RID: 19415
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006D3 RID: 1747
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A4 RID: 1444
			// (get) Token: 0x0600278E RID: 10126 RVA: 0x002083E0 File Offset: 0x002065E0
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

			// Token: 0x04005228 RID: 21032
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
