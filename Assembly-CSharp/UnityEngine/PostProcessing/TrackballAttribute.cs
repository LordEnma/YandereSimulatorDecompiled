using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054E RID: 1358
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x06002297 RID: 8855 RVA: 0x001EDC7F File Offset: 0x001EBE7F
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004AA3 RID: 19107
		public readonly string method;
	}
}
