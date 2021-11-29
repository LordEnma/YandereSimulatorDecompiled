using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000569 RID: 1385
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x0600232F RID: 9007 RVA: 0x001EF807 File Offset: 0x001EDA07
		// (set) Token: 0x06002330 RID: 9008 RVA: 0x001EF80F File Offset: 0x001EDA0F
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

		// Token: 0x06002331 RID: 9009 RVA: 0x001EF818 File Offset: 0x001EDA18
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004A87 RID: 19079
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006CD RID: 1741
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x06002726 RID: 10022 RVA: 0x001FE6D8 File Offset: 0x001FC8D8
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

			// Token: 0x0400510F RID: 20751
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005110 RID: 20752
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
