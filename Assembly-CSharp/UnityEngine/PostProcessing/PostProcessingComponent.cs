using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057E RID: 1406
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060023B6 RID: 9142 RVA: 0x001F9829 File Offset: 0x001F7A29
		// (set) Token: 0x060023B7 RID: 9143 RVA: 0x001F9831 File Offset: 0x001F7A31
		public T model { get; internal set; }

		// Token: 0x060023B8 RID: 9144 RVA: 0x001F983A File Offset: 0x001F7A3A
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023B9 RID: 9145 RVA: 0x001F984A File Offset: 0x001F7A4A
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
