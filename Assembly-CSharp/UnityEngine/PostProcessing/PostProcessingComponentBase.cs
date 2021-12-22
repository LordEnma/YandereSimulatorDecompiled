using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002359 RID: 9049 RVA: 0x001F1BBA File Offset: 0x001EFDBA
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x0600235A RID: 9050
		public abstract bool active { get; }

		// Token: 0x0600235B RID: 9051 RVA: 0x001F1BBD File Offset: 0x001EFDBD
		public virtual void OnEnable()
		{
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x001F1BBF File Offset: 0x001EFDBF
		public virtual void OnDisable()
		{
		}

		// Token: 0x0600235D RID: 9053
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004AE5 RID: 19173
		public PostProcessingContext context;
	}
}
