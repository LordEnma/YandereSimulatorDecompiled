using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002348 RID: 9032 RVA: 0x001F0486 File Offset: 0x001EE686
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06002349 RID: 9033
		public abstract bool active { get; }

		// Token: 0x0600234A RID: 9034 RVA: 0x001F0489 File Offset: 0x001EE689
		public virtual void OnEnable()
		{
		}

		// Token: 0x0600234B RID: 9035 RVA: 0x001F048B File Offset: 0x001EE68B
		public virtual void OnDisable()
		{
		}

		// Token: 0x0600234C RID: 9036
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004AA6 RID: 19110
		public PostProcessingContext context;
	}
}
