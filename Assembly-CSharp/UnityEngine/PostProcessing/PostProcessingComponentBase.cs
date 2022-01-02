using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x0600235C RID: 9052 RVA: 0x001F21AA File Offset: 0x001F03AA
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600235D RID: 9053
		public abstract bool active { get; }

		// Token: 0x0600235E RID: 9054 RVA: 0x001F21AD File Offset: 0x001F03AD
		public virtual void OnEnable()
		{
		}

		// Token: 0x0600235F RID: 9055 RVA: 0x001F21AF File Offset: 0x001F03AF
		public virtual void OnDisable()
		{
		}

		// Token: 0x06002360 RID: 9056
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004AEE RID: 19182
		public PostProcessingContext context;
	}
}
