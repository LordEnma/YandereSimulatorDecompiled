using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000579 RID: 1401
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060023A6 RID: 9126 RVA: 0x001F7FB9 File Offset: 0x001F61B9
		// (set) Token: 0x060023A7 RID: 9127 RVA: 0x001F7FC1 File Offset: 0x001F61C1
		public T model { get; internal set; }

		// Token: 0x060023A8 RID: 9128 RVA: 0x001F7FCA File Offset: 0x001F61CA
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023A9 RID: 9129 RVA: 0x001F7FDA File Offset: 0x001F61DA
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
