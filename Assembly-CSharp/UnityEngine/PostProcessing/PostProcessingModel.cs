using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000582 RID: 1410
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x060023CB RID: 9163 RVA: 0x001F98FD File Offset: 0x001F7AFD
		// (set) Token: 0x060023CC RID: 9164 RVA: 0x001F9905 File Offset: 0x001F7B05
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

		// Token: 0x060023CD RID: 9165
		public abstract void Reset();

		// Token: 0x060023CE RID: 9166 RVA: 0x001F9917 File Offset: 0x001F7B17
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004BEB RID: 19435
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
