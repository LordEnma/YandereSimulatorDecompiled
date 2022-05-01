using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000580 RID: 1408
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023CE RID: 9166 RVA: 0x001FBC41 File Offset: 0x001F9E41
		// (set) Token: 0x060023CF RID: 9167 RVA: 0x001FBC49 File Offset: 0x001F9E49
		public T model { get; internal set; }

		// Token: 0x060023D0 RID: 9168 RVA: 0x001FBC52 File Offset: 0x001F9E52
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023D1 RID: 9169 RVA: 0x001FBC62 File Offset: 0x001F9E62
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
