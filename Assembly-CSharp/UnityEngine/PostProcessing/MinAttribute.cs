using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000549 RID: 1353
	public sealed class MinAttribute : PropertyAttribute
	{
		// Token: 0x06002277 RID: 8823 RVA: 0x001EB5AC File Offset: 0x001E97AC
		public MinAttribute(float min)
		{
			this.min = min;
		}

		// Token: 0x04004A46 RID: 19014
		public readonly float min;
	}
}
