using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x0600236B RID: 9067 RVA: 0x001F21F7 File Offset: 0x001F03F7
		public virtual void Prepare(Material material)
		{
		}
	}
}
