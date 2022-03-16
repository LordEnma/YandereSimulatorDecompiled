using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SchemeGlobals
{
	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x060016FE RID: 5886 RVA: 0x000E0138 File Offset: 0x000DE338
	// (set) Token: 0x060016FF RID: 5887 RVA: 0x000E0168 File Offset: 0x000DE368
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
	// (get) Token: 0x06001700 RID: 5888 RVA: 0x000E0198 File Offset: 0x000DE398
	// (set) Token: 0x06001701 RID: 5889 RVA: 0x000E01C8 File Offset: 0x000DE3C8
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
	// (get) Token: 0x06001702 RID: 5890 RVA: 0x000E01F8 File Offset: 0x000DE3F8
	// (set) Token: 0x06001703 RID: 5891 RVA: 0x000E0228 File Offset: 0x000DE428
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

	// Token: 0x06001704 RID: 5892 RVA: 0x000E0258 File Offset: 0x000DE458
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x000E0290 File Offset: 0x000DE490
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x06001706 RID: 5894 RVA: 0x000E02EC File Offset: 0x000DE4EC
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x06001707 RID: 5895 RVA: 0x000E031C File Offset: 0x000DE51C
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x06001708 RID: 5896 RVA: 0x000E0354 File Offset: 0x000DE554
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x000E03B0 File Offset: 0x000DE5B0
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x000E03E0 File Offset: 0x000DE5E0
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x000E0418 File Offset: 0x000DE618
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x0600170C RID: 5900 RVA: 0x000E0474 File Offset: 0x000DE674
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x0600170D RID: 5901 RVA: 0x000E04A4 File Offset: 0x000DE6A4
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x0600170E RID: 5902 RVA: 0x000E04DC File Offset: 0x000DE6DC
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x0600170F RID: 5903 RVA: 0x000E0538 File Offset: 0x000DE738
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x06001710 RID: 5904 RVA: 0x000E0568 File Offset: 0x000DE768
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x06001711 RID: 5905 RVA: 0x000E05A0 File Offset: 0x000DE7A0
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x06001712 RID: 5906 RVA: 0x000E05FC File Offset: 0x000DE7FC
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x06001713 RID: 5907 RVA: 0x000E062C File Offset: 0x000DE82C
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

	// Token: 0x04002298 RID: 8856
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x04002299 RID: 8857
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x0400229A RID: 8858
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x0400229B RID: 8859
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x0400229C RID: 8860
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x0400229D RID: 8861
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x0400229E RID: 8862
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x0400229F RID: 8863
	private const string Str_ServicePurchased = "ServicePurchased_";
}
