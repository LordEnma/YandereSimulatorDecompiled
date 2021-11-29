using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000514 RID: 1300
	public static class PlayerPrefsHelper
	{
		// Token: 0x0600212E RID: 8494 RVA: 0x001E4FE9 File Offset: 0x001E31E9
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x0600212F RID: 8495 RVA: 0x001E4FF8 File Offset: 0x001E31F8
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
