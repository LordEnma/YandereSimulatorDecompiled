using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x0200057E RID: 1406
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023B1 RID: 9137 RVA: 0x001F3E91 File Offset: 0x001F2091
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023B2 RID: 9138 RVA: 0x001F3EBE File Offset: 0x001F20BE
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023B3 RID: 9139 RVA: 0x001F3EFA File Offset: 0x001F20FA
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023B4 RID: 9140 RVA: 0x001F3F16 File Offset: 0x001F2116
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023B5 RID: 9141 RVA: 0x001F3F33 File Offset: 0x001F2133
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023B6 RID: 9142 RVA: 0x001F3F50 File Offset: 0x001F2150
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023B7 RID: 9143 RVA: 0x001F3F5A File Offset: 0x001F215A
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B3B RID: 19259
		public const byte Major = 1;

		// Token: 0x04004B3C RID: 19260
		public const byte Minor = 8;

		// Token: 0x04004B3D RID: 19261
		public const byte Release = 3;

		// Token: 0x04004B3E RID: 19262
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B3F RID: 19263
		private static string TrialSuffix = "";

		// Token: 0x04004B40 RID: 19264
		[SerializeField]
		private int m_major;

		// Token: 0x04004B41 RID: 19265
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B42 RID: 19266
		[SerializeField]
		private int m_release;
	}
}
