using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class SenpaiGlobals
{
	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x0600170F RID: 5903 RVA: 0x000DEEF0 File Offset: 0x000DD0F0
	// (set) Token: 0x06001710 RID: 5904 RVA: 0x000DEF20 File Offset: 0x000DD120
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

	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06001711 RID: 5905 RVA: 0x000DEF50 File Offset: 0x000DD150
	// (set) Token: 0x06001712 RID: 5906 RVA: 0x000DEF80 File Offset: 0x000DD180
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

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06001713 RID: 5907 RVA: 0x000DEFB0 File Offset: 0x000DD1B0
	// (set) Token: 0x06001714 RID: 5908 RVA: 0x000DEFE0 File Offset: 0x000DD1E0
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

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x06001715 RID: 5909 RVA: 0x000DF010 File Offset: 0x000DD210
	// (set) Token: 0x06001716 RID: 5910 RVA: 0x000DF040 File Offset: 0x000DD240
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

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x06001717 RID: 5911 RVA: 0x000DF070 File Offset: 0x000DD270
	// (set) Token: 0x06001718 RID: 5912 RVA: 0x000DF0A0 File Offset: 0x000DD2A0
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

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x06001719 RID: 5913 RVA: 0x000DF0D0 File Offset: 0x000DD2D0
	// (set) Token: 0x0600171A RID: 5914 RVA: 0x000DF100 File Offset: 0x000DD300
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

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x0600171B RID: 5915 RVA: 0x000DF130 File Offset: 0x000DD330
	// (set) Token: 0x0600171C RID: 5916 RVA: 0x000DF160 File Offset: 0x000DD360
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

	// Token: 0x0600171D RID: 5917 RVA: 0x000DF190 File Offset: 0x000DD390
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

	// Token: 0x0400225D RID: 8797
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x0400225E RID: 8798
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x0400225F RID: 8799
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x04002260 RID: 8800
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x04002261 RID: 8801
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x04002262 RID: 8802
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x04002263 RID: 8803
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
