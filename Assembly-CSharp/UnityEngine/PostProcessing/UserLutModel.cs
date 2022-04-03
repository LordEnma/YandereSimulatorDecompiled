using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002397 RID: 9111 RVA: 0x001F8B9B File Offset: 0x001F6D9B
		// (set) Token: 0x06002398 RID: 9112 RVA: 0x001F8BA3 File Offset: 0x001F6DA3
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

		// Token: 0x06002399 RID: 9113 RVA: 0x001F8BAC File Offset: 0x001F6DAC
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004BC5 RID: 19397
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006DB RID: 1755
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x06002783 RID: 10115 RVA: 0x002075C4 File Offset: 0x002057C4
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

			// Token: 0x04005230 RID: 21040
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005231 RID: 21041
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
