using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002379 RID: 9081 RVA: 0x001F4A8A File Offset: 0x001F2C8A
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x0600237A RID: 9082
		public abstract bool active { get; }

		// Token: 0x0600237B RID: 9083 RVA: 0x001F4A8D File Offset: 0x001F2C8D
		public virtual void OnEnable()
		{
		}

		// Token: 0x0600237C RID: 9084 RVA: 0x001F4A8F File Offset: 0x001F2C8F
		public virtual void OnDisable()
		{
		}

		// Token: 0x0600237D RID: 9085
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B26 RID: 19238
		public PostProcessingContext context;
	}
}
