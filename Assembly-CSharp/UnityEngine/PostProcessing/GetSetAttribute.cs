using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x06002301 RID: 8961 RVA: 0x001F8495 File Offset: 0x001F6695
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004BD5 RID: 19413
		public readonly string name;

		// Token: 0x04004BD6 RID: 19414
		public bool dirty;
	}
}
