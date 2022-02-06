using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054F RID: 1359
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022A2 RID: 8866 RVA: 0x001EF70B File Offset: 0x001ED90B
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004ABE RID: 19134
		public readonly string method;
	}
}
