using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public static class CorkboardGlobals
{
	// Token: 0x0600180B RID: 6155 RVA: 0x000E3368 File Offset: 0x000E1568
	public static void DeleteAll()
	{
		for (int i = 0; i < 100; i++)
		{
			PlayerPrefs.SetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_Exists"
			}), 0);
			PlayerPrefs.SetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PhotoID"
			}), 0);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PositionX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PositionY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PositionZ"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_RotationX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_RotationY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_RotationZ"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_ScaleX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_ScaleY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_ScaleZ"
			}), 0f);
			PlayerPrefs.SetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_Exists"
			}), 0);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_PositionX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_PositionY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_PositionZ"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString2_",
				i.ToString(),
				"_PositionX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString2_",
				i.ToString(),
				"_PositionY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString2_",
				i.ToString(),
				"_PositionZ"
			}), 0f);
		}
	}
}
