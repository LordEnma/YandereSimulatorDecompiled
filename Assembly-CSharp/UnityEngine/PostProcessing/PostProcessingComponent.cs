using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x0600236D RID: 9069 RVA: 0x001F2B59 File Offset: 0x001F0D59
		// (set) Token: 0x0600236E RID: 9070 RVA: 0x001F2B61 File Offset: 0x001F0D61
		public T model { get; internal set; }

		// Token: 0x0600236F RID: 9071 RVA: 0x001F2B6A File Offset: 0x001F0D6A
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002370 RID: 9072 RVA: 0x001F2B7A File Offset: 0x001F0D7A
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
