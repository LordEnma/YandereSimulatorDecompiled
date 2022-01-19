using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000519 RID: 1305
	public static class PlayerPrefsHelper
	{
		// Token: 0x0600214F RID: 8527 RVA: 0x001E837D File Offset: 0x001E657D
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x06002150 RID: 8528 RVA: 0x001E838C File Offset: 0x001E658C
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
