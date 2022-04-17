using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057B RID: 1403
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060023A6 RID: 9126 RVA: 0x001F9B27 File Offset: 0x001F7D27
		// (set) Token: 0x060023A7 RID: 9127 RVA: 0x001F9B2F File Offset: 0x001F7D2F
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

		// Token: 0x060023A8 RID: 9128 RVA: 0x001F9B38 File Offset: 0x001F7D38
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004BDB RID: 19419
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006DC RID: 1756
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A8 RID: 1448
			// (get) Token: 0x06002792 RID: 10130 RVA: 0x00208550 File Offset: 0x00206750
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

			// Token: 0x04005246 RID: 21062
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005247 RID: 21063
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
