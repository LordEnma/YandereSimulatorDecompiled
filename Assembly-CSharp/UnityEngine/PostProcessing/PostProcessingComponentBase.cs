using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x06002369 RID: 9065 RVA: 0x001F381A File Offset: 0x001F1A1A
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600236A RID: 9066
		public abstract bool active { get; }

		// Token: 0x0600236B RID: 9067 RVA: 0x001F381D File Offset: 0x001F1A1D
		public virtual void OnEnable()
		{
		}

		// Token: 0x0600236C RID: 9068 RVA: 0x001F381F File Offset: 0x001F1A1F
		public virtual void OnDisable()
		{
		}

		// Token: 0x0600236D RID: 9069
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004B09 RID: 19209
		public PostProcessingContext context;
	}
}
