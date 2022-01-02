using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class SchemeGlobals
{
	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060016E2 RID: 5858 RVA: 0x000DE530 File Offset: 0x000DC730
	// (set) Token: 0x060016E3 RID: 5859 RVA: 0x000DE560 File Offset: 0x000DC760
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

	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x060016E4 RID: 5860 RVA: 0x000DE590 File Offset: 0x000DC790
	// (set) Token: 0x060016E5 RID: 5861 RVA: 0x000DE5C0 File Offset: 0x000DC7C0
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

	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060016E6 RID: 5862 RVA: 0x000DE5F0 File Offset: 0x000DC7F0
	// (set) Token: 0x060016E7 RID: 5863 RVA: 0x000DE620 File Offset: 0x000DC820
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

	// Token: 0x060016E8 RID: 5864 RVA: 0x000DE650 File Offset: 0x000DC850
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x060016E9 RID: 5865 RVA: 0x000DE688 File Offset: 0x000DC888
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x060016EA RID: 5866 RVA: 0x000DE6E4 File Offset: 0x000DC8E4
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x060016EB RID: 5867 RVA: 0x000DE714 File Offset: 0x000DC914
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x060016EC RID: 5868 RVA: 0x000DE74C File Offset: 0x000DC94C
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x060016ED RID: 5869 RVA: 0x000DE7A8 File Offset: 0x000DC9A8
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x060016EE RID: 5870 RVA: 0x000DE7D8 File Offset: 0x000DC9D8
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x060016EF RID: 5871 RVA: 0x000DE810 File Offset: 0x000DCA10
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x060016F0 RID: 5872 RVA: 0x000DE86C File Offset: 0x000DCA6C
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x060016F1 RID: 5873 RVA: 0x000DE89C File Offset: 0x000DCA9C
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x000DE8D4 File Offset: 0x000DCAD4
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x000DE930 File Offset: 0x000DCB30
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x000DE960 File Offset: 0x000DCB60
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x060016F5 RID: 5877 RVA: 0x000DE998 File Offset: 0x000DCB98
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x000DE9F4 File Offset: 0x000DCBF4
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x060016F7 RID: 5879 RVA: 0x000DEA24 File Offset: 0x000DCC24
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

	// Token: 0x0400224E RID: 8782
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x0400224F RID: 8783
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x04002250 RID: 8784
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x04002251 RID: 8785
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x04002252 RID: 8786
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x04002253 RID: 8787
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x04002254 RID: 8788
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x04002255 RID: 8789
	private const string Str_ServicePurchased = "ServicePurchased_";
}
