using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002382 RID: 9090 RVA: 0x001F566A File Offset: 0x001F386A
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06002383 RID: 9091
		public abstract bool active { get; }

		// Token: 0x06002384 RID: 9092 RVA: 0x001F566D File Offset: 0x001F386D
		public virtual void OnEnable()
		{
		}

		// Token: 0x06002385 RID: 9093 RVA: 0x001F566F File Offset: 0x001F386F
		public virtual void OnDisable()
		{
		}

		// Token: 0x06002386 RID: 9094
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B36 RID: 19254
		public PostProcessingContext context;
	}
}
