using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000581 RID: 1409
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023BE RID: 9150 RVA: 0x001F5501 File Offset: 0x001F3701
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023BF RID: 9151 RVA: 0x001F552E File Offset: 0x001F372E
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023C0 RID: 9152 RVA: 0x001F556A File Offset: 0x001F376A
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x001F5586 File Offset: 0x001F3786
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x001F55A3 File Offset: 0x001F37A3
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x001F55C0 File Offset: 0x001F37C0
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x001F55CA File Offset: 0x001F37CA
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B56 RID: 19286
		public const byte Major = 1;

		// Token: 0x04004B57 RID: 19287
		public const byte Minor = 8;

		// Token: 0x04004B58 RID: 19288
		public const byte Release = 3;

		// Token: 0x04004B59 RID: 19289
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B5A RID: 19290
		private static string TrialSuffix = "";

		// Token: 0x04004B5B RID: 19291
		[SerializeField]
		private int m_major;

		// Token: 0x04004B5C RID: 19292
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B5D RID: 19293
		[SerializeField]
		private int m_release;
	}
}
