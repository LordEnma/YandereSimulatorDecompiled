using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054E RID: 1358
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x0600229E RID: 8862 RVA: 0x001EF4F8 File Offset: 0x001ED6F8
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004ABA RID: 19130
		public readonly float min;
	}
}
