using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055D RID: 1373
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022F8 RID: 8952 RVA: 0x001F6D67 File Offset: 0x001F4F67
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004BB1 RID: 19377
		public readonly string method;
	}
}
