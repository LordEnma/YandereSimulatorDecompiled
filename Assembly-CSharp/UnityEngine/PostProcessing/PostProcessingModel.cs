using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x0600239D RID: 9117 RVA: 0x001F574D File Offset: 0x001F394D
		// (set) Token: 0x0600239E RID: 9118 RVA: 0x001F5755 File Offset: 0x001F3955
		public bool enabled
		{
			get
			{
				return this.m_Enabled;
			}
			set
			{
				this.m_Enabled = value;
				if (value)
				{
					this.OnValidate();
				}
			}
		}

		// Token: 0x0600239F RID: 9119
		public abstract void Reset();

		// Token: 0x060023A0 RID: 9120 RVA: 0x001F5767 File Offset: 0x001F3967
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B3D RID: 19261
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
