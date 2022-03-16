using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000520 RID: 1312
	public static class PlayerPrefsHelper
	{
		// Token: 0x06002186 RID: 8582 RVA: 0x001ECB0D File Offset: 0x001EAD0D
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002187 RID: 8583 RVA: 0x001ECB1C File Offset: 0x001EAD1C
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
