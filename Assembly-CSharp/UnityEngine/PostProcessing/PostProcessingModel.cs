using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06002363 RID: 9059 RVA: 0x001F0569 File Offset: 0x001EE769
		// (set) Token: 0x06002364 RID: 9060 RVA: 0x001F0571 File Offset: 0x001EE771
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

		// Token: 0x06002365 RID: 9061
		public abstract void Reset();

		// Token: 0x06002366 RID: 9062 RVA: 0x001F0583 File Offset: 0x001EE783
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004AAD RID: 19117
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
