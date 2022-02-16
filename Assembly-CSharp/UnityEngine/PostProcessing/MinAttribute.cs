using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054F RID: 1359
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022A8 RID: 8872 RVA: 0x001EFBB0 File Offset: 0x001EDDB0
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004AC6 RID: 19142
		public readonly float min;
	}
}
