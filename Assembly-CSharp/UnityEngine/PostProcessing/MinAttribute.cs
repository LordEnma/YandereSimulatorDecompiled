using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055D RID: 1373
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x06002302 RID: 8962 RVA: 0x001F84A4 File Offset: 0x001F66A4
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004BD7 RID: 19415
		public readonly float min;
	}
}
