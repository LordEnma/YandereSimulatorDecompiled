using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054A RID: 1354
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x0600228A RID: 8842 RVA: 0x001ED2C1 File Offset: 0x001EB4C1
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004A8C RID: 19084
		public readonly string name;

		// Token: 0x04004A8D RID: 19085
		public bool dirty;
	}
}
