using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000584 RID: 1412
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023DD RID: 9181 RVA: 0x001F7D29 File Offset: 0x001F5F29
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x001F7D56 File Offset: 0x001F5F56
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023DF RID: 9183 RVA: 0x001F7D92 File Offset: 0x001F5F92
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x001F7DAE File Offset: 0x001F5FAE
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x001F7DCB File Offset: 0x001F5FCB
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023E2 RID: 9186 RVA: 0x001F7DE8 File Offset: 0x001F5FE8
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023E3 RID: 9187 RVA: 0x001F7DF2 File Offset: 0x001F5FF2
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004BA0 RID: 19360
		public const byte Major = 1;

		// Token: 0x04004BA1 RID: 19361
		public const byte Minor = 8;

		// Token: 0x04004BA2 RID: 19362
		public const byte Release = 3;

		// Token: 0x04004BA3 RID: 19363
		private static string StageSuffix = "_dev001";

		// Token: 0x04004BA4 RID: 19364
		private static string TrialSuffix = "";

		// Token: 0x04004BA5 RID: 19365
		[SerializeField]
		private int m_major;

		// Token: 0x04004BA6 RID: 19366
		[SerializeField]
		private int m_minor;

		// Token: 0x04004BA7 RID: 19367
		[SerializeField]
		private int m_release;
	}
}
