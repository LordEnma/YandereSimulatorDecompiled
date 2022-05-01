using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	[Serializable]
	public class FogModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x0600239F RID: 9119 RVA: 0x001FAEEF File Offset: 0x001F90EF
		// (set) Token: 0x060023A0 RID: 9120 RVA: 0x001FAEF7 File Offset: 0x001F90F7
		public FogModel.Settings settings
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

		// Token: 0x060023A1 RID: 9121 RVA: 0x001FAF00 File Offset: 0x001F9100
		public override void Reset()
		{
			this.m_Settings = FogModel.Settings.defaultSettings;
		}

		// Token: 0x04004BED RID: 19437
		[SerializeField]
		private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

		// Token: 0x020006D4 RID: 1748
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A4 RID: 1444
			// (get) Token: 0x06002797 RID: 10135 RVA: 0x00209980 File Offset: 0x00207B80
			public static FogModel.Settings defaultSettings
			{
				get
				{
					return new FogModel.Settings
					{
						excludeSkybox = true
					};
				}
			}

			// Token: 0x04005246 RID: 21062
			[Tooltip("Should the fog affect the skybox?")]
			public bool excludeSkybox;
		}
	}
}
