using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057D RID: 1405
	[Serializable]
	public class UserLutModel : PostProcessingModel
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060023BA RID: 9146 RVA: 0x001FC6FF File Offset: 0x001FA8FF
		// (set) Token: 0x060023BB RID: 9147 RVA: 0x001FC707 File Offset: 0x001FA907
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

		// Token: 0x060023BC RID: 9148 RVA: 0x001FC710 File Offset: 0x001FA910
		public override void Reset()
		{
			this.m_Settings = UserLutModel.Settings.defaultSettings;
		}

		// Token: 0x04004C18 RID: 19480
		[SerializeField]
		private UserLutModel.Settings m_Settings = UserLutModel.Settings.defaultSettings;

		// Token: 0x020006DE RID: 1758
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A9 RID: 1449
			// (get) Token: 0x060027A6 RID: 10150 RVA: 0x0020B23C File Offset: 0x0020943C
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

			// Token: 0x0400528B RID: 21131
			[Tooltip("Custom lookup texture (strip format, e.g. 256x16).")]
			public Texture2D lut;

			// Token: 0x0400528C RID: 21132
			[Range(0f, 1f)]
			[Tooltip("Blending factor.")]
			public float contribution;
		}
	}
}
