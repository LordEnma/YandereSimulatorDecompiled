using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000581 RID: 1409
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023C2 RID: 9154 RVA: 0x001F5DA1 File Offset: 0x001F3FA1
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x001F5DCE File Offset: 0x001F3FCE
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023C4 RID: 9156 RVA: 0x001F5E0A File Offset: 0x001F400A
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023C5 RID: 9157 RVA: 0x001F5E26 File Offset: 0x001F4026
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023C6 RID: 9158 RVA: 0x001F5E43 File Offset: 0x001F4043
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023C7 RID: 9159 RVA: 0x001F5E60 File Offset: 0x001F4060
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x001F5E6A File Offset: 0x001F406A
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B61 RID: 19297
		public const byte Major = 1;

		// Token: 0x04004B62 RID: 19298
		public const byte Minor = 8;

		// Token: 0x04004B63 RID: 19299
		public const byte Release = 3;

		// Token: 0x04004B64 RID: 19300
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B65 RID: 19301
		private static string TrialSuffix = "";

		// Token: 0x04004B66 RID: 19302
		[SerializeField]
		private int m_major;

		// Token: 0x04004B67 RID: 19303
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B68 RID: 19304
		[SerializeField]
		private int m_release;
	}
}
