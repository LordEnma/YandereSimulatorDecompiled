using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000528 RID: 1320
	public static class PlayerPrefsHelper
	{
		// Token: 0x060021B9 RID: 8633 RVA: 0x001F1EE1 File Offset: 0x001F00E1
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x060021BA RID: 8634 RVA: 0x001F1EF0 File Offset: 0x001F00F0
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
