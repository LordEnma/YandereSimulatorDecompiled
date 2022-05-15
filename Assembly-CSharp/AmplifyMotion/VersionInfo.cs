using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000590 RID: 1424
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x06002428 RID: 9256 RVA: 0x001FF065 File Offset: 0x001FD265
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x001FF092 File Offset: 0x001FD292
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x0600242A RID: 9258 RVA: 0x001FF0CE File Offset: 0x001FD2CE
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x0600242B RID: 9259 RVA: 0x001FF0EA File Offset: 0x001FD2EA
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x001FF107 File Offset: 0x001FD307
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x001FF124 File Offset: 0x001FD324
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x001FF12E File Offset: 0x001FD32E
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004C84 RID: 19588
		public const byte Major = 1;

		// Token: 0x04004C85 RID: 19589
		public const byte Minor = 8;

		// Token: 0x04004C86 RID: 19590
		public const byte Release = 3;

		// Token: 0x04004C87 RID: 19591
		private static string StageSuffix = "_dev001";

		// Token: 0x04004C88 RID: 19592
		private static string TrialSuffix = "";

		// Token: 0x04004C89 RID: 19593
		[SerializeField]
		private int m_major;

		// Token: 0x04004C8A RID: 19594
		[SerializeField]
		private int m_minor;

		// Token: 0x04004C8B RID: 19595
		[SerializeField]
		private int m_release;
	}
}
