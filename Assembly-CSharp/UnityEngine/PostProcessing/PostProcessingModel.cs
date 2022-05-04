using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000584 RID: 1412
	[Serializable]
	public abstract class PostProcessingModel
	{
		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x060023E4 RID: 9188 RVA: 0x001FBE11 File Offset: 0x001FA011
		// (set) Token: 0x060023E5 RID: 9189 RVA: 0x001FBE19 File Offset: 0x001FA019
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

		// Token: 0x060023E6 RID: 9190
		public abstract void Reset();

		// Token: 0x060023E7 RID: 9191 RVA: 0x001FBE2B File Offset: 0x001FA02B
		public virtual void OnValidate()
		{
		}

		// Token: 0x04004C17 RID: 19479
		[SerializeField]
		[GetSet("enabled")]
		private bool m_Enabled;
	}
}
