using System;
using UnityEngine;

// Token: 0x020002FE RID: 766
public static class SenpaiGlobals
{
	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x06001743 RID: 5955 RVA: 0x000E1F54 File Offset: 0x000E0154
	// (set) Token: 0x06001744 RID: 5956 RVA: 0x000E1F84 File Offset: 0x000E0184
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

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x06001745 RID: 5957 RVA: 0x000E1FB4 File Offset: 0x000E01B4
	// (set) Token: 0x06001746 RID: 5958 RVA: 0x000E1FE4 File Offset: 0x000E01E4
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

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001747 RID: 5959 RVA: 0x000E2014 File Offset: 0x000E0214
	// (set) Token: 0x06001748 RID: 5960 RVA: 0x000E2044 File Offset: 0x000E0244
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

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06001749 RID: 5961 RVA: 0x000E2074 File Offset: 0x000E0274
	// (set) Token: 0x0600174A RID: 5962 RVA: 0x000E20A4 File Offset: 0x000E02A4
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

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x0600174B RID: 5963 RVA: 0x000E20D4 File Offset: 0x000E02D4
	// (set) Token: 0x0600174C RID: 5964 RVA: 0x000E2104 File Offset: 0x000E0304
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

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x0600174D RID: 5965 RVA: 0x000E2134 File Offset: 0x000E0334
	// (set) Token: 0x0600174E RID: 5966 RVA: 0x000E2164 File Offset: 0x000E0364
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

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x0600174F RID: 5967 RVA: 0x000E2194 File Offset: 0x000E0394
	// (set) Token: 0x06001750 RID: 5968 RVA: 0x000E21C4 File Offset: 0x000E03C4
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

	// Token: 0x06001751 RID: 5969 RVA: 0x000E21F4 File Offset: 0x000E03F4
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

	// Token: 0x040022D1 RID: 8913
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x040022D2 RID: 8914
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x040022D3 RID: 8915
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x040022D4 RID: 8916
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x040022D5 RID: 8917
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x040022D6 RID: 8918
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x040022D7 RID: 8919
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
