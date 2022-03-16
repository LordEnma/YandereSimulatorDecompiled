using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000555 RID: 1365
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x060022CF RID: 8911 RVA: 0x001F30D0 File Offset: 0x001F12D0
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004B52 RID: 19282
		public readonly float min;
	}
}
