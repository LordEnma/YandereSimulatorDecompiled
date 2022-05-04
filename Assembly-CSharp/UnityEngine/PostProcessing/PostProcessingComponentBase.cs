using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057F RID: 1407
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023C9 RID: 9161 RVA: 0x001FBD2E File Offset: 0x001F9F2E
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060023CA RID: 9162
		public abstract bool active { get; }

		// Token: 0x060023CB RID: 9163 RVA: 0x001FBD31 File Offset: 0x001F9F31
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x001FBD33 File Offset: 0x001F9F33
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023CD RID: 9165
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004C10 RID: 19472
		public PostProcessingContext context;
	}
}
