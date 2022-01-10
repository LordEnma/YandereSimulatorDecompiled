using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SenpaiGlobals
{
	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06001715 RID: 5909 RVA: 0x000DF4E8 File Offset: 0x000DD6E8
	// (set) Token: 0x06001716 RID: 5910 RVA: 0x000DF518 File Offset: 0x000DD718
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

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06001717 RID: 5911 RVA: 0x000DF548 File Offset: 0x000DD748
	// (set) Token: 0x06001718 RID: 5912 RVA: 0x000DF578 File Offset: 0x000DD778
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

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x06001719 RID: 5913 RVA: 0x000DF5A8 File Offset: 0x000DD7A8
	// (set) Token: 0x0600171A RID: 5914 RVA: 0x000DF5D8 File Offset: 0x000DD7D8
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

	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600171B RID: 5915 RVA: 0x000DF608 File Offset: 0x000DD808
	// (set) Token: 0x0600171C RID: 5916 RVA: 0x000DF638 File Offset: 0x000DD838
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

	// Token: 0x1700042A RID: 1066
	// (get) Token: 0x0600171D RID: 5917 RVA: 0x000DF668 File Offset: 0x000DD868
	// (set) Token: 0x0600171E RID: 5918 RVA: 0x000DF698 File Offset: 0x000DD898
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

	// Token: 0x1700042B RID: 1067
	// (get) Token: 0x0600171F RID: 5919 RVA: 0x000DF6C8 File Offset: 0x000DD8C8
	// (set) Token: 0x06001720 RID: 5920 RVA: 0x000DF6F8 File Offset: 0x000DD8F8
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

	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x06001721 RID: 5921 RVA: 0x000DF728 File Offset: 0x000DD928
	// (set) Token: 0x06001722 RID: 5922 RVA: 0x000DF758 File Offset: 0x000DD958
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

	// Token: 0x06001723 RID: 5923 RVA: 0x000DF788 File Offset: 0x000DD988
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

	// Token: 0x04002265 RID: 8805
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x04002266 RID: 8806
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x04002267 RID: 8807
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x04002268 RID: 8808
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x04002269 RID: 8809
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x0400226A RID: 8810
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x0400226B RID: 8811
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
