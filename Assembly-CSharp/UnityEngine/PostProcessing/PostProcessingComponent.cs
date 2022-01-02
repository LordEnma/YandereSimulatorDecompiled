using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002362 RID: 9058 RVA: 0x001F21B9 File Offset: 0x001F03B9
		// (set) Token: 0x06002363 RID: 9059 RVA: 0x001F21C1 File Offset: 0x001F03C1
		public T model { get; internal set; }

		// Token: 0x06002364 RID: 9060 RVA: 0x001F21CA File Offset: 0x001F03CA
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002365 RID: 9061 RVA: 0x001F21DA File Offset: 0x001F03DA
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
