using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06002333 RID: 9011 RVA: 0x001F1467 File Offset: 0x001EF667
		// (set) Token: 0x06002334 RID: 9012 RVA: 0x001F146F File Offset: 0x001EF66F
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

		// Token: 0x06002335 RID: 9013 RVA: 0x001F1478 File Offset: 0x001EF678
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004ACB RID: 19147
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006C7 RID: 1735
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059E RID: 1438
			// (get) Token: 0x06002736 RID: 10038 RVA: 0x002002B0 File Offset: 0x001FE4B0
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

			// Token: 0x04005145 RID: 20805
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
