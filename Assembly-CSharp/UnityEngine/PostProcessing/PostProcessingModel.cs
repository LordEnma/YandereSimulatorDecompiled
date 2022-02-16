using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06002394 RID: 9108 RVA: 0x001F4B6D File Offset: 0x001F2D6D
		// (set) Token: 0x06002395 RID: 9109 RVA: 0x001F4B75 File Offset: 0x001F2D75
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

		// Token: 0x06002396 RID: 9110
		public abstract void Reset();

		// Token: 0x06002397 RID: 9111 RVA: 0x001F4B87 File Offset: 0x001F2D87
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B2D RID: 19245
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
