using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055E RID: 1374
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x06002304 RID: 8964 RVA: 0x001F8A1B File Offset: 0x001F6C1B
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004BE1 RID: 19425
		public readonly string method;
	}
}
