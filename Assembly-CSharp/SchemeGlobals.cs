using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class SchemeGlobals
{
	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060016DB RID: 5851 RVA: 0x000DDB20 File Offset: 0x000DBD20
	// (set) Token: 0x060016DC RID: 5852 RVA: 0x000DDB50 File Offset: 0x000DBD50
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
	// (get) Token: 0x060016DD RID: 5853 RVA: 0x000DDB80 File Offset: 0x000DBD80
	// (set) Token: 0x060016DE RID: 5854 RVA: 0x000DDBB0 File Offset: 0x000DBDB0
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
	// (get) Token: 0x060016DF RID: 5855 RVA: 0x000DDBE0 File Offset: 0x000DBDE0
	// (set) Token: 0x060016E0 RID: 5856 RVA: 0x000DDC10 File Offset: 0x000DBE10
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

	// Token: 0x060016E1 RID: 5857 RVA: 0x000DDC40 File Offset: 0x000DBE40
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x060016E2 RID: 5858 RVA: 0x000DDC78 File Offset: 0x000DBE78
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x060016E3 RID: 5859 RVA: 0x000DDCD4 File Offset: 0x000DBED4
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x060016E4 RID: 5860 RVA: 0x000DDD04 File Offset: 0x000DBF04
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x060016E5 RID: 5861 RVA: 0x000DDD3C File Offset: 0x000DBF3C
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x000DDD98 File Offset: 0x000DBF98
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x060016E7 RID: 5863 RVA: 0x000DDDC8 File Offset: 0x000DBFC8
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x060016E8 RID: 5864 RVA: 0x000DDE00 File Offset: 0x000DC000
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x060016E9 RID: 5865 RVA: 0x000DDE5C File Offset: 0x000DC05C
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x060016EA RID: 5866 RVA: 0x000DDE8C File Offset: 0x000DC08C
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x060016EB RID: 5867 RVA: 0x000DDEC4 File Offset: 0x000DC0C4
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x060016EC RID: 5868 RVA: 0x000DDF20 File Offset: 0x000DC120
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x060016ED RID: 5869 RVA: 0x000DDF50 File Offset: 0x000DC150
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x060016EE RID: 5870 RVA: 0x000DDF88 File Offset: 0x000DC188
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x060016EF RID: 5871 RVA: 0x000DDFE4 File Offset: 0x000DC1E4
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x060016F0 RID: 5872 RVA: 0x000DE014 File Offset: 0x000DC214
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

	// Token: 0x0400222B RID: 8747
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x0400222C RID: 8748
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x0400222D RID: 8749
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x0400222E RID: 8750
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x0400222F RID: 8751
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x04002230 RID: 8752
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x04002231 RID: 8753
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x04002232 RID: 8754
	private const string Str_ServicePurchased = "ServicePurchased_";
}
