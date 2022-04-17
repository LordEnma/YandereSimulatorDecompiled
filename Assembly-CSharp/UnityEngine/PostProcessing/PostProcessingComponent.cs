using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057F RID: 1407
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023C5 RID: 9157 RVA: 0x001FA7B5 File Offset: 0x001F89B5
		// (set) Token: 0x060023C6 RID: 9158 RVA: 0x001FA7BD File Offset: 0x001F89BD
		public T model { get; internal set; }

		// Token: 0x060023C7 RID: 9159 RVA: 0x001FA7C6 File Offset: 0x001F89C6
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x001FA7D6 File Offset: 0x001F89D6
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
