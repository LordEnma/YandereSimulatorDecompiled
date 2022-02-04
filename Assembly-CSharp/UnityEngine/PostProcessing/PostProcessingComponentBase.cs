using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x0600236F RID: 9071 RVA: 0x001F43D2 File Offset: 0x001F25D2
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06002370 RID: 9072
		public abstract bool active { get; }

		// Token: 0x06002371 RID: 9073 RVA: 0x001F43D5 File Offset: 0x001F25D5
		public virtual void OnEnable()
		{
		}

		// Token: 0x06002372 RID: 9074 RVA: 0x001F43D7 File Offset: 0x001F25D7
		public virtual void OnDisable()
		{
		}

		// Token: 0x06002373 RID: 9075
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B1A RID: 19226
		public PostProcessingContext context;
	}
}
