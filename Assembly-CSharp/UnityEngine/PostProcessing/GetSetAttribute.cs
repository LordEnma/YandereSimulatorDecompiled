using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055A RID: 1370
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022ED RID: 8941 RVA: 0x001F58BD File Offset: 0x001F3ABD
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004B98 RID: 19352
		public readonly string name;

		// Token: 0x04004B99 RID: 19353
		public bool dirty;
	}
}
