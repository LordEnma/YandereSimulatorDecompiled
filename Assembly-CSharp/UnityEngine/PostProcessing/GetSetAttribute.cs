using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054D RID: 1357
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022A0 RID: 8864 RVA: 0x001EF6ED File Offset: 0x001ED8ED
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004ABB RID: 19131
		public readonly string name;

		// Token: 0x04004ABC RID: 19132
		public bool dirty;
	}
}
