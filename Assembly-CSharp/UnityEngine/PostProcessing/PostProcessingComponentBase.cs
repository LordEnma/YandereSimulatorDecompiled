using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000580 RID: 1408
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023D3 RID: 9171 RVA: 0x001FD37E File Offset: 0x001FB57E
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023D4 RID: 9172
		public abstract bool active { get; }

		// Token: 0x060023D5 RID: 9173 RVA: 0x001FD381 File Offset: 0x001FB581
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023D6 RID: 9174 RVA: 0x001FD383 File Offset: 0x001FB583
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023D7 RID: 9175
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004C37 RID: 19511
		public PostProcessingContext context;
	}
}
