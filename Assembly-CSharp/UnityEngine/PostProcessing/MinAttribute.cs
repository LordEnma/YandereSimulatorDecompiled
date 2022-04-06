using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055B RID: 1371
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022E7 RID: 8935 RVA: 0x001F4E70 File Offset: 0x001F3070
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004B88 RID: 19336
		public readonly float min;
	}
}
