using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class SenpaiGlobals
{
	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x06001708 RID: 5896 RVA: 0x000DE730 File Offset: 0x000DC930
	// (set) Token: 0x06001709 RID: 5897 RVA: 0x000DE760 File Offset: 0x000DC960
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
	// (get) Token: 0x0600170A RID: 5898 RVA: 0x000DE790 File Offset: 0x000DC990
	// (set) Token: 0x0600170B RID: 5899 RVA: 0x000DE7C0 File Offset: 0x000DC9C0
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
	// (get) Token: 0x0600170C RID: 5900 RVA: 0x000DE7F0 File Offset: 0x000DC9F0
	// (set) Token: 0x0600170D RID: 5901 RVA: 0x000DE820 File Offset: 0x000DCA20
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
	// (get) Token: 0x0600170E RID: 5902 RVA: 0x000DE850 File Offset: 0x000DCA50
	// (set) Token: 0x0600170F RID: 5903 RVA: 0x000DE880 File Offset: 0x000DCA80
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
	// (get) Token: 0x06001710 RID: 5904 RVA: 0x000DE8B0 File Offset: 0x000DCAB0
	// (set) Token: 0x06001711 RID: 5905 RVA: 0x000DE8E0 File Offset: 0x000DCAE0
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
	// (get) Token: 0x06001712 RID: 5906 RVA: 0x000DE910 File Offset: 0x000DCB10
	// (set) Token: 0x06001713 RID: 5907 RVA: 0x000DE940 File Offset: 0x000DCB40
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
	// (get) Token: 0x06001714 RID: 5908 RVA: 0x000DE970 File Offset: 0x000DCB70
	// (set) Token: 0x06001715 RID: 5909 RVA: 0x000DE9A0 File Offset: 0x000DCBA0
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

	// Token: 0x06001716 RID: 5910 RVA: 0x000DE9D0 File Offset: 0x000DCBD0
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

	// Token: 0x0400223D RID: 8765
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x0400223E RID: 8766
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x0400223F RID: 8767
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x04002240 RID: 8768
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x04002241 RID: 8769
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x04002242 RID: 8770
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x04002243 RID: 8771
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
