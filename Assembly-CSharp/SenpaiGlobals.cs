using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class SenpaiGlobals
{
	// Token: 0x17000429 RID: 1065
	// (get) Token: 0x0600172D RID: 5933 RVA: 0x000E0DC8 File Offset: 0x000DEFC8
	// (set) Token: 0x0600172E RID: 5934 RVA: 0x000E0DF8 File Offset: 0x000DEFF8
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
	// (get) Token: 0x0600172F RID: 5935 RVA: 0x000E0E28 File Offset: 0x000DF028
	// (set) Token: 0x06001730 RID: 5936 RVA: 0x000E0E58 File Offset: 0x000DF058
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
	// (get) Token: 0x06001731 RID: 5937 RVA: 0x000E0E88 File Offset: 0x000DF088
	// (set) Token: 0x06001732 RID: 5938 RVA: 0x000E0EB8 File Offset: 0x000DF0B8
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
	// (get) Token: 0x06001733 RID: 5939 RVA: 0x000E0EE8 File Offset: 0x000DF0E8
	// (set) Token: 0x06001734 RID: 5940 RVA: 0x000E0F18 File Offset: 0x000DF118
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
	// (get) Token: 0x06001735 RID: 5941 RVA: 0x000E0F48 File Offset: 0x000DF148
	// (set) Token: 0x06001736 RID: 5942 RVA: 0x000E0F78 File Offset: 0x000DF178
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
	// (get) Token: 0x06001737 RID: 5943 RVA: 0x000E0FA8 File Offset: 0x000DF1A8
	// (set) Token: 0x06001738 RID: 5944 RVA: 0x000E0FD8 File Offset: 0x000DF1D8
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
	// (get) Token: 0x06001739 RID: 5945 RVA: 0x000E1008 File Offset: 0x000DF208
	// (set) Token: 0x0600173A RID: 5946 RVA: 0x000E1038 File Offset: 0x000DF238
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

	// Token: 0x0600173B RID: 5947 RVA: 0x000E1068 File Offset: 0x000DF268
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

	// Token: 0x040022AB RID: 8875
	private const string Str_CustomSenpai = "CustomSenpai";

	// Token: 0x040022AC RID: 8876
	private const string Str_SenpaiEyeColor = "SenpaiEyeColor";

	// Token: 0x040022AD RID: 8877
	private const string Str_SenpaiEyeWear = "SenpaiEyeWear";

	// Token: 0x040022AE RID: 8878
	private const string Str_SenpaiFacialHair = "SenpaiFacialHair";

	// Token: 0x040022AF RID: 8879
	private const string Str_SenpaiHairColor = "SenpaiHairColor";

	// Token: 0x040022B0 RID: 8880
	private const string Str_SenpaiHairStyle = "SenpaiHairStyle";

	// Token: 0x040022B1 RID: 8881
	private const string Str_SenpaiSkinColor = "SenpaiSkinColor";
}
