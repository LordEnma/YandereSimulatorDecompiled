using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x0600238E RID: 9102 RVA: 0x001F6051 File Offset: 0x001F4251
		// (set) Token: 0x0600238F RID: 9103 RVA: 0x001F6059 File Offset: 0x001F4259
		public T model { get; internal set; }

		// Token: 0x06002390 RID: 9104 RVA: 0x001F6062 File Offset: 0x001F4262
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002391 RID: 9105 RVA: 0x001F6072 File Offset: 0x001F4272
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
