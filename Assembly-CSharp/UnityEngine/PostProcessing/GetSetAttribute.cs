using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x06002302 RID: 8962 RVA: 0x001F89FD File Offset: 0x001F6BFD
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004BDE RID: 19422
		public readonly string name;

		// Token: 0x04004BDF RID: 19423
		public bool dirty;
	}
}
