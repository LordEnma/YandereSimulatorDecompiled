using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055A RID: 1370
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022DF RID: 8927 RVA: 0x001F4940 File Offset: 0x001F2B40
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004B84 RID: 19332
		public readonly float min;
	}
}
