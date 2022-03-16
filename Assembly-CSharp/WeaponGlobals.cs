using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class WeaponGlobals
{
	// Token: 0x060017C0 RID: 6080 RVA: 0x000E361C File Offset: 0x000E181C
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017C1 RID: 6081 RVA: 0x000E3654 File Offset: 0x000E1854
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017C2 RID: 6082 RVA: 0x000E36B0 File Offset: 0x000E18B0
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017C3 RID: 6083 RVA: 0x000E36E0 File Offset: 0x000E18E0
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022E6 RID: 8934
	private const string Str_WeaponStatus = "WeaponStatus_";
}
