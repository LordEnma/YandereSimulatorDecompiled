using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600236F RID: 9071 RVA: 0x001F53C3 File Offset: 0x001F35C3
		// (set) Token: 0x06002370 RID: 9072 RVA: 0x001F53CB File Offset: 0x001F35CB
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

		// Token: 0x06002371 RID: 9073 RVA: 0x001F53D4 File Offset: 0x001F35D4
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004B34 RID: 19252
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006D2 RID: 1746
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x0600275B RID: 10075 RVA: 0x00203C9C File Offset: 0x00201E9C
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

			// Token: 0x0400519F RID: 20895
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x040051A0 RID: 20896
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
