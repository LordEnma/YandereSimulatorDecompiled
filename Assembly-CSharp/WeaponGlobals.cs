using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class WeaponGlobals
{
	// Token: 0x060017AB RID: 6059 RVA: 0x000E23E8 File Offset: 0x000E05E8
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017AC RID: 6060 RVA: 0x000E2420 File Offset: 0x000E0620
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017AD RID: 6061 RVA: 0x000E247C File Offset: 0x000E067C
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017AE RID: 6062 RVA: 0x000E24AC File Offset: 0x000E06AC
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022AC RID: 8876
	private const string Str_WeaponStatus = "WeaponStatus_";
}
