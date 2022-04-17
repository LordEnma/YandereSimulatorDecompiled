using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055B RID: 1371
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022EE RID: 8942 RVA: 0x001F58CC File Offset: 0x001F3ACC
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004B9A RID: 19354
		public readonly float min;
	}
}
