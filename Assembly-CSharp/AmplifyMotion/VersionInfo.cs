using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000582 RID: 1410
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023CE RID: 9166 RVA: 0x001F6771 File Offset: 0x001F4971
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023CF RID: 9167 RVA: 0x001F679E File Offset: 0x001F499E
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023D0 RID: 9168 RVA: 0x001F67DA File Offset: 0x001F49DA
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023D1 RID: 9169 RVA: 0x001F67F6 File Offset: 0x001F49F6
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023D2 RID: 9170 RVA: 0x001F6813 File Offset: 0x001F4A13
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x001F6830 File Offset: 0x001F4A30
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023D4 RID: 9172 RVA: 0x001F683A File Offset: 0x001F4A3A
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B73 RID: 19315
		public const byte Major = 1;

		// Token: 0x04004B74 RID: 19316
		public const byte Minor = 8;

		// Token: 0x04004B75 RID: 19317
		public const byte Release = 3;

		// Token: 0x04004B76 RID: 19318
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B77 RID: 19319
		private static string TrialSuffix = "";

		// Token: 0x04004B78 RID: 19320
		[SerializeField]
		private int m_major;

		// Token: 0x04004B79 RID: 19321
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B7A RID: 19322
		[SerializeField]
		private int m_release;
	}
}
