using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002387 RID: 9095 RVA: 0x001F732B File Offset: 0x001F552B
		// (set) Token: 0x06002388 RID: 9096 RVA: 0x001F7333 File Offset: 0x001F5533
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

		// Token: 0x06002389 RID: 9097 RVA: 0x001F733C File Offset: 0x001F553C
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004B93 RID: 19347
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006D6 RID: 1750
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x06002773 RID: 10099 RVA: 0x00205C04 File Offset: 0x00203E04
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

			// Token: 0x040051FE RID: 20990
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x040051FF RID: 20991
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
