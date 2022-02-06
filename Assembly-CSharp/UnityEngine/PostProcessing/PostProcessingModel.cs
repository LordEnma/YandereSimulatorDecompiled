using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x0600238D RID: 9101 RVA: 0x001F46B9 File Offset: 0x001F28B9
		// (set) Token: 0x0600238E RID: 9102 RVA: 0x001F46C1 File Offset: 0x001F28C1
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

		// Token: 0x0600238F RID: 9103
		public abstract void Reset();

		// Token: 0x06002390 RID: 9104 RVA: 0x001F46D3 File Offset: 0x001F28D3
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B24 RID: 19236
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
