using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x0200057C RID: 1404
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x0600239D RID: 9117 RVA: 0x001F216D File Offset: 0x001F036D
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x0600239E RID: 9118 RVA: 0x001F219A File Offset: 0x001F039A
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x0600239F RID: 9119 RVA: 0x001F21D6 File Offset: 0x001F03D6
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023A0 RID: 9120 RVA: 0x001F21F2 File Offset: 0x001F03F2
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023A1 RID: 9121 RVA: 0x001F220F File Offset: 0x001F040F
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023A2 RID: 9122 RVA: 0x001F222C File Offset: 0x001F042C
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023A3 RID: 9123 RVA: 0x001F2236 File Offset: 0x001F0436
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004AF3 RID: 19187
		public const byte Major = 1;

		// Token: 0x04004AF4 RID: 19188
		public const byte Minor = 8;

		// Token: 0x04004AF5 RID: 19189
		public const byte Release = 3;

		// Token: 0x04004AF6 RID: 19190
		private static string StageSuffix = "_dev001";

		// Token: 0x04004AF7 RID: 19191
		private static string TrialSuffix = "";

		// Token: 0x04004AF8 RID: 19192
		[SerializeField]
		private int m_major;

		// Token: 0x04004AF9 RID: 19193
		[SerializeField]
		private int m_minor;

		// Token: 0x04004AFA RID: 19194
		[SerializeField]
		private int m_release;
	}
}
