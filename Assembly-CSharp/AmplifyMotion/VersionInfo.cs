using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x0200057E RID: 1406
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023AE RID: 9134 RVA: 0x001F38A1 File Offset: 0x001F1AA1
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023AF RID: 9135 RVA: 0x001F38CE File Offset: 0x001F1ACE
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x060023B0 RID: 9136 RVA: 0x001F390A File Offset: 0x001F1B0A
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023B1 RID: 9137 RVA: 0x001F3926 File Offset: 0x001F1B26
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x001F3943 File Offset: 0x001F1B43
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023B3 RID: 9139 RVA: 0x001F3960 File Offset: 0x001F1B60
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x001F396A File Offset: 0x001F1B6A
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B32 RID: 19250
		public const byte Major = 1;

		// Token: 0x04004B33 RID: 19251
		public const byte Minor = 8;

		// Token: 0x04004B34 RID: 19252
		public const byte Release = 3;

		// Token: 0x04004B35 RID: 19253
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B36 RID: 19254
		private static string TrialSuffix = "";

		// Token: 0x04004B37 RID: 19255
		[SerializeField]
		private int m_major;

		// Token: 0x04004B38 RID: 19256
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B39 RID: 19257
		[SerializeField]
		private int m_release;
	}
}
