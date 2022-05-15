using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000585 RID: 1413
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x060023EE RID: 9198 RVA: 0x001FD461 File Offset: 0x001FB661
		// (set) Token: 0x060023EF RID: 9199 RVA: 0x001FD469 File Offset: 0x001FB669
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

		// Token: 0x060023F0 RID: 9200
		public abstract void Reset();

		// Token: 0x060023F1 RID: 9201 RVA: 0x001FD47B File Offset: 0x001FB67B
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004C3E RID: 19518
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
