using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06002387 RID: 9095 RVA: 0x001F8AD7 File Offset: 0x001F6CD7
		// (set) Token: 0x06002388 RID: 9096 RVA: 0x001F8ADF File Offset: 0x001F6CDF
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

		// Token: 0x06002389 RID: 9097 RVA: 0x001F8AE8 File Offset: 0x001F6CE8
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004BC1 RID: 19393
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006D2 RID: 1746
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x0600277F RID: 10111 RVA: 0x00207454 File Offset: 0x00205654
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

			// Token: 0x04005212 RID: 21010
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
