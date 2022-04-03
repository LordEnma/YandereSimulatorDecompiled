using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x0200058D RID: 1421
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x06002405 RID: 9221 RVA: 0x001FB501 File Offset: 0x001F9701
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x001FB52E File Offset: 0x001F972E
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002407 RID: 9223 RVA: 0x001FB56A File Offset: 0x001F976A
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x001FB586 File Offset: 0x001F9786
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x001FB5A3 File Offset: 0x001F97A3
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001FB5C0 File Offset: 0x001F97C0
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001FB5CA File Offset: 0x001F97CA
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004C31 RID: 19505
		public const byte Major = 1;

		// Token: 0x04004C32 RID: 19506
		public const byte Minor = 8;

		// Token: 0x04004C33 RID: 19507
		public const byte Release = 3;

		// Token: 0x04004C34 RID: 19508
		private static string StageSuffix = "_dev001";

		// Token: 0x04004C35 RID: 19509
		private static string TrialSuffix = "";

		// Token: 0x04004C36 RID: 19510
		[SerializeField]
		private int m_major;

		// Token: 0x04004C37 RID: 19511
		[SerializeField]
		private int m_minor;

		// Token: 0x04004C38 RID: 19512
		[SerializeField]
		private int m_release;
	}
}
