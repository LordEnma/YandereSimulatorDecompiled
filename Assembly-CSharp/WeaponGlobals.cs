using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class WeaponGlobals
{
	// Token: 0x060017A9 RID: 6057 RVA: 0x000E22FC File Offset: 0x000E04FC
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x000E2334 File Offset: 0x000E0534
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017AB RID: 6059 RVA: 0x000E2390 File Offset: 0x000E0590
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017AC RID: 6060 RVA: 0x000E23C0 File Offset: 0x000E05C0
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022A9 RID: 8873
	private const string Str_WeaponStatus = "WeaponStatus_";
}
