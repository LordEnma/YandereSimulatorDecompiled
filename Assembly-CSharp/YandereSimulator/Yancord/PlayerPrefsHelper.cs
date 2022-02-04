using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	public static class PlayerPrefsHelper
	{
		// Token: 0x06002155 RID: 8533 RVA: 0x001E8F35 File Offset: 0x001E7135
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002156 RID: 8534 RVA: 0x001E8F44 File Offset: 0x001E7144
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
