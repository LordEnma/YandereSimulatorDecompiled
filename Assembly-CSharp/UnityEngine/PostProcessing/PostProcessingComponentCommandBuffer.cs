using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002372 RID: 9074
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x06002373 RID: 9075
		public abstract string GetName();

		// Token: 0x06002374 RID: 9076
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
