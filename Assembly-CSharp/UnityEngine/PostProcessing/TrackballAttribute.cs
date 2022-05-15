using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055E RID: 1374
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x06002303 RID: 8963 RVA: 0x001F84B3 File Offset: 0x001F66B3
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004BD8 RID: 19416
		public readonly string method;
	}
}
