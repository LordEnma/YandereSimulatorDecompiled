using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000582 RID: 1410
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023DF RID: 9183
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x060023E0 RID: 9184
		public abstract string GetName();

		// Token: 0x060023E1 RID: 9185
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
