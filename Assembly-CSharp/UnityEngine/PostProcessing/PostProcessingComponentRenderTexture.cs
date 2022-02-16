using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002388 RID: 9096 RVA: 0x001F4AD7 File Offset: 0x001F2CD7
		public virtual void Prepare(Material material)
		{
		}
	}
}
