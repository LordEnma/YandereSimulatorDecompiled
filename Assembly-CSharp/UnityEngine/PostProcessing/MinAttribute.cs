using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000551 RID: 1361
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022B7 RID: 8887 RVA: 0x001F1168 File Offset: 0x001EF368
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004AF3 RID: 19187
		public readonly float min;
	}
}
