using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public static class WeaponGlobals
{
	// Token: 0x060017D8 RID: 6104 RVA: 0x000E4828 File Offset: 0x000E2A28
	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + weaponID.ToString());
	}

	// Token: 0x060017D9 RID: 6105 RVA: 0x000E4860 File Offset: 0x000E2A60
	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_" + text, value);
	}

	// Token: 0x060017DA RID: 6106 RVA: 0x000E48BC File Offset: 0x000E2ABC
	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_");
	}

	// Token: 0x060017DB RID: 6107 RVA: 0x000E48EC File Offset: 0x000E2AEC
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_WeaponStatus_", WeaponGlobals.KeysOfWeaponStatus());
	}

	// Token: 0x0400230D RID: 8973
	private const string Str_WeaponStatus = "WeaponStatus_";
}
