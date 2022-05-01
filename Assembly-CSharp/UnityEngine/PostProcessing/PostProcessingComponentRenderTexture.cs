using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000582 RID: 1410
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023D7 RID: 9175 RVA: 0x001FBC7F File Offset: 0x001F9E7F
		public virtual void Prepare(Material material)
		{
		}
	}
}
