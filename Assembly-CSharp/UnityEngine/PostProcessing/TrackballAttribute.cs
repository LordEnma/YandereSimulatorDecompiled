using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000550 RID: 1360
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022A9 RID: 8873 RVA: 0x001EFBBF File Offset: 0x001EDDBF
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004AC7 RID: 19143
		public readonly string method;
	}
}
