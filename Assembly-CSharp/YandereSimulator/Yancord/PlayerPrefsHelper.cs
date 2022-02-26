using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051B RID: 1307
	public static class PlayerPrefsHelper
	{
		// Token: 0x06002168 RID: 8552 RVA: 0x001EA1CD File Offset: 0x001E83CD
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002169 RID: 8553 RVA: 0x001EA1DC File Offset: 0x001E83DC
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
