using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public static class WeaponGlobals
{
	// Token: 0x060017D4 RID: 6100 RVA: 0x000E4330 File Offset: 0x000E2530
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017D5 RID: 6101 RVA: 0x000E4368 File Offset: 0x000E2568
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017D6 RID: 6102 RVA: 0x000E43C4 File Offset: 0x000E25C4
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017D7 RID: 6103 RVA: 0x000E43F4 File Offset: 0x000E25F4
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x04002302 RID: 8962
	private const string Str_WeaponStatus = "WeaponStatus_";
}
