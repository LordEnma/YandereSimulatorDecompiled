using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class SenpaiGlobals
{
	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x06001733 RID: 5939 RVA: 0x000E12C8 File Offset: 0x000DF4C8
	// (set) Token: 0x06001734 RID: 5940 RVA: 0x000E12F8 File Offset: 0x000DF4F8
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

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x06001735 RID: 5941 RVA: 0x000E1328 File Offset: 0x000DF528
	// (set) Token: 0x06001736 RID: 5942 RVA: 0x000E1358 File Offset: 0x000DF558
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

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x06001737 RID: 5943 RVA: 0x000E1388 File Offset: 0x000DF588
	// (set) Token: 0x06001738 RID: 5944 RVA: 0x000E13B8 File Offset: 0x000DF5B8
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

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001739 RID: 5945 RVA: 0x000E13E8 File Offset: 0x000DF5E8
	// (set) Token: 0x0600173A RID: 5946 RVA: 0x000E1418 File Offset: 0x000DF618
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

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x0600173B RID: 5947 RVA: 0x000E1448 File Offset: 0x000DF648
	// (set) Token: 0x0600173C RID: 5948 RVA: 0x000E1478 File Offset: 0x000DF678
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

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x0600173D RID: 5949 RVA: 0x000E14A8 File Offset: 0x000DF6A8
	// (set) Token: 0x0600173E RID: 5950 RVA: 0x000E14D8 File Offset: 0x000DF6D8
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

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x0600173F RID: 5951 RVA: 0x000E1508 File Offset: 0x000DF708
	// (set) Token: 0x06001740 RID: 5952 RVA: 0x000E1538 File Offset: 0x000DF738
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

	// Token: 0x06001741 RID: 5953 RVA: 0x000E1568 File Offset: 0x000DF768
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

	// Token: 0x040022B9 RID: 8889
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x040022BA RID: 8890
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x040022BB RID: 8891
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x040022BC RID: 8892
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x040022BD RID: 8893
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x040022BE RID: 8894
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x040022BF RID: 8895
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
