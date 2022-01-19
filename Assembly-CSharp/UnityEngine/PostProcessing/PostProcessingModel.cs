using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06002384 RID: 9092 RVA: 0x001F38FD File Offset: 0x001F1AFD
		// (set) Token: 0x06002385 RID: 9093 RVA: 0x001F3905 File Offset: 0x001F1B05
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

		// Token: 0x06002386 RID: 9094
		public abstract void Reset();

		// Token: 0x06002387 RID: 9095 RVA: 0x001F3917 File Offset: 0x001F1B17
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B10 RID: 19216
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
