using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002384 RID: 9092
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x06002385 RID: 9093
		public abstract string GetName();

		// Token: 0x06002386 RID: 9094
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
