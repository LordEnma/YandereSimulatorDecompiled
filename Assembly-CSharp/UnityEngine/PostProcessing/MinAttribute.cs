using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054E RID: 1358
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x06002298 RID: 8856 RVA: 0x001EE940 File Offset: 0x001ECB40
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004AA9 RID: 19113
		public readonly float min;
	}
}
