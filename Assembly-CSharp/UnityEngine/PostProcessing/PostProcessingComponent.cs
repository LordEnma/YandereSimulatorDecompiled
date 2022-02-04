using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002375 RID: 9077 RVA: 0x001F43E1 File Offset: 0x001F25E1
		// (set) Token: 0x06002376 RID: 9078 RVA: 0x001F43E9 File Offset: 0x001F25E9
		public T model { get; internal set; }

		// Token: 0x06002377 RID: 9079 RVA: 0x001F43F2 File Offset: 0x001F25F2
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002378 RID: 9080 RVA: 0x001F4402 File Offset: 0x001F2602
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
