using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055A RID: 1370
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022E6 RID: 8934 RVA: 0x001F4E61 File Offset: 0x001F3061
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004B86 RID: 19334
		public readonly string name;

		// Token: 0x04004B87 RID: 19335
		public bool dirty;
	}
}
