using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000584 RID: 1412
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060023E3 RID: 9187 RVA: 0x001FBD15 File Offset: 0x001F9F15
		// (set) Token: 0x060023E4 RID: 9188 RVA: 0x001FBD1D File Offset: 0x001F9F1D
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

		// Token: 0x060023E5 RID: 9189
		public abstract void Reset();

		// Token: 0x060023E6 RID: 9190 RVA: 0x001FBD2F File Offset: 0x001F9F2F
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004C17 RID: 19479
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
