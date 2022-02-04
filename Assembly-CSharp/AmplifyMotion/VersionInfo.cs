using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000581 RID: 1409
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023C4 RID: 9156 RVA: 0x001F60B9 File Offset: 0x001F42B9
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023C5 RID: 9157 RVA: 0x001F60E6 File Offset: 0x001F42E6
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023C6 RID: 9158 RVA: 0x001F6122 File Offset: 0x001F4322
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023C7 RID: 9159 RVA: 0x001F613E File Offset: 0x001F433E
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x001F615B File Offset: 0x001F435B
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x001F6178 File Offset: 0x001F4378
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x001F6182 File Offset: 0x001F4382
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B67 RID: 19303
		public const byte Major = 1;

		// Token: 0x04004B68 RID: 19304
		public const byte Minor = 8;

		// Token: 0x04004B69 RID: 19305
		public const byte Release = 3;

		// Token: 0x04004B6A RID: 19306
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B6B RID: 19307
		private static string TrialSuffix = "";

		// Token: 0x04004B6C RID: 19308
		[SerializeField]
		private int m_major;

		// Token: 0x04004B6D RID: 19309
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B6E RID: 19310
		[SerializeField]
		private int m_release;
	}
}
