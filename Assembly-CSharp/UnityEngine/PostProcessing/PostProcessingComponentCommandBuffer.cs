using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002353 RID: 9043
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x06002354 RID: 9044
		public abstract string GetName();

		// Token: 0x06002355 RID: 9045
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
