using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054E RID: 1358
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x0600229C RID: 8860 RVA: 0x001EF1E0 File Offset: 0x001ED3E0
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004AB4 RID: 19124
		public readonly float min;
	}
}
