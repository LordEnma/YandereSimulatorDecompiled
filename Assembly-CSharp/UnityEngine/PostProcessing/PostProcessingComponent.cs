using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002373 RID: 9075 RVA: 0x001F40C9 File Offset: 0x001F22C9
		// (set) Token: 0x06002374 RID: 9076 RVA: 0x001F40D1 File Offset: 0x001F22D1
		public T model { get; internal set; }

		// Token: 0x06002375 RID: 9077 RVA: 0x001F40DA File Offset: 0x001F22DA
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002376 RID: 9078 RVA: 0x001F40EA File Offset: 0x001F22EA
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
