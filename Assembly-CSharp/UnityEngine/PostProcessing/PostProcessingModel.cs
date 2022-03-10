using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000579 RID: 1401
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x060023A3 RID: 9123 RVA: 0x001F6125 File Offset: 0x001F4325
		// (set) Token: 0x060023A4 RID: 9124 RVA: 0x001F612D File Offset: 0x001F432D
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

		// Token: 0x060023A5 RID: 9125
		public abstract void Reset();

		// Token: 0x060023A6 RID: 9126 RVA: 0x001F613F File Offset: 0x001F433F
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B5A RID: 19290
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
