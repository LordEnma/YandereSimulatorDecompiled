using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600234E RID: 9038 RVA: 0x001F0495 File Offset: 0x001EE695
		// (set) Token: 0x0600234F RID: 9039 RVA: 0x001F049D File Offset: 0x001EE69D
		public T model { get; internal set; }

		// Token: 0x06002350 RID: 9040 RVA: 0x001F04A6 File Offset: 0x001EE6A6
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002351 RID: 9041 RVA: 0x001F04B6 File Offset: 0x001EE6B6
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
