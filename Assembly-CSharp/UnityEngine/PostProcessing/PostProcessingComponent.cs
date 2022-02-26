using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06002388 RID: 9096 RVA: 0x001F5679 File Offset: 0x001F3879
		// (set) Token: 0x06002389 RID: 9097 RVA: 0x001F5681 File Offset: 0x001F3881
		public T model { get; internal set; }

		// Token: 0x0600238A RID: 9098 RVA: 0x001F568A File Offset: 0x001F388A
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x001F569A File Offset: 0x001F389A
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
