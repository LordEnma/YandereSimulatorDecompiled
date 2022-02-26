using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000551 RID: 1361
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022B2 RID: 8882 RVA: 0x001F079F File Offset: 0x001EE99F
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004AD7 RID: 19159
		public readonly string method;
	}
}
