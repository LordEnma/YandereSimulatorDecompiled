using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000585 RID: 1413
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x060023EF RID: 9199 RVA: 0x001FD9C9 File Offset: 0x001FBBC9
		// (set) Token: 0x060023F0 RID: 9200 RVA: 0x001FD9D1 File Offset: 0x001FBBD1
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

		// Token: 0x060023F1 RID: 9201
		public abstract void Reset();

		// Token: 0x060023F2 RID: 9202 RVA: 0x001FD9E3 File Offset: 0x001FBBE3
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004C47 RID: 19527
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
