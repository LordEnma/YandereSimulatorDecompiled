using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057F RID: 1407
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023BB RID: 9147
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x060023BC RID: 9148
		public abstract string GetName();

		// Token: 0x060023BD RID: 9149
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
