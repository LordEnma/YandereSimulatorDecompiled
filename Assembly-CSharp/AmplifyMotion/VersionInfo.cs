using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000580 RID: 1408
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023BC RID: 9148 RVA: 0x001F4831 File Offset: 0x001F2A31
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023BD RID: 9149 RVA: 0x001F485E File Offset: 0x001F2A5E
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023BE RID: 9150 RVA: 0x001F489A File Offset: 0x001F2A9A
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023BF RID: 9151 RVA: 0x001F48B6 File Offset: 0x001F2AB6
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023C0 RID: 9152 RVA: 0x001F48D3 File Offset: 0x001F2AD3
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x001F48F0 File Offset: 0x001F2AF0
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023C2 RID: 9154 RVA: 0x001F48FA File Offset: 0x001F2AFA
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B4F RID: 19279
		public const byte Major = 1;

		// Token: 0x04004B50 RID: 19280
		public const byte Minor = 8;

		// Token: 0x04004B51 RID: 19281
		public const byte Release = 3;

		// Token: 0x04004B52 RID: 19282
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B53 RID: 19283
		private static string TrialSuffix = "";

		// Token: 0x04004B54 RID: 19284
		[SerializeField]
		private int m_major;

		// Token: 0x04004B55 RID: 19285
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B56 RID: 19286
		[SerializeField]
		private int m_release;
	}
}
