using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057D RID: 1405
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060023BB RID: 9147 RVA: 0x001FCC67 File Offset: 0x001FAE67
		// (set) Token: 0x060023BC RID: 9148 RVA: 0x001FCC6F File Offset: 0x001FAE6F
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

		// Token: 0x060023BD RID: 9149 RVA: 0x001FCC78 File Offset: 0x001FAE78
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004C21 RID: 19489
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006DE RID: 1758
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A9 RID: 1449
			// (get) Token: 0x060027A7 RID: 10151 RVA: 0x0020B7CC File Offset: 0x002099CC
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

			// Token: 0x04005294 RID: 21140
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x04005295 RID: 21141
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
