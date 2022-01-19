using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x0600236F RID: 9071 RVA: 0x001F3829 File Offset: 0x001F1A29
		// (set) Token: 0x06002370 RID: 9072 RVA: 0x001F3831 File Offset: 0x001F1A31
		public T model { get; internal set; }

		// Token: 0x06002371 RID: 9073 RVA: 0x001F383A File Offset: 0x001F1A3A
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x001F384A File Offset: 0x001F1A4A
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
