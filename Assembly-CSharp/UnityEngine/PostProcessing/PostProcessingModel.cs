using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002374 RID: 9076 RVA: 0x001F1C9D File Offset: 0x001EFE9D
		// (set) Token: 0x06002375 RID: 9077 RVA: 0x001F1CA5 File Offset: 0x001EFEA5
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

		// Token: 0x06002376 RID: 9078
		public abstract void Reset();

		// Token: 0x06002377 RID: 9079 RVA: 0x001F1CB7 File Offset: 0x001EFEB7
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004AEC RID: 19180
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
