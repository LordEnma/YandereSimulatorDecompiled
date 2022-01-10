using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002376 RID: 9078 RVA: 0x001F2B97 File Offset: 0x001F0D97
		public virtual void Prepare(Material material)
		{
		}
	}
}
