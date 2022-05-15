using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000583 RID: 1411
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023E2 RID: 9186 RVA: 0x001FD3CB File Offset: 0x001FB5CB
		public virtual void Prepare(Material material)
		{
		}
	}
}
