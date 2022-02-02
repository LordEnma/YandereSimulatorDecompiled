using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x0600237C RID: 9084 RVA: 0x001F4107 File Offset: 0x001F2307
		public virtual void Prepare(Material material)
		{
		}
	}
}
