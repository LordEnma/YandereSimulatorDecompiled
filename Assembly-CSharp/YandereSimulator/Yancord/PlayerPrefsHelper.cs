using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000518 RID: 1304
	public static class PlayerPrefsHelper
	{
		// Token: 0x0600214D RID: 8525 RVA: 0x001E76AD File Offset: 0x001E58AD
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x0600214E RID: 8526 RVA: 0x001E76BC File Offset: 0x001E58BC
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
