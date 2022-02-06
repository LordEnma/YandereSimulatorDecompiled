using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06002359 RID: 9049 RVA: 0x001F3957 File Offset: 0x001F1B57
		// (set) Token: 0x0600235A RID: 9050 RVA: 0x001F395F File Offset: 0x001F1B5F
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

		// Token: 0x0600235B RID: 9051 RVA: 0x001F3968 File Offset: 0x001F1B68
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004AFE RID: 19198
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006CD RID: 1741
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x0600273C RID: 10044 RVA: 0x00202168 File Offset: 0x00200368
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

			// Token: 0x04005164 RID: 20836
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005165 RID: 20837
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
