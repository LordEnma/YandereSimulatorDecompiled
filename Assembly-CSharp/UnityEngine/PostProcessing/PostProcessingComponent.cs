using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600235F RID: 9055 RVA: 0x001F1BC9 File Offset: 0x001EFDC9
		// (set) Token: 0x06002360 RID: 9056 RVA: 0x001F1BD1 File Offset: 0x001EFDD1
		public T model { get; internal set; }

		// Token: 0x06002361 RID: 9057 RVA: 0x001F1BDA File Offset: 0x001EFDDA
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002362 RID: 9058 RVA: 0x001F1BEA File Offset: 0x001EFDEA
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
