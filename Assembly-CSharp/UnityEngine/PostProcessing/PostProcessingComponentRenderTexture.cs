using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057B RID: 1403
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023AF RID: 9135 RVA: 0x001F7FF7 File Offset: 0x001F61F7
		public virtual void Prepare(Material material)
		{
		}
	}
}
