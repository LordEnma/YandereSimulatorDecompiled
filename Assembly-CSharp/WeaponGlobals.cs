using System;
using UnityEngine;

// Token: 0x020002FE RID: 766
public static class WeaponGlobals
{
	// Token: 0x060017B2 RID: 6066 RVA: 0x000E255C File Offset: 0x000E075C
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017B3 RID: 6067 RVA: 0x000E2594 File Offset: 0x000E0794
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017B4 RID: 6068 RVA: 0x000E25F0 File Offset: 0x000E07F0
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x000E2620 File Offset: 0x000E0820
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x040022B2 RID: 8882
	private const string Str_WeaponStatus = "WeaponStatus_";
}
