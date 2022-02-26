using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002391 RID: 9105 RVA: 0x001F56B7 File Offset: 0x001F38B7
		public virtual void Prepare(Material material)
		{
		}
	}
}
