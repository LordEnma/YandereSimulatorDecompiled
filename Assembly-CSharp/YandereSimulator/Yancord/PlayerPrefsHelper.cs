using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000528 RID: 1320
	public static class PlayerPrefsHelper
	{
		// Token: 0x060021BA RID: 8634 RVA: 0x001F2449 File Offset: 0x001F0649
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x060021BB RID: 8635 RVA: 0x001F2458 File Offset: 0x001F0658
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
