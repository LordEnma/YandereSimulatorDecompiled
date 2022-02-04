using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x0600237A RID: 9082
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x0600237B RID: 9083
		public abstract string GetName();

		// Token: 0x0600237C RID: 9084
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
