using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x0600234E RID: 9038 RVA: 0x001F1ECB File Offset: 0x001F00CB
		// (set) Token: 0x0600234F RID: 9039 RVA: 0x001F1ED3 File Offset: 0x001F00D3
		public UserLutModel.Settings settings
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

		// Token: 0x06002350 RID: 9040 RVA: 0x001F1EDC File Offset: 0x001F00DC
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE3 RID: 19171
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006D2 RID: 1746
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x06002745 RID: 10053 RVA: 0x00200DC0 File Offset: 0x001FEFC0
			public static UserLutModel.Settings defaultSettings
			{
				get
				{
					return new UserLutModel.Settings
					{
						lut = null,
						contribution = 1f
					};
				}
			}

			// Token: 0x04005177 RID: 20855
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005178 RID: 20856
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
