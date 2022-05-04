using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000580 RID: 1408
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023CF RID: 9167 RVA: 0x001FBD3D File Offset: 0x001F9F3D
		// (set) Token: 0x060023D0 RID: 9168 RVA: 0x001FBD45 File Offset: 0x001F9F45
		public T model { get; internal set; }

		// Token: 0x060023D1 RID: 9169 RVA: 0x001FBD4E File Offset: 0x001F9F4E
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x060023D2 RID: 9170 RVA: 0x001FBD5E File Offset: 0x001F9F5E
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
