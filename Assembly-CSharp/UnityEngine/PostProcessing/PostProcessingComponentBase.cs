using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002367 RID: 9063 RVA: 0x001F2B4A File Offset: 0x001F0D4A
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06002368 RID: 9064
		public abstract bool active { get; }

		// Token: 0x06002369 RID: 9065 RVA: 0x001F2B4D File Offset: 0x001F0D4D
		public virtual void OnEnable()
		{
		}

		// Token: 0x0600236A RID: 9066 RVA: 0x001F2B4F File Offset: 0x001F0D4F
		public virtual void OnDisable()
		{
		}

		// Token: 0x0600236B RID: 9067
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B02 RID: 19202
		public PostProcessingContext context;
	}
}
