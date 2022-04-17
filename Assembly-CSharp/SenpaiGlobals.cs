using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class SenpaiGlobals
{
	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600173B RID: 5947 RVA: 0x000E15C0 File Offset: 0x000DF7C0
	// (set) Token: 0x0600173C RID: 5948 RVA: 0x000E15F0 File Offset: 0x000DF7F0
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
	// (get) Token: 0x0600173D RID: 5949 RVA: 0x000E1620 File Offset: 0x000DF820
	// (set) Token: 0x0600173E RID: 5950 RVA: 0x000E1650 File Offset: 0x000DF850
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
	// (get) Token: 0x0600173F RID: 5951 RVA: 0x000E1680 File Offset: 0x000DF880
	// (set) Token: 0x06001740 RID: 5952 RVA: 0x000E16B0 File Offset: 0x000DF8B0
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
	// (get) Token: 0x06001741 RID: 5953 RVA: 0x000E16E0 File Offset: 0x000DF8E0
	// (set) Token: 0x06001742 RID: 5954 RVA: 0x000E1710 File Offset: 0x000DF910
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
	// (get) Token: 0x06001743 RID: 5955 RVA: 0x000E1740 File Offset: 0x000DF940
	// (set) Token: 0x06001744 RID: 5956 RVA: 0x000E1770 File Offset: 0x000DF970
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
	// (get) Token: 0x06001745 RID: 5957 RVA: 0x000E17A0 File Offset: 0x000DF9A0
	// (set) Token: 0x06001746 RID: 5958 RVA: 0x000E17D0 File Offset: 0x000DF9D0
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
	// (get) Token: 0x06001747 RID: 5959 RVA: 0x000E1800 File Offset: 0x000DFA00
	// (set) Token: 0x06001748 RID: 5960 RVA: 0x000E1830 File Offset: 0x000DFA30
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

	// Token: 0x06001749 RID: 5961 RVA: 0x000E1860 File Offset: 0x000DFA60
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

	// Token: 0x040022BD RID: 8893
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x040022BE RID: 8894
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x040022BF RID: 8895
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x040022C0 RID: 8896
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x040022C1 RID: 8897
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x040022C2 RID: 8898
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x040022C3 RID: 8899
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
