using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000565 RID: 1381
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x0600231F RID: 8991 RVA: 0x001EF743 File Offset: 0x001ED943
		// (set) Token: 0x06002320 RID: 8992 RVA: 0x001EF74B File Offset: 0x001ED94B
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

		// Token: 0x06002321 RID: 8993 RVA: 0x001EF754 File Offset: 0x001ED954
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004A83 RID: 19075
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006C4 RID: 1732
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002722 RID: 10018 RVA: 0x001FE568 File Offset: 0x001FC768
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

			// Token: 0x040050F1 RID: 20721
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
