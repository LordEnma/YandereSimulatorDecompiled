using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000588 RID: 1416
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023F5 RID: 9205 RVA: 0x001F9C91 File Offset: 0x001F7E91
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x001F9CBE File Offset: 0x001F7EBE
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x060023F7 RID: 9207 RVA: 0x001F9CFA File Offset: 0x001F7EFA
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001F9D16 File Offset: 0x001F7F16
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F9D33 File Offset: 0x001F7F33
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001F9D50 File Offset: 0x001F7F50
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x001F9D5A File Offset: 0x001F7F5A
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004BFF RID: 19455
		public const byte Major = 1;

		// Token: 0x04004C00 RID: 19456
		public const byte Minor = 8;

		// Token: 0x04004C01 RID: 19457
		public const byte Release = 3;

		// Token: 0x04004C02 RID: 19458
		private static string StageSuffix = "_dev001";

		// Token: 0x04004C03 RID: 19459
		private static string TrialSuffix = "";

		// Token: 0x04004C04 RID: 19460
		[SerializeField]
		private int m_major;

		// Token: 0x04004C05 RID: 19461
		[SerializeField]
		private int m_minor;

		// Token: 0x04004C06 RID: 19462
		[SerializeField]
		private int m_release;
	}
}
