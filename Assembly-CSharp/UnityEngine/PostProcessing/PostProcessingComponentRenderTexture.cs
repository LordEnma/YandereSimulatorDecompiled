using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000582 RID: 1410
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023D8 RID: 9176 RVA: 0x001FBD7B File Offset: 0x001F9F7B
		public virtual void Prepare(Material material)
		{
		}
	}
}
