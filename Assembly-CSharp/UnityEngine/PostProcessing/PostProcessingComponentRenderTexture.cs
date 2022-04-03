using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000580 RID: 1408
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023BF RID: 9151 RVA: 0x001F9867 File Offset: 0x001F7A67
		public virtual void Prepare(Material material)
		{
		}
	}
}
