using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000527 RID: 1319
	public static class PlayerPrefsHelper
	{
		// Token: 0x060021AE RID: 8622 RVA: 0x001F0795 File Offset: 0x001EE995
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x060021AF RID: 8623 RVA: 0x001F07A4 File Offset: 0x001EE9A4
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
