using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000580 RID: 1408
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023CA RID: 9162
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x060023CB RID: 9163
		public abstract string GetName();

		// Token: 0x060023CC RID: 9164
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
