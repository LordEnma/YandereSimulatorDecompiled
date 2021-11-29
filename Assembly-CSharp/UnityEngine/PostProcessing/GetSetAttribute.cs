using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000548 RID: 1352
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x06002276 RID: 8822 RVA: 0x001EB59D File Offset: 0x001E979D
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004A44 RID: 19012
		public readonly string name;

		// Token: 0x04004A45 RID: 19013
		public bool dirty;
	}
}
