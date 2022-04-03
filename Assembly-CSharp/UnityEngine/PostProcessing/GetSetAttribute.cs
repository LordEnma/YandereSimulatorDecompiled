using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000559 RID: 1369
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022DE RID: 8926 RVA: 0x001F4931 File Offset: 0x001F2B31
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004B82 RID: 19330
		public readonly string name;

		// Token: 0x04004B83 RID: 19331
		public bool dirty;
	}
}
