using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public static class WeaponGlobals
{
	// Token: 0x060017CC RID: 6092 RVA: 0x000E3C2C File Offset: 0x000E1E2C
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017CD RID: 6093 RVA: 0x000E3C64 File Offset: 0x000E1E64
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017CE RID: 6094 RVA: 0x000E3CC0 File Offset: 0x000E1EC0
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017CF RID: 6095 RVA: 0x000E3CF0 File Offset: 0x000E1EF0
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022F6 RID: 8950
	private const string Str_WeaponStatus = "WeaponStatus_";
}
