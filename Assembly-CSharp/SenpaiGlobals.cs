using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class SenpaiGlobals
{
	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x06001739 RID: 5945 RVA: 0x000E13D8 File Offset: 0x000DF5D8
	// (set) Token: 0x0600173A RID: 5946 RVA: 0x000E1408 File Offset: 0x000DF608
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
	// (get) Token: 0x0600173B RID: 5947 RVA: 0x000E1438 File Offset: 0x000DF638
	// (set) Token: 0x0600173C RID: 5948 RVA: 0x000E1468 File Offset: 0x000DF668
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
	// (get) Token: 0x0600173D RID: 5949 RVA: 0x000E1498 File Offset: 0x000DF698
	// (set) Token: 0x0600173E RID: 5950 RVA: 0x000E14C8 File Offset: 0x000DF6C8
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
	// (get) Token: 0x0600173F RID: 5951 RVA: 0x000E14F8 File Offset: 0x000DF6F8
	// (set) Token: 0x06001740 RID: 5952 RVA: 0x000E1528 File Offset: 0x000DF728
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
	// (get) Token: 0x06001741 RID: 5953 RVA: 0x000E1558 File Offset: 0x000DF758
	// (set) Token: 0x06001742 RID: 5954 RVA: 0x000E1588 File Offset: 0x000DF788
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
	// (get) Token: 0x06001743 RID: 5955 RVA: 0x000E15B8 File Offset: 0x000DF7B8
	// (set) Token: 0x06001744 RID: 5956 RVA: 0x000E15E8 File Offset: 0x000DF7E8
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
	// (get) Token: 0x06001745 RID: 5957 RVA: 0x000E1618 File Offset: 0x000DF818
	// (set) Token: 0x06001746 RID: 5958 RVA: 0x000E1648 File Offset: 0x000DF848
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

	// Token: 0x06001747 RID: 5959 RVA: 0x000E1678 File Offset: 0x000DF878
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

	// Token: 0x040022BB RID: 8891
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x040022BC RID: 8892
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x040022BD RID: 8893
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x040022BE RID: 8894
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x040022BF RID: 8895
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x040022C0 RID: 8896
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x040022C1 RID: 8897
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
