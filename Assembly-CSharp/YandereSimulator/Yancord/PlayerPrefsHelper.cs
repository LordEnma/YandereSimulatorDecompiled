using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	public static class PlayerPrefsHelper
	{
		// Token: 0x06002153 RID: 8531 RVA: 0x001E8C1D File Offset: 0x001E6E1D
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002154 RID: 8532 RVA: 0x001E8C2C File Offset: 0x001E6E2C
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
