using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022F7 RID: 8951 RVA: 0x001F6D58 File Offset: 0x001F4F58
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004BB0 RID: 19376
		public readonly float min;
	}
}
