using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public static class WeaponGlobals
{
	// Token: 0x060017C6 RID: 6086 RVA: 0x000E3B1C File Offset: 0x000E1D1C
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017C7 RID: 6087 RVA: 0x000E3B54 File Offset: 0x000E1D54
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017C8 RID: 6088 RVA: 0x000E3BB0 File Offset: 0x000E1DB0
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x000E3BE0 File Offset: 0x000E1DE0
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022F4 RID: 8948
	private const string Str_WeaponStatus = "WeaponStatus_";
}
