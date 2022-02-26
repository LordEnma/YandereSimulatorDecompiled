using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SchemeGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060016F9 RID: 5881 RVA: 0x000DF95C File Offset: 0x000DDB5C
	// (set) Token: 0x060016FA RID: 5882 RVA: 0x000DF98C File Offset: 0x000DDB8C
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

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x060016FB RID: 5883 RVA: 0x000DF9BC File Offset: 0x000DDBBC
	// (set) Token: 0x060016FC RID: 5884 RVA: 0x000DF9EC File Offset: 0x000DDBEC
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

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x060016FD RID: 5885 RVA: 0x000DFA1C File Offset: 0x000DDC1C
	// (set) Token: 0x060016FE RID: 5886 RVA: 0x000DFA4C File Offset: 0x000DDC4C
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

	// Token: 0x060016FF RID: 5887 RVA: 0x000DFA7C File Offset: 0x000DDC7C
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x06001700 RID: 5888 RVA: 0x000DFAB4 File Offset: 0x000DDCB4
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x06001701 RID: 5889 RVA: 0x000DFB10 File Offset: 0x000DDD10
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x06001702 RID: 5890 RVA: 0x000DFB40 File Offset: 0x000DDD40
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x06001703 RID: 5891 RVA: 0x000DFB78 File Offset: 0x000DDD78
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x06001704 RID: 5892 RVA: 0x000DFBD4 File Offset: 0x000DDDD4
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x000DFC04 File Offset: 0x000DDE04
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x06001706 RID: 5894 RVA: 0x000DFC3C File Offset: 0x000DDE3C
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x06001707 RID: 5895 RVA: 0x000DFC98 File Offset: 0x000DDE98
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x06001708 RID: 5896 RVA: 0x000DFCC8 File Offset: 0x000DDEC8
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x000DFD00 File Offset: 0x000DDF00
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x000DFD5C File Offset: 0x000DDF5C
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x000DFD8C File Offset: 0x000DDF8C
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x0600170C RID: 5900 RVA: 0x000DFDC4 File Offset: 0x000DDFC4
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x0600170D RID: 5901 RVA: 0x000DFE20 File Offset: 0x000DE020
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x0600170E RID: 5902 RVA: 0x000DFE50 File Offset: 0x000DE050
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

	// Token: 0x04002273 RID: 8819
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x04002274 RID: 8820
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x04002275 RID: 8821
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x04002276 RID: 8822
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x04002277 RID: 8823
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x04002278 RID: 8824
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x04002279 RID: 8825
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x0400227A RID: 8826
	private const string Str_ServicePurchased = "ServicePurchased_";
}
