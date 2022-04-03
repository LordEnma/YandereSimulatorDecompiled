using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057D RID: 1405
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023B0 RID: 9136 RVA: 0x001F981A File Offset: 0x001F7A1A
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060023B1 RID: 9137
		public abstract bool active { get; }

		// Token: 0x060023B2 RID: 9138 RVA: 0x001F981D File Offset: 0x001F7A1D
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023B3 RID: 9139 RVA: 0x001F981F File Offset: 0x001F7A1F
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023B4 RID: 9140
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004BE4 RID: 19428
		public PostProcessingContext context;
	}
}
