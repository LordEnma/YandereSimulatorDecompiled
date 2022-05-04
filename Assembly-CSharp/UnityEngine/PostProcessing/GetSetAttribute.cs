using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055B RID: 1371
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022F7 RID: 8951 RVA: 0x001F6E45 File Offset: 0x001F5045
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004BAE RID: 19374
		public readonly string name;

		// Token: 0x04004BAF RID: 19375
		public bool dirty;
	}
}
