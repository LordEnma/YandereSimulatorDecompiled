using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	public abstract class PostProcessingComponentCommandBuffer<T> : PostProcessingComponent<T> where T : PostProcessingModel
	{
		// Token: 0x06002364 RID: 9060
		public abstract CameraEvent GetCameraEvent();

		// Token: 0x06002365 RID: 9061
		public abstract string GetName();

		// Token: 0x06002366 RID: 9062
		public abstract void PopulateCommandBuffer(CommandBuffer cb);
	}
}
