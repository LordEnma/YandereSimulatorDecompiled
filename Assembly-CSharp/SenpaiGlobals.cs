using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class SenpaiGlobals
{
	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600173F RID: 5951 RVA: 0x000E1A5C File Offset: 0x000DFC5C
	// (set) Token: 0x06001740 RID: 5952 RVA: 0x000E1A8C File Offset: 0x000DFC8C
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
	// (get) Token: 0x06001741 RID: 5953 RVA: 0x000E1ABC File Offset: 0x000DFCBC
	// (set) Token: 0x06001742 RID: 5954 RVA: 0x000E1AEC File Offset: 0x000DFCEC
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
	// (get) Token: 0x06001743 RID: 5955 RVA: 0x000E1B1C File Offset: 0x000DFD1C
	// (set) Token: 0x06001744 RID: 5956 RVA: 0x000E1B4C File Offset: 0x000DFD4C
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
	// (get) Token: 0x06001745 RID: 5957 RVA: 0x000E1B7C File Offset: 0x000DFD7C
	// (set) Token: 0x06001746 RID: 5958 RVA: 0x000E1BAC File Offset: 0x000DFDAC
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
	// (get) Token: 0x06001747 RID: 5959 RVA: 0x000E1BDC File Offset: 0x000DFDDC
	// (set) Token: 0x06001748 RID: 5960 RVA: 0x000E1C0C File Offset: 0x000DFE0C
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
	// (get) Token: 0x06001749 RID: 5961 RVA: 0x000E1C3C File Offset: 0x000DFE3C
	// (set) Token: 0x0600174A RID: 5962 RVA: 0x000E1C6C File Offset: 0x000DFE6C
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
	// (get) Token: 0x0600174B RID: 5963 RVA: 0x000E1C9C File Offset: 0x000DFE9C
	// (set) Token: 0x0600174C RID: 5964 RVA: 0x000E1CCC File Offset: 0x000DFECC
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

	// Token: 0x0600174D RID: 5965 RVA: 0x000E1CFC File Offset: 0x000DFEFC
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
