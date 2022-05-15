using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000581 RID: 1409
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060023D9 RID: 9177 RVA: 0x001FD38D File Offset: 0x001FB58D
		// (set) Token: 0x060023DA RID: 9178 RVA: 0x001FD395 File Offset: 0x001FB595
		public T model { get; internal set; }

		// Token: 0x060023DB RID: 9179 RVA: 0x001FD39E File Offset: 0x001FB59E
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x001FD3AE File Offset: 0x001FB5AE
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
