using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000554 RID: 1364
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022CE RID: 8910 RVA: 0x001F30C1 File Offset: 0x001F12C1
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004B50 RID: 19280
		public readonly string name;

		// Token: 0x04004B51 RID: 19281
		public bool dirty;
	}
}
