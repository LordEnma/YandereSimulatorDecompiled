using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06002350 RID: 9040 RVA: 0x001F2B9B File Offset: 0x001F0D9B
		// (set) Token: 0x06002351 RID: 9041 RVA: 0x001F2BA3 File Offset: 0x001F0DA3
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

		// Token: 0x06002352 RID: 9042 RVA: 0x001F2BAC File Offset: 0x001F0DAC
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004AEA RID: 19178
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006D3 RID: 1747
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x06002747 RID: 10055 RVA: 0x00201A90 File Offset: 0x001FFC90
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

			// Token: 0x0400517E RID: 20862
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x0400517F RID: 20863
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
