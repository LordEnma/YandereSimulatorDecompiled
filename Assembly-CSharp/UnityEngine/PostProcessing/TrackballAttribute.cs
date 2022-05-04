using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055D RID: 1373
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022F9 RID: 8953 RVA: 0x001F6E63 File Offset: 0x001F5063
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004BB1 RID: 19377
		public readonly string method;
	}
}
