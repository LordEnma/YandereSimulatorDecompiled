using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054A RID: 1354
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x06002278 RID: 8824 RVA: 0x001EB5BB File Offset: 0x001E97BB
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004A47 RID: 19015
		public readonly string method;
	}
}
