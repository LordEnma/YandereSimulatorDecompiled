using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057D RID: 1405
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060023BB RID: 9147 RVA: 0x001F808D File Offset: 0x001F628D
		// (set) Token: 0x060023BC RID: 9148 RVA: 0x001F8095 File Offset: 0x001F6295
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

		// Token: 0x060023BD RID: 9149
		public abstract void Reset();

		// Token: 0x060023BE RID: 9150 RVA: 0x001F80A7 File Offset: 0x001F62A7
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004BB9 RID: 19385
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
