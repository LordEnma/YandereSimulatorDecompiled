using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000526 RID: 1318
	public static class PlayerPrefsHelper
	{
		// Token: 0x060021A5 RID: 8613 RVA: 0x001EF309 File Offset: 0x001ED509
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x060021A6 RID: 8614 RVA: 0x001EF318 File Offset: 0x001ED518
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
