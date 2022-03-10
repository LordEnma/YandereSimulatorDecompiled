using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002388 RID: 9096 RVA: 0x001F6042 File Offset: 0x001F4242
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06002389 RID: 9097
		public abstract bool active { get; }

		// Token: 0x0600238A RID: 9098 RVA: 0x001F6045 File Offset: 0x001F4245
		public virtual void OnEnable()
		{
		}

		// Token: 0x0600238B RID: 9099 RVA: 0x001F6047 File Offset: 0x001F4247
		public virtual void OnDisable()
		{
		}

		// Token: 0x0600238C RID: 9100
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B53 RID: 19283
		public PostProcessingContext context;
	}
}
