using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public static class WeaponGlobals
{
	// Token: 0x060017D8 RID: 6104 RVA: 0x000E46AC File Offset: 0x000E28AC
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017D9 RID: 6105 RVA: 0x000E46E4 File Offset: 0x000E28E4
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017DA RID: 6106 RVA: 0x000E4740 File Offset: 0x000E2940
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017DB RID: 6107 RVA: 0x000E4770 File Offset: 0x000E2970
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x0400230C RID: 8972
	private const string Str_WeaponStatus = "WeaponStatus_";
}
