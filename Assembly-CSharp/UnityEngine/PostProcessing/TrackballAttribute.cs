using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class TrackballAttribute : PropertyAttribute
	{
		// Token: 0x060022EF RID: 8943 RVA: 0x001F58DB File Offset: 0x001F3ADB
		public TrackballAttribute(string method)
		{
			this.method = method;
		}

		// Token: 0x04004B9B RID: 19355
		public readonly string method;
	}
}
