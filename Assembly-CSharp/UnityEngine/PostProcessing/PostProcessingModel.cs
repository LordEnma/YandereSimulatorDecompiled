using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06002388 RID: 9096 RVA: 0x001F419D File Offset: 0x001F239D
		// (set) Token: 0x06002389 RID: 9097 RVA: 0x001F41A5 File Offset: 0x001F23A5
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

		// Token: 0x0600238A RID: 9098
		public abstract void Reset();

		// Token: 0x0600238B RID: 9099 RVA: 0x001F41B7 File Offset: 0x001F23B7
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B1B RID: 19227
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
