using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002372 RID: 9074 RVA: 0x001F45D6 File Offset: 0x001F27D6
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002373 RID: 9075
		public abstract bool active { get; }

		// Token: 0x06002374 RID: 9076 RVA: 0x001F45D9 File Offset: 0x001F27D9
		public virtual void OnEnable()
		{
		}

		// Token: 0x06002375 RID: 9077 RVA: 0x001F45DB File Offset: 0x001F27DB
		public virtual void OnDisable()
		{
		}

		// Token: 0x06002376 RID: 9078
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B1D RID: 19229
		public PostProcessingContext context;
	}
}
