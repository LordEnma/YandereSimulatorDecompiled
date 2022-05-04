using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000581 RID: 1409
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x060023D4 RID: 9172
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x060023D5 RID: 9173
		public abstract string GetName();

		// Token: 0x060023D6 RID: 9174
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
