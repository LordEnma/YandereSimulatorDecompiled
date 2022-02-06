using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	public static class PlayerPrefsHelper
	{
		// Token: 0x06002158 RID: 8536 RVA: 0x001E9139 File Offset: 0x001E7339
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x001E9148 File Offset: 0x001E7348
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
