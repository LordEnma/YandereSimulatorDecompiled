using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057F RID: 1407
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023C8 RID: 9160 RVA: 0x001FBC32 File Offset: 0x001F9E32
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060023C9 RID: 9161
		public abstract bool active { get; }

		// Token: 0x060023CA RID: 9162 RVA: 0x001FBC35 File Offset: 0x001F9E35
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x001FBC37 File Offset: 0x001F9E37
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023CC RID: 9164
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004C10 RID: 19472
		public PostProcessingContext context;
	}
}
