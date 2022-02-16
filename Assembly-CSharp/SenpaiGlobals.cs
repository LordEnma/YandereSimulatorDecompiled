using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class SenpaiGlobals
{
	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x0600171F RID: 5919 RVA: 0x000DFD08 File Offset: 0x000DDF08
	// (set) Token: 0x06001720 RID: 5920 RVA: 0x000DFD38 File Offset: 0x000DDF38
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
	// (get) Token: 0x06001721 RID: 5921 RVA: 0x000DFD68 File Offset: 0x000DDF68
	// (set) Token: 0x06001722 RID: 5922 RVA: 0x000DFD98 File Offset: 0x000DDF98
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
	// (get) Token: 0x06001723 RID: 5923 RVA: 0x000DFDC8 File Offset: 0x000DDFC8
	// (set) Token: 0x06001724 RID: 5924 RVA: 0x000DFDF8 File Offset: 0x000DDFF8
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
	// (get) Token: 0x06001725 RID: 5925 RVA: 0x000DFE28 File Offset: 0x000DE028
	// (set) Token: 0x06001726 RID: 5926 RVA: 0x000DFE58 File Offset: 0x000DE058
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
	// (get) Token: 0x06001727 RID: 5927 RVA: 0x000DFE88 File Offset: 0x000DE088
	// (set) Token: 0x06001728 RID: 5928 RVA: 0x000DFEB8 File Offset: 0x000DE0B8
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
	// (get) Token: 0x06001729 RID: 5929 RVA: 0x000DFEE8 File Offset: 0x000DE0E8
	// (set) Token: 0x0600172A RID: 5930 RVA: 0x000DFF18 File Offset: 0x000DE118
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
	// (get) Token: 0x0600172B RID: 5931 RVA: 0x000DFF48 File Offset: 0x000DE148
	// (set) Token: 0x0600172C RID: 5932 RVA: 0x000DFF78 File Offset: 0x000DE178
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

	// Token: 0x0600172D RID: 5933 RVA: 0x000DFFA8 File Offset: 0x000DE1A8
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

	// Token: 0x04002277 RID: 8823
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x04002278 RID: 8824
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x04002279 RID: 8825
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x0400227A RID: 8826
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x0400227B RID: 8827
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x0400227C RID: 8828
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x0400227D RID: 8829
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
