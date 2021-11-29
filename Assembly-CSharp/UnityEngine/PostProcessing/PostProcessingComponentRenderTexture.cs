using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002357 RID: 9047 RVA: 0x001F04D3 File Offset: 0x001EE6D3
		public virtual void Prepare(Material material)
		{
		}
	}
}
