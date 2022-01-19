using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054F RID: 1359
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x06002299 RID: 8857 RVA: 0x001EE94F File Offset: 0x001ECB4F
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004AAA RID: 19114
		public readonly string method;
	}
}
