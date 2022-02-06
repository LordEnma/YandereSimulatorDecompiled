using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class SchemeGlobals
{
	// Token: 0x1700041B RID: 1051
	// (get) Token: 0x060016E9 RID: 5865 RVA: 0x000DEF04 File Offset: 0x000DD104
	// (set) Token: 0x060016EA RID: 5866 RVA: 0x000DEF34 File Offset: 0x000DD134
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

	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060016EB RID: 5867 RVA: 0x000DEF64 File Offset: 0x000DD164
	// (set) Token: 0x060016EC RID: 5868 RVA: 0x000DEF94 File Offset: 0x000DD194
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

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x060016ED RID: 5869 RVA: 0x000DEFC4 File Offset: 0x000DD1C4
	// (set) Token: 0x060016EE RID: 5870 RVA: 0x000DEFF4 File Offset: 0x000DD1F4
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

	// Token: 0x060016EF RID: 5871 RVA: 0x000DF024 File Offset: 0x000DD224
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x060016F0 RID: 5872 RVA: 0x000DF05C File Offset: 0x000DD25C
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x060016F1 RID: 5873 RVA: 0x000DF0B8 File Offset: 0x000DD2B8
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x000DF0E8 File Offset: 0x000DD2E8
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x000DF120 File Offset: 0x000DD320
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x000DF17C File Offset: 0x000DD37C
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x060016F5 RID: 5877 RVA: 0x000DF1AC File Offset: 0x000DD3AC
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x000DF1E4 File Offset: 0x000DD3E4
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x060016F7 RID: 5879 RVA: 0x000DF240 File Offset: 0x000DD440
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x060016F8 RID: 5880 RVA: 0x000DF270 File Offset: 0x000DD470
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x000DF2A8 File Offset: 0x000DD4A8
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x000DF304 File Offset: 0x000DD504
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x000DF334 File Offset: 0x000DD534
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x000DF36C File Offset: 0x000DD56C
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x000DF3C8 File Offset: 0x000DD5C8
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x060016FE RID: 5886 RVA: 0x000DF3F8 File Offset: 0x000DD5F8
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

	// Token: 0x0400225E RID: 8798
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x0400225F RID: 8799
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x04002260 RID: 8800
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x04002261 RID: 8801
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x04002262 RID: 8802
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x04002263 RID: 8803
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x04002264 RID: 8804
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x04002265 RID: 8805
	private const string Str_ServicePurchased = "ServicePurchased_";
}
