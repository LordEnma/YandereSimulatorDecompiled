using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054E RID: 1358
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022A1 RID: 8865 RVA: 0x001EF6FC File Offset: 0x001ED8FC
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004ABD RID: 19133
		public readonly float min;
	}
}
