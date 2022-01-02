using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056B RID: 1387
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06002343 RID: 9027 RVA: 0x001F152B File Offset: 0x001EF72B
		// (set) Token: 0x06002344 RID: 9028 RVA: 0x001F1533 File Offset: 0x001EF733
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

		// Token: 0x06002345 RID: 9029 RVA: 0x001F153C File Offset: 0x001EF73C
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004ACF RID: 19151
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006D0 RID: 1744
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x0600273A RID: 10042 RVA: 0x00200420 File Offset: 0x001FE620
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

			// Token: 0x04005163 RID: 20835
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005164 RID: 20836
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
