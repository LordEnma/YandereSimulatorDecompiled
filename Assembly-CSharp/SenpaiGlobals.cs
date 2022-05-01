using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class SenpaiGlobals
{
	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600173F RID: 5951 RVA: 0x000E1A90 File Offset: 0x000DFC90
	// (set) Token: 0x06001740 RID: 5952 RVA: 0x000E1AC0 File Offset: 0x000DFCC0
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
	// (get) Token: 0x06001741 RID: 5953 RVA: 0x000E1AF0 File Offset: 0x000DFCF0
	// (set) Token: 0x06001742 RID: 5954 RVA: 0x000E1B20 File Offset: 0x000DFD20
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
	// (get) Token: 0x06001743 RID: 5955 RVA: 0x000E1B50 File Offset: 0x000DFD50
	// (set) Token: 0x06001744 RID: 5956 RVA: 0x000E1B80 File Offset: 0x000DFD80
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
	// (get) Token: 0x06001745 RID: 5957 RVA: 0x000E1BB0 File Offset: 0x000DFDB0
	// (set) Token: 0x06001746 RID: 5958 RVA: 0x000E1BE0 File Offset: 0x000DFDE0
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
	// (get) Token: 0x06001747 RID: 5959 RVA: 0x000E1C10 File Offset: 0x000DFE10
	// (set) Token: 0x06001748 RID: 5960 RVA: 0x000E1C40 File Offset: 0x000DFE40
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
	// (get) Token: 0x06001749 RID: 5961 RVA: 0x000E1C70 File Offset: 0x000DFE70
	// (set) Token: 0x0600174A RID: 5962 RVA: 0x000E1CA0 File Offset: 0x000DFEA0
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
	// (get) Token: 0x0600174B RID: 5963 RVA: 0x000E1CD0 File Offset: 0x000DFED0
	// (set) Token: 0x0600174C RID: 5964 RVA: 0x000E1D00 File Offset: 0x000DFF00
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

	// Token: 0x0600174D RID: 5965 RVA: 0x000E1D30 File Offset: 0x000DFF30
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

	// Token: 0x040022C6 RID: 8902
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x040022C7 RID: 8903
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x040022C8 RID: 8904
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x040022C9 RID: 8905
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x040022CA RID: 8906
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x040022CB RID: 8907
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x040022CC RID: 8908
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
