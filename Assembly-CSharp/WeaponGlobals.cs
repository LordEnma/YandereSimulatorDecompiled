using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class WeaponGlobals
{
	// Token: 0x060017BB RID: 6075 RVA: 0x000E3170 File Offset: 0x000E1370
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017BC RID: 6076 RVA: 0x000E31A8 File Offset: 0x000E13A8
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017BD RID: 6077 RVA: 0x000E3204 File Offset: 0x000E1404
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017BE RID: 6078 RVA: 0x000E3234 File Offset: 0x000E1434
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022D5 RID: 8917
	private const string Str_WeaponStatus = "WeaponStatus_";
}
