using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06002369 RID: 9065 RVA: 0x001F49EB File Offset: 0x001F2BEB
		// (set) Token: 0x0600236A RID: 9066 RVA: 0x001F49F3 File Offset: 0x001F2BF3
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

		// Token: 0x0600236B RID: 9067 RVA: 0x001F49FC File Offset: 0x001F2BFC
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004B17 RID: 19223
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006D1 RID: 1745
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x06002755 RID: 10069 RVA: 0x002032C4 File Offset: 0x002014C4
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

			// Token: 0x04005182 RID: 20866
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005183 RID: 20867
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
