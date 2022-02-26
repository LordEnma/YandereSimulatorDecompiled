using System;
using UnityEngine;

namespace AmplifyMotion
{
	// Token: 0x02000583 RID: 1411
	[Serializable]
	public class VersionInfo
	{
		// Token: 0x060023D7 RID: 9175 RVA: 0x001F7351 File Offset: 0x001F5551
		public static string StaticToString()
		{
			return string.Format("{0}.{1}.{2}", 1, 8, 3) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x060023D8 RID: 9176 RVA: 0x001F737E File Offset: 0x001F557E
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}", this.m_major, this.m_minor, this.m_release) + VersionInfo.StageSuffix + VersionInfo.TrialSuffix;
		}

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023D9 RID: 9177 RVA: 0x001F73BA File Offset: 0x001F55BA
		public int Number
		{
			get
			{
				return this.m_major * 100 + this.m_minor * 10 + this.m_release;
			}
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x001F73D6 File Offset: 0x001F55D6
		private VersionInfo()
		{
			this.m_major = 1;
			this.m_minor = 8;
			this.m_release = 3;
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x001F73F3 File Offset: 0x001F55F3
		private VersionInfo(byte major, byte minor, byte release)
		{
			this.m_major = (int)major;
			this.m_minor = (int)minor;
			this.m_release = (int)release;
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x001F7410 File Offset: 0x001F5610
		public static VersionInfo Current()
		{
			return new VersionInfo(1, 8, 3);
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x001F741A File Offset: 0x001F561A
		public static bool Matches(VersionInfo version)
		{
			return 1 == version.m_major && 8 == version.m_minor && 3 == version.m_release;
		}

		// Token: 0x04004B83 RID: 19331
		public const byte Major = 1;

		// Token: 0x04004B84 RID: 19332
		public const byte Minor = 8;

		// Token: 0x04004B85 RID: 19333
		public const byte Release = 3;

		// Token: 0x04004B86 RID: 19334
		private static string StageSuffix = "_dev001";

		// Token: 0x04004B87 RID: 19335
		private static string TrialSuffix = "";

		// Token: 0x04004B88 RID: 19336
		[SerializeField]
		private int m_major;

		// Token: 0x04004B89 RID: 19337
		[SerializeField]
		private int m_minor;

		// Token: 0x04004B8A RID: 19338
		[SerializeField]
		private int m_release;
	}
}
