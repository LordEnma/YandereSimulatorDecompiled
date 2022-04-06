using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022E8 RID: 8936 RVA: 0x001F4E7F File Offset: 0x001F307F
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004B89 RID: 19337
		public readonly string method;
	}
}
