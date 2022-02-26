using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class SenpaiGlobals
{
	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000E05EC File Offset: 0x000DE7EC
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000E061C File Offset: 0x000DE81C
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
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000E064C File Offset: 0x000DE84C
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000E067C File Offset: 0x000DE87C
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
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000E06AC File Offset: 0x000DE8AC
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000E06DC File Offset: 0x000DE8DC
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
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000E070C File Offset: 0x000DE90C
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000E073C File Offset: 0x000DE93C
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
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E076C File Offset: 0x000DE96C
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E079C File Offset: 0x000DE99C
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
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000E07CC File Offset: 0x000DE9CC
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000E07FC File Offset: 0x000DE9FC
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
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000E082C File Offset: 0x000DEA2C
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000E085C File Offset: 0x000DEA5C
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

	// Token: 0x06001736 RID: 5942 RVA: 0x000E088C File Offset: 0x000DEA8C
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

	// Token: 0x04002286 RID: 8838
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x04002287 RID: 8839
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x04002288 RID: 8840
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x04002289 RID: 8841
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x0400228A RID: 8842
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x0400228B RID: 8843
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x0400228C RID: 8844
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
