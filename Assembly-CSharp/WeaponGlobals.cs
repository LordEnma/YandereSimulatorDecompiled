using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class WeaponGlobals
{
	// Token: 0x060017A9 RID: 6057 RVA: 0x000E2244 File Offset: 0x000E0444
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x000E227C File Offset: 0x000E047C
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017AB RID: 6059 RVA: 0x000E22D8 File Offset: 0x000E04D8
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017AC RID: 6060 RVA: 0x000E2308 File Offset: 0x000E0508
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022A8 RID: 8872
	private const string Str_WeaponStatus = "WeaponStatus_";
}
