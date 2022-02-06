using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SenpaiGlobals
{
	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06001718 RID: 5912 RVA: 0x000DFB94 File Offset: 0x000DDD94
	// (set) Token: 0x06001719 RID: 5913 RVA: 0x000DFBC4 File Offset: 0x000DDDC4
	public static bool CustomSenpai
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSenpai");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSenpai", value);
		}
	}

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x0600171A RID: 5914 RVA: 0x000DFBF4 File Offset: 0x000DDDF4
	// (set) Token: 0x0600171B RID: 5915 RVA: 0x000DFC24 File Offset: 0x000DDE24
	public static string SenpaiEyeColor
	{
		get
		{
			return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeColor");
		}
		set
		{
			PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeColor", value);
		}
	}

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600171C RID: 5916 RVA: 0x000DFC54 File Offset: 0x000DDE54
	// (set) Token: 0x0600171D RID: 5917 RVA: 0x000DFC84 File Offset: 0x000DDE84
	public static int SenpaiEyeWear
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeWear");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeWear", value);
		}
	}

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x0600171E RID: 5918 RVA: 0x000DFCB4 File Offset: 0x000DDEB4
	// (set) Token: 0x0600171F RID: 5919 RVA: 0x000DFCE4 File Offset: 0x000DDEE4
	public static int SenpaiFacialHair
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiFacialHair");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiFacialHair", value);
		}
	}

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x06001720 RID: 5920 RVA: 0x000DFD14 File Offset: 0x000DDF14
	// (set) Token: 0x06001721 RID: 5921 RVA: 0x000DFD44 File Offset: 0x000DDF44
	public static string SenpaiHairColor
	{
		get
		{
			return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairColor");
		}
		set
		{
			PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairColor", value);
		}
	}

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001722 RID: 5922 RVA: 0x000DFD74 File Offset: 0x000DDF74
	// (set) Token: 0x06001723 RID: 5923 RVA: 0x000DFDA4 File Offset: 0x000DDFA4
	public static int SenpaiHairStyle
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairStyle");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairStyle", value);
		}
	}

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06001724 RID: 5924 RVA: 0x000DFDD4 File Offset: 0x000DDFD4
	// (set) Token: 0x06001725 RID: 5925 RVA: 0x000DFE04 File Offset: 0x000DE004
	public static int SenpaiSkinColor
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSkinColor");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSkinColor", value);
		}
	}

	// Token: 0x06001726 RID: 5926 RVA: 0x000DFE34 File Offset: 0x000DE034
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSenpai");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeColor");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiEyeWear");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiFacialHair");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairColor");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiHairStyle");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSkinColor");
	}

	// Token: 0x04002271 RID: 8817
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x04002272 RID: 8818
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x04002273 RID: 8819
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x04002274 RID: 8820
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x04002275 RID: 8821
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x04002276 RID: 8822
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x04002277 RID: 8823
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
