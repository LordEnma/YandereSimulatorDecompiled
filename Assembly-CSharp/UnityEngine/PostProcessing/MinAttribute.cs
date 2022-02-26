using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000550 RID: 1360
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022B1 RID: 8881 RVA: 0x001F0790 File Offset: 0x001EE990
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004AD6 RID: 19158
		public readonly float min;
	}
}
