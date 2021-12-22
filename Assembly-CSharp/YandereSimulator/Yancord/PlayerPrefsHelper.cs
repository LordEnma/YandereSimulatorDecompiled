using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000516 RID: 1302
	public static class PlayerPrefsHelper
	{
		// Token: 0x0600213F RID: 8511 RVA: 0x001E671D File Offset: 0x001E491D
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002140 RID: 8512 RVA: 0x001E672C File Offset: 0x001E492C
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
