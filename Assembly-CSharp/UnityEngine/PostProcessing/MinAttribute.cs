using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054D RID: 1357
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x06002296 RID: 8854 RVA: 0x001EDC70 File Offset: 0x001EBE70
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004AA2 RID: 19106
		public readonly float min;
	}
}
