using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054C RID: 1356
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x0600228C RID: 8844 RVA: 0x001ED2DF File Offset: 0x001EB4DF
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004A8F RID: 19087
		public readonly string method;
	}
}
