using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x0200058E RID: 1422
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x0600240D RID: 9229 RVA: 0x001FBA31 File Offset: 0x001F9C31
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x001FBA5E File Offset: 0x001F9C5E
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x0600240F RID: 9231 RVA: 0x001FBA9A File Offset: 0x001F9C9A
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x06002410 RID: 9232 RVA: 0x001FBAB6 File Offset: 0x001F9CB6
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x001FBAD3 File Offset: 0x001F9CD3
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x06002412 RID: 9234 RVA: 0x001FBAF0 File Offset: 0x001F9CF0
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x06002413 RID: 9235 RVA: 0x001FBAFA File Offset: 0x001F9CFA
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004C35 RID: 19509
		public const byte Major = 1;

		// Token: 0x04004C36 RID: 19510
		public const byte Minor = 8;

		// Token: 0x04004C37 RID: 19511
		public const byte Release = 3;

		// Token: 0x04004C38 RID: 19512
		private static string StageSuffix = "_dev001";

		// Token: 0x04004C39 RID: 19513
		private static string TrialSuffix = "";

		// Token: 0x04004C3A RID: 19514
		[SerializeField]
		private int m_major;

		// Token: 0x04004C3B RID: 19515
		[SerializeField]
		private int m_minor;

		// Token: 0x04004C3C RID: 19516
		[SerializeField]
		private int m_release;
	}
}
