using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000581 RID: 1409
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023CE RID: 9166 RVA: 0x001FA7F3 File Offset: 0x001F89F3
		public virtual void Prepare(Material material)
		{
		}
	}
}
