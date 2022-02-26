using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054F RID: 1359
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x060022B0 RID: 8880 RVA: 0x001F0781 File Offset: 0x001EE981
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004AD4 RID: 19156
		public readonly string name;

		// Token: 0x04004AD5 RID: 19157
		public bool dirty;
	}
}
