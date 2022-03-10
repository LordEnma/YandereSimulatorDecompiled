using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000577 RID: 1399
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002397 RID: 9111 RVA: 0x001F608F File Offset: 0x001F428F
		public virtual void Prepare(Material material)
		{
		}
	}
}
