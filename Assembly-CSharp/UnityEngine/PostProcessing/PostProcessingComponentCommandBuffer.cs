using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x0600238D RID: 9101
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x0600238E RID: 9102
		public abstract string GetName();

		// Token: 0x0600238F RID: 9103
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
