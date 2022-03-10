using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x0200051C RID: 1308
	public static class PlayerPrefsHelper
	{
		// Token: 0x0600216E RID: 8558 RVA: 0x001EABA5 File Offset: 0x001E8DA5
		public static void SetBool(string name, bool flag)
		{
			PlayerPrefs.SetInt(name, flag ? 1 : 0);
		}

		// Token: 0x0600216F RID: 8559 RVA: 0x001EABB4 File Offset: 0x001E8DB4
		public static bool GetBool(string name)
		{
			return PlayerPrefs.GetInt(name) == 1;
		}
	}
}
