using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x0600237E RID: 9086 RVA: 0x001F441F File Offset: 0x001F261F
		public virtual void Prepare(Material material)
		{
		}
	}
}
