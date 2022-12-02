using UnityEngine;

public static class SenpaiGlobals
{
	private const string Str_CustomSenpai = "CustomSenpai";

	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";

	public static bool CustomSenpai
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_CustomSenpai");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_CustomSenpai", value);
		}
	}

	public static string SenpaiEyeColor
	{
		get
		{
			return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile + "_SenpaiEyeColor");
		}
		set
		{
			PlayerPrefs.SetString("Profile_" + GameGlobals.Profile + "_SenpaiEyeColor", value);
		}
	}

	public static int SenpaiEyeWear
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiEyeWear");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiEyeWear", value);
		}
	}

	public static int SenpaiFacialHair
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiFacialHair");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiFacialHair", value);
		}
	}

	public static string SenpaiHairColor
	{
		get
		{
			return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile + "_SenpaiHairColor");
		}
		set
		{
			PlayerPrefs.SetString("Profile_" + GameGlobals.Profile + "_SenpaiHairColor", value);
		}
	}

	public static int SenpaiHairStyle
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiHairStyle");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiHairStyle", value);
		}
	}

	public static int SenpaiSkinColor
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_SenpaiSkinColor");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_SenpaiSkinColor", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile + "_CustomSenpai");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiEyeColor");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiEyeWear");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiFacialHair");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiHairColor");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiHairStyle");
		Globals.Delete("Profile_" + GameGlobals.Profile + "_SenpaiSkinColor");
	}
}
