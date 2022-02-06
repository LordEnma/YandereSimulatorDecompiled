using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06002378 RID: 9080 RVA: 0x001F45E5 File Offset: 0x001F27E5
		// (set) Token: 0x06002379 RID: 9081 RVA: 0x001F45ED File Offset: 0x001F27ED
		public T model { get; internal set; }

		// Token: 0x0600237A RID: 9082 RVA: 0x001F45F6 File Offset: 0x001F27F6
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x0600237B RID: 9083 RVA: 0x001F4606 File Offset: 0x001F2806
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
