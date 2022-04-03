using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000525 RID: 1317
	public static class PlayerPrefsHelper
	{
		// Token: 0x06002196 RID: 8598 RVA: 0x001EE37D File Offset: 0x001EC57D
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x001EE38C File Offset: 0x001EC58C
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
