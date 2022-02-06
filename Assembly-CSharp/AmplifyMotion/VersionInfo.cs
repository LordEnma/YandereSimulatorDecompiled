using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000581 RID: 1409
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023C7 RID: 9159 RVA: 0x001F62BD File Offset: 0x001F44BD
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x001F62EA File Offset: 0x001F44EA
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023C9 RID: 9161 RVA: 0x001F6326 File Offset: 0x001F4526
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x001F6342 File Offset: 0x001F4542
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x001F635F File Offset: 0x001F455F
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x001F637C File Offset: 0x001F457C
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023CD RID: 9165 RVA: 0x001F6386 File Offset: 0x001F4586
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B6A RID: 19306
		public const byte Major = 1;

		// Token: 0x04004B6B RID: 19307
		public const byte Minor = 8;

		// Token: 0x04004B6C RID: 19308
		public const byte Release = 3;

		// Token: 0x04004B6D RID: 19309
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B6E RID: 19310
		private static string TrialSuffix = "";

		// Token: 0x04004B6F RID: 19311
		[SerializeField]
		private int m_major;

		// Token: 0x04004B70 RID: 19312
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B71 RID: 19313
		[SerializeField]
		private int m_release;
	}
}
