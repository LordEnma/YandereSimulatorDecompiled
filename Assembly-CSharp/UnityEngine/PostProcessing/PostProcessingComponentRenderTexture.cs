using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002381 RID: 9089 RVA: 0x001F4623 File Offset: 0x001F2823
		public virtual void Prepare(Material material)
		{
		}
	}
}
