using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055D RID: 1373
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x06002303 RID: 8963 RVA: 0x001F8A0C File Offset: 0x001F6C0C
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004BE0 RID: 19424
		public readonly float min;
	}
}
