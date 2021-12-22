using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054C RID: 1356
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x06002289 RID: 8841 RVA: 0x001ECCEF File Offset: 0x001EAEEF
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004A86 RID: 19078
		public readonly string method;
	}
}
