using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056A RID: 1386
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002344 RID: 9028 RVA: 0x001F3377 File Offset: 0x001F1577
		// (set) Token: 0x06002345 RID: 9029 RVA: 0x001F337F File Offset: 0x001F157F
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

		// Token: 0x06002346 RID: 9030 RVA: 0x001F3388 File Offset: 0x001F1588
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF1 RID: 19185
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006C4 RID: 1732
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002733 RID: 10035 RVA: 0x00201ADC File Offset: 0x001FFCDC
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

			// Token: 0x0400513D RID: 20797
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
