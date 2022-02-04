using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054F RID: 1359
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x0600229F RID: 8863 RVA: 0x001EF507 File Offset: 0x001ED707
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004ABB RID: 19131
		public readonly string method;
	}
}
