using UnityEngine;

public static class WeaponGlobals
{
	private const string Str_WeaponStatus = "WeaponStatus_";

	public static int GetWeaponStatus(int weaponID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_WeaponStatus_" + weaponID);
	}

	public static void SetWeaponStatus(int weaponID, int value)
	{
		string text = weaponID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_WeaponStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_WeaponStatus_" + text, value);
	}

	public static int[] KeysOfWeaponStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_WeaponStatus_");
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_WeaponStatus_", KeysOfWeaponStatus());
	}
}
