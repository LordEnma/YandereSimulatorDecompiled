using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054E RID: 1358
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022A7 RID: 8871 RVA: 0x001EFBA1 File Offset: 0x001EDDA1
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004AC4 RID: 19140
		public readonly string name;

		// Token: 0x04004AC5 RID: 19141
		public bool dirty;
	}
}
