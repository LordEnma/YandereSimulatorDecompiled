using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057F RID: 1407
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060023BE RID: 9150 RVA: 0x001F9D59 File Offset: 0x001F7F59
		// (set) Token: 0x060023BF RID: 9151 RVA: 0x001F9D61 File Offset: 0x001F7F61
		public T model { get; internal set; }

		// Token: 0x060023C0 RID: 9152 RVA: 0x001F9D6A File Offset: 0x001F7F6A
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x001F9D7A File Offset: 0x001F7F7A
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
