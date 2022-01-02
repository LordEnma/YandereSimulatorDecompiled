using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06002377 RID: 9079 RVA: 0x001F228D File Offset: 0x001F048D
		// (set) Token: 0x06002378 RID: 9080 RVA: 0x001F2295 File Offset: 0x001F0495
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

		// Token: 0x06002379 RID: 9081
		public abstract void Reset();

		// Token: 0x0600237A RID: 9082 RVA: 0x001F22A7 File Offset: 0x001F04A7
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004AF5 RID: 19189
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
