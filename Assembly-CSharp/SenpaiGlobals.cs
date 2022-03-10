using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class SenpaiGlobals
{
	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000E091C File Offset: 0x000DEB1C
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000E094C File Offset: 0x000DEB4C
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

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000E097C File Offset: 0x000DEB7C
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000E09AC File Offset: 0x000DEBAC
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

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000E09DC File Offset: 0x000DEBDC
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000E0A0C File Offset: 0x000DEC0C
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

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000E0A3C File Offset: 0x000DEC3C
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000E0A6C File Offset: 0x000DEC6C
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

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E0A9C File Offset: 0x000DEC9C
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E0ACC File Offset: 0x000DECCC
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

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000E0AFC File Offset: 0x000DECFC
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000E0B2C File Offset: 0x000DED2C
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

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000E0B5C File Offset: 0x000DED5C
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000E0B8C File Offset: 0x000DED8C
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

	// Token: 0x06001736 RID: 5942 RVA: 0x000E0BBC File Offset: 0x000DEDBC
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

	// Token: 0x0400229A RID: 8858
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x0400229B RID: 8859
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x0400229C RID: 8860
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x0400229D RID: 8861
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x0400229E RID: 8862
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x0400229F RID: 8863
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x040022A0 RID: 8864
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
