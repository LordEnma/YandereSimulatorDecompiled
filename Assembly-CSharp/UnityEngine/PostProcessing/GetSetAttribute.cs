using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054D RID: 1357
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x0600229D RID: 8861 RVA: 0x001EF4E9 File Offset: 0x001ED6E9
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004AB8 RID: 19128
		public readonly string name;

		// Token: 0x04004AB9 RID: 19129
		public bool dirty;
	}
}
