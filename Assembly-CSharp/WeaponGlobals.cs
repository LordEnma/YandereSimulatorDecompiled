using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public static class WeaponGlobals
{
	// Token: 0x060017D0 RID: 6096 RVA: 0x000E3E94 File Offset: 0x000E2094
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017D1 RID: 6097 RVA: 0x000E3ECC File Offset: 0x000E20CC
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017D2 RID: 6098 RVA: 0x000E3F28 File Offset: 0x000E2128
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017D3 RID: 6099 RVA: 0x000E3F58 File Offset: 0x000E2158
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022F9 RID: 8953
	private const string Str_WeaponStatus = "WeaponStatus_";
}
