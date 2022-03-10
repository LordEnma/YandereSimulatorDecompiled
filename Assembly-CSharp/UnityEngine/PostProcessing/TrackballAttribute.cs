using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000552 RID: 1362
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022B8 RID: 8888 RVA: 0x001F1177 File Offset: 0x001EF377
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004AF4 RID: 19188
		public readonly string method;
	}
}
