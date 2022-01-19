using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002378 RID: 9080 RVA: 0x001F3867 File Offset: 0x001F1A67
		public virtual void Prepare(Material material)
		{
		}
	}
}
