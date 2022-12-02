using UnityEngine;

public static class CorkboardGlobals
{
	public static void DeleteAll()
	{
		for (int i = 0; i < 100; i++)
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_Exists", 0);
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_PhotoID", 0);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_PositionX", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_PositionY", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_PositionZ", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_RotationX", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_RotationY", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_RotationZ", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_ScaleX", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_ScaleY", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardPhoto_" + i + "_ScaleZ", 0f);
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_CorkboardString_" + i + "_Exists", 0);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardString_" + i + "_PositionX", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardString_" + i + "_PositionY", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardString_" + i + "_PositionZ", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardString2_" + i + "_PositionX", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardString2_" + i + "_PositionY", 0f);
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile + "_CorkboardString2_" + i + "_PositionZ", 0f);
		}
	}
}
