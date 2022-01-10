using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06002382 RID: 9090 RVA: 0x001F2C2D File Offset: 0x001F0E2D
		// (set) Token: 0x06002383 RID: 9091 RVA: 0x001F2C35 File Offset: 0x001F0E35
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

		// Token: 0x06002384 RID: 9092
		public abstract void Reset();

		// Token: 0x06002385 RID: 9093 RVA: 0x001F2C47 File Offset: 0x001F0E47
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B09 RID: 19209
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
