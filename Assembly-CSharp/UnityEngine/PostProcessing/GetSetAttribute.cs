using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000550 RID: 1360
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022B6 RID: 8886 RVA: 0x001F1159 File Offset: 0x001EF359
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004AF1 RID: 19185
		public readonly string name;

		// Token: 0x04004AF2 RID: 19186
		public bool dirty;
	}
}
