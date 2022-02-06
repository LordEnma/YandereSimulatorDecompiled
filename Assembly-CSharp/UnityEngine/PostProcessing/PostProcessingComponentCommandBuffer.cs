using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x0600237D RID: 9085
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x0600237E RID: 9086
		public abstract string GetName();

		// Token: 0x0600237F RID: 9087
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
