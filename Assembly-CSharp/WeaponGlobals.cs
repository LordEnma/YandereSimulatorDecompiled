using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class WeaponGlobals
{
	// Token: 0x0600179B RID: 6043 RVA: 0x000E0F84 File Offset: 0x000DF184
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x0600179C RID: 6044 RVA: 0x000E0FBC File Offset: 0x000DF1BC
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x0600179D RID: 6045 RVA: 0x000E1018 File Offset: 0x000DF218
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x0600179E RID: 6046 RVA: 0x000E1048 File Offset: 0x000DF248
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x04002278 RID: 8824
	private const string Str_WeaponStatus = "WeaponStatus_";
}
