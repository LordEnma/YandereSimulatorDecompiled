using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x0600236D RID: 9069 RVA: 0x001F40BA File Offset: 0x001F22BA
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600236E RID: 9070
		public abstract bool active { get; }

		// Token: 0x0600236F RID: 9071 RVA: 0x001F40BD File Offset: 0x001F22BD
		public virtual void OnEnable()
		{
		}

		// Token: 0x06002370 RID: 9072 RVA: 0x001F40BF File Offset: 0x001F22BF
		public virtual void OnDisable()
		{
		}

		// Token: 0x06002371 RID: 9073
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B14 RID: 19220
		public PostProcessingContext context;
	}
}
