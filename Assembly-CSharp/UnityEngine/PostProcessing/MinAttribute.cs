using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054B RID: 1355
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x0600228B RID: 8843 RVA: 0x001ED2D0 File Offset: 0x001EB4D0
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004A8E RID: 19086
		public readonly float min;
	}
}
