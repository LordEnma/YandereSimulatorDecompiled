using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000580 RID: 1408
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023C3 RID: 9155
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x060023C4 RID: 9156
		public abstract string GetName();

		// Token: 0x060023C5 RID: 9157
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
