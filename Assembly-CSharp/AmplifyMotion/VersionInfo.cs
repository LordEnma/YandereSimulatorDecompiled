using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x0200058F RID: 1423
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x0600241D RID: 9245 RVA: 0x001FD919 File Offset: 0x001FBB19
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x0600241E RID: 9246 RVA: 0x001FD946 File Offset: 0x001FBB46
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x0600241F RID: 9247 RVA: 0x001FD982 File Offset: 0x001FBB82
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x06002420 RID: 9248 RVA: 0x001FD99E File Offset: 0x001FBB9E
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x001FD9BB File Offset: 0x001FBBBB
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x001FD9D8 File Offset: 0x001FBBD8
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x001FD9E2 File Offset: 0x001FBBE2
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004C5D RID: 19549
		public const byte Major = 1;

		// Token: 0x04004C5E RID: 19550
		public const byte Minor = 8;

		// Token: 0x04004C5F RID: 19551
		public const byte Release = 3;

		// Token: 0x04004C60 RID: 19552
		private static string StageSuffix = "_dev001";

		// Token: 0x04004C61 RID: 19553
		private static string TrialSuffix = "";

		// Token: 0x04004C62 RID: 19554
		[SerializeField]
		private int m_major;

		// Token: 0x04004C63 RID: 19555
		[SerializeField]
		private int m_minor;

		// Token: 0x04004C64 RID: 19556
		[SerializeField]
		private int m_release;
	}
}
