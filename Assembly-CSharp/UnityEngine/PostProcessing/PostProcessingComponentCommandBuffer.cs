using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002393 RID: 9107
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x06002394 RID: 9108
		public abstract string GetName();

		// Token: 0x06002395 RID: 9109
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
