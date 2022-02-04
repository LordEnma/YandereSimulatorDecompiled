using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x0600238A RID: 9098 RVA: 0x001F44B5 File Offset: 0x001F26B5
		// (set) Token: 0x0600238B RID: 9099 RVA: 0x001F44BD File Offset: 0x001F26BD
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

		// Token: 0x0600238C RID: 9100
		public abstract void Reset();

		// Token: 0x0600238D RID: 9101 RVA: 0x001F44CF File Offset: 0x001F26CF
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004B21 RID: 19233
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
