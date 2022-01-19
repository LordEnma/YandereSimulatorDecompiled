using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056A RID: 1386
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002340 RID: 9024 RVA: 0x001F2AD7 File Offset: 0x001F0CD7
		// (set) Token: 0x06002341 RID: 9025 RVA: 0x001F2ADF File Offset: 0x001F0CDF
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

		// Token: 0x06002342 RID: 9026 RVA: 0x001F2AE8 File Offset: 0x001F0CE8
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE6 RID: 19174
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006CA RID: 1738
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002743 RID: 10051 RVA: 0x00201920 File Offset: 0x001FFB20
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

			// Token: 0x04005160 RID: 20832
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
