using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000516 RID: 1302
	public static class PlayerPrefsHelper
	{
		// Token: 0x06002142 RID: 8514 RVA: 0x001E6D0D File Offset: 0x001E4F0D
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002143 RID: 8515 RVA: 0x001E6D1C File Offset: 0x001E4F1C
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
