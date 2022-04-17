using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000583 RID: 1411
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060023DA RID: 9178 RVA: 0x001FA889 File Offset: 0x001F8A89
		// (set) Token: 0x060023DB RID: 9179 RVA: 0x001FA891 File Offset: 0x001F8A91
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

		// Token: 0x060023DC RID: 9180
		public abstract void Reset();

		// Token: 0x060023DD RID: 9181 RVA: 0x001FA8A3 File Offset: 0x001F8AA3
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004C01 RID: 19457
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
