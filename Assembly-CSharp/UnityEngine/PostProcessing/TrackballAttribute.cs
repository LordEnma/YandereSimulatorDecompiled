using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054F RID: 1359
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x0600229D RID: 8861 RVA: 0x001EF1EF File Offset: 0x001ED3EF
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004AB5 RID: 19125
		public readonly string method;
	}
}
