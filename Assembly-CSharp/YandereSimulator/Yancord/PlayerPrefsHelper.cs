using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000527 RID: 1319
	public static class PlayerPrefsHelper
	{
		// Token: 0x060021AF RID: 8623 RVA: 0x001F0891 File Offset: 0x001EEA91
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x001F08A0 File Offset: 0x001EEAA0
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
