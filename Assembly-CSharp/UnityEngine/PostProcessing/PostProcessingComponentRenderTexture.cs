using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000583 RID: 1411
	public abstract class PostProcessingComponentRenderTexture<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023E3 RID: 9187 RVA: 0x001FD933 File Offset: 0x001FBB33
		public virtual void Prepare(Material material)
		{
		}
	}
}
