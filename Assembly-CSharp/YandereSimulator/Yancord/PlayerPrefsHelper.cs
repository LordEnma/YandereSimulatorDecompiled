using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051A RID: 1306
	public static class PlayerPrefsHelper
	{
		// Token: 0x0600215F RID: 8543 RVA: 0x001E95ED File Offset: 0x001E77ED
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002160 RID: 8544 RVA: 0x001E95FC File Offset: 0x001E77FC
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
