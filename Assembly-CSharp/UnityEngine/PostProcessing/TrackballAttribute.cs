using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000556 RID: 1366
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022D0 RID: 8912 RVA: 0x001F30DF File Offset: 0x001F12DF
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004B53 RID: 19283
		public readonly string method;
	}
}
