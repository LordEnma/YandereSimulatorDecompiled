using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057E RID: 1406
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023B8 RID: 9144 RVA: 0x001F9D4A File Offset: 0x001F7F4A
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060023B9 RID: 9145
		public abstract bool active { get; }

		// Token: 0x060023BA RID: 9146 RVA: 0x001F9D4D File Offset: 0x001F7F4D
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023BB RID: 9147 RVA: 0x001F9D4F File Offset: 0x001F7F4F
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023BC RID: 9148
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004BE8 RID: 19432
		public PostProcessingContext context;
	}
}
