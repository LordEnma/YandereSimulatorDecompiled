using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002374 RID: 9076
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x06002375 RID: 9077
		public abstract string GetName();

		// Token: 0x06002376 RID: 9078
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
