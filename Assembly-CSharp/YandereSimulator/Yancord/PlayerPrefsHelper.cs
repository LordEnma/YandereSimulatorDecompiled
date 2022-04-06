using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000526 RID: 1318
	public static class PlayerPrefsHelper
	{
		// Token: 0x0600219E RID: 8606 RVA: 0x001EE8AD File Offset: 0x001ECAAD
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x0600219F RID: 8607 RVA: 0x001EE8BC File Offset: 0x001ECABC
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
