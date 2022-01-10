using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054C RID: 1356
	public sealed class GetSetAttribute : PropertyAttribute
	{
		// Token: 0x06002295 RID: 8853 RVA: 0x001EDC61 File Offset: 0x001EBE61
		public GetSetAttribute(string name)
		{
			this.name = name;
		}

		// Token: 0x04004AA0 RID: 19104
		public readonly string name;

		// Token: 0x04004AA1 RID: 19105
		public bool dirty;
	}
}
