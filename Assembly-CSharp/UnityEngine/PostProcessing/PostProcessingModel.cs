using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000583 RID: 1411
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060023D3 RID: 9171 RVA: 0x001F9E2D File Offset: 0x001F802D
		// (set) Token: 0x060023D4 RID: 9172 RVA: 0x001F9E35 File Offset: 0x001F8035
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

		// Token: 0x060023D5 RID: 9173
		public abstract void Reset();

		// Token: 0x060023D6 RID: 9174 RVA: 0x001F9E47 File Offset: 0x001F8047
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004BEF RID: 19439
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
