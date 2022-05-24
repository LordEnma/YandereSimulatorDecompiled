using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000581 RID: 1409
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x060023DA RID: 9178 RVA: 0x001FD8F5 File Offset: 0x001FBAF5
		// (set) Token: 0x060023DB RID: 9179 RVA: 0x001FD8FD File Offset: 0x001FBAFD
		public T model { get; internal set; }

		// Token: 0x060023DC RID: 9180 RVA: 0x001FD906 File Offset: 0x001FBB06
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x001FD916 File Offset: 0x001FBB16
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
