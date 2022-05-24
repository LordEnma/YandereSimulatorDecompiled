using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000590 RID: 1424
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x06002429 RID: 9257 RVA: 0x001FF5CD File Offset: 0x001FD7CD
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x0600242A RID: 9258 RVA: 0x001FF5FA File Offset: 0x001FD7FA
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x0600242B RID: 9259 RVA: 0x001FF636 File Offset: 0x001FD836
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x001FF652 File Offset: 0x001FD852
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x001FF66F File Offset: 0x001FD86F
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x001FF68C File Offset: 0x001FD88C
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x0600242F RID: 9263 RVA: 0x001FF696 File Offset: 0x001FD896
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004C8D RID: 19597
		public const byte Major = 1;

		// Token: 0x04004C8E RID: 19598
		public const byte Minor = 8;

		// Token: 0x04004C8F RID: 19599
		public const byte Release = 3;

		// Token: 0x04004C90 RID: 19600
		private static string StageSuffix = "_dev001";

		// Token: 0x04004C91 RID: 19601
		private static string TrialSuffix = "";

		// Token: 0x04004C92 RID: 19602
		[SerializeField]
		private int m_major;

		// Token: 0x04004C93 RID: 19603
		[SerializeField]
		private int m_minor;

		// Token: 0x04004C94 RID: 19604
		[SerializeField]
		private int m_release;
	}
}
