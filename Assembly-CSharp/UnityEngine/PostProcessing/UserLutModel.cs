using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057C RID: 1404
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x060023AF RID: 9135 RVA: 0x001FAFB3 File Offset: 0x001F91B3
		// (set) Token: 0x060023B0 RID: 9136 RVA: 0x001FAFBB File Offset: 0x001F91BB
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

		// Token: 0x060023B1 RID: 9137 RVA: 0x001FAFC4 File Offset: 0x001F91C4
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004BF1 RID: 19441
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006DD RID: 1757
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A8 RID: 1448
			// (get) Token: 0x0600279B RID: 10139 RVA: 0x00209AF0 File Offset: 0x00207CF0
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

			// Token: 0x04005264 RID: 21092
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005265 RID: 21093
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
