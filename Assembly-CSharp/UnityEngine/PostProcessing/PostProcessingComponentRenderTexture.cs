using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000581 RID: 1409
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023C7 RID: 9159 RVA: 0x001F9D97 File Offset: 0x001F7F97
		public virtual void Prepare(Material material)
		{
		}
	}
}
