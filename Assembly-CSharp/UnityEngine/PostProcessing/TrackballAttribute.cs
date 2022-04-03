using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055B RID: 1371
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022E0 RID: 8928 RVA: 0x001F494F File Offset: 0x001F2B4F
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004B85 RID: 19333
		public readonly string method;
	}
}
