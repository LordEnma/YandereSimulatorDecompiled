using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000578 RID: 1400
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023A0 RID: 9120 RVA: 0x001F7FAA File Offset: 0x001F61AA
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060023A1 RID: 9121
		public abstract bool active { get; }

		// Token: 0x060023A2 RID: 9122 RVA: 0x001F7FAD File Offset: 0x001F61AD
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023A3 RID: 9123 RVA: 0x001F7FAF File Offset: 0x001F61AF
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023A4 RID: 9124
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004BB2 RID: 19378
		public PostProcessingContext context;
	}
}
