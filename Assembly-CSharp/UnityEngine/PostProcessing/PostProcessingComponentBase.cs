using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000580 RID: 1408
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023D4 RID: 9172 RVA: 0x001FD8E6 File Offset: 0x001FBAE6
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x060023D5 RID: 9173
		public abstract bool active { get; }

		// Token: 0x060023D6 RID: 9174 RVA: 0x001FD8E9 File Offset: 0x001FBAE9
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023D7 RID: 9175 RVA: 0x001FD8EB File Offset: 0x001FBAEB
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023D8 RID: 9176
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004C40 RID: 19520
		public PostProcessingContext context;
	}
}
