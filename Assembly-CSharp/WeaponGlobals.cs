using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class WeaponGlobals
{
	// Token: 0x060017A4 RID: 6052 RVA: 0x000E1A14 File Offset: 0x000DFC14
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017A5 RID: 6053 RVA: 0x000E1A4C File Offset: 0x000DFC4C
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017A6 RID: 6054 RVA: 0x000E1AA8 File Offset: 0x000DFCA8
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017A7 RID: 6055 RVA: 0x000E1AD8 File Offset: 0x000DFCD8
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x0400229C RID: 8860
	private const string Str_WeaponStatus = "WeaponStatus_";
}
