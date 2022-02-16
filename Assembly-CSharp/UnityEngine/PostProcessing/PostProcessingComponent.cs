using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	public abstract class PostProcessingComponent<T> : PostProcessingComponentBase where T : PostProcessingModel
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x0600237F RID: 9087 RVA: 0x001F4A99 File Offset: 0x001F2C99
		// (set) Token: 0x06002380 RID: 9088 RVA: 0x001F4AA1 File Offset: 0x001F2CA1
		public T model { get; internal set; }

		// Token: 0x06002381 RID: 9089 RVA: 0x001F4AAA File Offset: 0x001F2CAA
		public virtual void Init(PostProcessingContext pcontext, T pmodel)
		{
			this.context = pcontext;
			this.model = pmodel;
		}

		// Token: 0x06002382 RID: 9090 RVA: 0x001F4ABA File Offset: 0x001F2CBA
		public override PostProcessingModel GetModel()
		{
			return this.model;
		}
	}
}
