using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class WeaponGlobals
{
	// Token: 0x060017A2 RID: 6050 RVA: 0x000E1744 File Offset: 0x000DF944
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017A3 RID: 6051 RVA: 0x000E177C File Offset: 0x000DF97C
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017A4 RID: 6052 RVA: 0x000E17D8 File Offset: 0x000DF9D8
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017A5 RID: 6053 RVA: 0x000E1808 File Offset: 0x000DFA08
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x04002298 RID: 8856
	private const string Str_WeaponStatus = "WeaponStatus_";
}
