using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054D RID: 1357
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x06002297 RID: 8855 RVA: 0x001EE931 File Offset: 0x001ECB31
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004AA7 RID: 19111
		public readonly string name;

		// Token: 0x04004AA8 RID: 19112
		public bool dirty;
	}
}
