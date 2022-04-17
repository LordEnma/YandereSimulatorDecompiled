using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x0200058E RID: 1422
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x06002414 RID: 9236 RVA: 0x001FC48D File Offset: 0x001FA68D
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x001FC4BA File Offset: 0x001FA6BA
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002416 RID: 9238 RVA: 0x001FC4F6 File Offset: 0x001FA6F6
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x06002417 RID: 9239 RVA: 0x001FC512 File Offset: 0x001FA712
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x06002418 RID: 9240 RVA: 0x001FC52F File Offset: 0x001FA72F
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x06002419 RID: 9241 RVA: 0x001FC54C File Offset: 0x001FA74C
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x001FC556 File Offset: 0x001FA756
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004C47 RID: 19527
		public const byte Major = 1;

		// Token: 0x04004C48 RID: 19528
		public const byte Minor = 8;

		// Token: 0x04004C49 RID: 19529
		public const byte Release = 3;

		// Token: 0x04004C4A RID: 19530
		private static string StageSuffix = "_dev001";

		// Token: 0x04004C4B RID: 19531
		private static string TrialSuffix = "";

		// Token: 0x04004C4C RID: 19532
		[SerializeField]
		private int m_major;

		// Token: 0x04004C4D RID: 19533
		[SerializeField]
		private int m_minor;

		// Token: 0x04004C4E RID: 19534
		[SerializeField]
		private int m_release;
	}
}
