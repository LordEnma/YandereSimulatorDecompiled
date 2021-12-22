using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200054B RID: 1355
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x06002288 RID: 8840 RVA: 0x001ECCE0 File Offset: 0x001EAEE0
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004A85 RID: 19077
		public readonly float min;
	}
}
