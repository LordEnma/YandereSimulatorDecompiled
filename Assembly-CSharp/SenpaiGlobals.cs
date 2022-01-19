using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SenpaiGlobals
{
	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06001715 RID: 5909 RVA: 0x000DF5D4 File Offset: 0x000DD7D4
	// (set) Token: 0x06001716 RID: 5910 RVA: 0x000DF604 File Offset: 0x000DD804
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
	// (get) Token: 0x06001717 RID: 5911 RVA: 0x000DF634 File Offset: 0x000DD834
	// (set) Token: 0x06001718 RID: 5912 RVA: 0x000DF664 File Offset: 0x000DD864
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
	// (get) Token: 0x06001719 RID: 5913 RVA: 0x000DF694 File Offset: 0x000DD894
	// (set) Token: 0x0600171A RID: 5914 RVA: 0x000DF6C4 File Offset: 0x000DD8C4
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
	// (get) Token: 0x0600171B RID: 5915 RVA: 0x000DF6F4 File Offset: 0x000DD8F4
	// (set) Token: 0x0600171C RID: 5916 RVA: 0x000DF724 File Offset: 0x000DD924
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
	// (get) Token: 0x0600171D RID: 5917 RVA: 0x000DF754 File Offset: 0x000DD954
	// (set) Token: 0x0600171E RID: 5918 RVA: 0x000DF784 File Offset: 0x000DD984
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
	// (get) Token: 0x0600171F RID: 5919 RVA: 0x000DF7B4 File Offset: 0x000DD9B4
	// (set) Token: 0x06001720 RID: 5920 RVA: 0x000DF7E4 File Offset: 0x000DD9E4
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
	// (get) Token: 0x06001721 RID: 5921 RVA: 0x000DF814 File Offset: 0x000DDA14
	// (set) Token: 0x06001722 RID: 5922 RVA: 0x000DF844 File Offset: 0x000DDA44
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

	// Token: 0x06001723 RID: 5923 RVA: 0x000DF874 File Offset: 0x000DDA74
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

	// Token: 0x04002268 RID: 8808
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x04002269 RID: 8809
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x0400226A RID: 8810
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x0400226B RID: 8811
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x0400226C RID: 8812
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x0400226D RID: 8813
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x0400226E RID: 8814
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
