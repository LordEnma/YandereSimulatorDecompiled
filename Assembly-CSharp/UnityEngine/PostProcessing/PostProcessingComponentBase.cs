using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057E RID: 1406
	public abstract class PostProcessingComponentBase
	{
		// Token: 0x060023BF RID: 9151 RVA: 0x001FA7A6 File Offset: 0x001F89A6
		public virtual DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.None;
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060023C0 RID: 9152
		public abstract bool active { get; }

		// Token: 0x060023C1 RID: 9153 RVA: 0x001FA7A9 File Offset: 0x001F89A9
		public virtual void OnEnable()
		{
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x001FA7AB File Offset: 0x001F89AB
		public virtual void OnDisable()
		{
		}

		// Token: 0x060023C3 RID: 9155
		public abstract PostProcessingModel GetModel();

		// Token: 0x04004BFA RID: 19450
		public PostProcessingContext context;
	}
}
