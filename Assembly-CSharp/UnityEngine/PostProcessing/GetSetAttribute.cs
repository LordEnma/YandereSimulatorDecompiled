using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054A RID: 1354
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x06002287 RID: 8839 RVA: 0x001ECCD1 File Offset: 0x001EAED1
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004A83 RID: 19075
		public readonly string name;

		// Token: 0x04004A84 RID: 19076
		public bool dirty;
	}
}
