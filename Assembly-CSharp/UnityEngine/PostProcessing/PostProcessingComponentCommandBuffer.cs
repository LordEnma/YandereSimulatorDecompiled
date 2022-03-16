using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023AB RID: 9131
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x060023AC RID: 9132
		public abstract string GetName();

		// Token: 0x060023AD RID: 9133
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
