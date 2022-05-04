using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class SchemeGlobals
{
	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x06001710 RID: 5904 RVA: 0x000E0DCC File Offset: 0x000DEFCC
	// (set) Token: 0x06001711 RID: 5905 RVA: 0x000E0DFC File Offset: 0x000DEFFC
	public static int CurrentScheme
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentScheme");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentScheme", value);
		}
	}

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x06001712 RID: 5906 RVA: 0x000E0E2C File Offset: 0x000DF02C
	// (set) Token: 0x06001713 RID: 5907 RVA: 0x000E0E5C File Offset: 0x000DF05C
	public static bool EmbarassingSecret
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmbarassingSecret");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmbarassingSecret", value);
		}
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x06001714 RID: 5908 RVA: 0x000E0E8C File Offset: 0x000DF08C
	// (set) Token: 0x06001715 RID: 5909 RVA: 0x000E0EBC File Offset: 0x000DF0BC
	public static bool HelpingKokona
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HelpingKokona");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HelpingKokona", value);
		}
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x000E0EEC File Offset: 0x000DF0EC
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x000E0F24 File Offset: 0x000DF124
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x000E0F80 File Offset: 0x000DF180
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x000E0FB0 File Offset: 0x000DF1B0
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x0600171A RID: 5914 RVA: 0x000E0FE8 File Offset: 0x000DF1E8
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x000E1044 File Offset: 0x000DF244
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x000E1074 File Offset: 0x000DF274
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x000E10AC File Offset: 0x000DF2AC
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x0600171E RID: 5918 RVA: 0x000E1108 File Offset: 0x000DF308
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x0600171F RID: 5919 RVA: 0x000E1138 File Offset: 0x000DF338
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x06001720 RID: 5920 RVA: 0x000E1170 File Offset: 0x000DF370
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x06001721 RID: 5921 RVA: 0x000E11CC File Offset: 0x000DF3CC
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x06001722 RID: 5922 RVA: 0x000E11FC File Offset: 0x000DF3FC
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x000E1234 File Offset: 0x000DF434
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x000E1290 File Offset: 0x000DF490
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x000E12C0 File Offset: 0x000DF4C0
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentScheme");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EmbarassingSecret");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HelpingKokona");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", SchemeGlobals.KeysOfSchemePreviousStage());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", SchemeGlobals.KeysOfSchemeStage());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", SchemeGlobals.KeysOfSchemeStatus());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", SchemeGlobals.KeysOfSchemeUnlocked());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", SchemeGlobals.KeysOfServicePurchased());
	}

	// Token: 0x040022B3 RID: 8883
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x040022B4 RID: 8884
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x040022B5 RID: 8885
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x040022B6 RID: 8886
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x040022B7 RID: 8887
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x040022B8 RID: 8888
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x040022B9 RID: 8889
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x040022BA RID: 8890
	private const string Str_ServicePurchased = "ServicePurchased_";
}
