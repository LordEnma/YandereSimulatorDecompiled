using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002368 RID: 9064 RVA: 0x001F1C07 File Offset: 0x001EFE07
		public virtual void Prepare(Material material)
		{
		}
	}
}
