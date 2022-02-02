using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054D RID: 1357
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x0600229B RID: 8859 RVA: 0x001EF1D1 File Offset: 0x001ED3D1
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004AB2 RID: 19122
		public readonly string name;

		// Token: 0x04004AB3 RID: 19123
		public bool dirty;
	}
}
