using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002367 RID: 9063
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x06002368 RID: 9064
		public abstract string GetName();

		// Token: 0x06002369 RID: 9065
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
