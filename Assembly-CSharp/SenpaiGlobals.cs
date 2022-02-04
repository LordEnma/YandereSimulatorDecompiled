using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SenpaiGlobals
{
	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06001716 RID: 5910 RVA: 0x000DFAA8 File Offset: 0x000DDCA8
	// (set) Token: 0x06001717 RID: 5911 RVA: 0x000DFAD8 File Offset: 0x000DDCD8
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

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06001718 RID: 5912 RVA: 0x000DFB08 File Offset: 0x000DDD08
	// (set) Token: 0x06001719 RID: 5913 RVA: 0x000DFB38 File Offset: 0x000DDD38
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

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x0600171A RID: 5914 RVA: 0x000DFB68 File Offset: 0x000DDD68
	// (set) Token: 0x0600171B RID: 5915 RVA: 0x000DFB98 File Offset: 0x000DDD98
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

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600171C RID: 5916 RVA: 0x000DFBC8 File Offset: 0x000DDDC8
	// (set) Token: 0x0600171D RID: 5917 RVA: 0x000DFBF8 File Offset: 0x000DDDF8
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

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x0600171E RID: 5918 RVA: 0x000DFC28 File Offset: 0x000DDE28
	// (set) Token: 0x0600171F RID: 5919 RVA: 0x000DFC58 File Offset: 0x000DDE58
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

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x06001720 RID: 5920 RVA: 0x000DFC88 File Offset: 0x000DDE88
	// (set) Token: 0x06001721 RID: 5921 RVA: 0x000DFCB8 File Offset: 0x000DDEB8
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

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001722 RID: 5922 RVA: 0x000DFCE8 File Offset: 0x000DDEE8
	// (set) Token: 0x06001723 RID: 5923 RVA: 0x000DFD18 File Offset: 0x000DDF18
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

	// Token: 0x06001724 RID: 5924 RVA: 0x000DFD48 File Offset: 0x000DDF48
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

	// Token: 0x0400226E RID: 8814
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x0400226F RID: 8815
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x04002270 RID: 8816
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x04002271 RID: 8817
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x04002272 RID: 8818
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x04002273 RID: 8819
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x04002274 RID: 8820
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
