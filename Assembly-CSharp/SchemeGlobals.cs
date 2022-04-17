using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class SchemeGlobals
{
	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x0600170C RID: 5900 RVA: 0x000E0930 File Offset: 0x000DEB30
	// (set) Token: 0x0600170D RID: 5901 RVA: 0x000E0960 File Offset: 0x000DEB60
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
	// (get) Token: 0x0600170E RID: 5902 RVA: 0x000E0990 File Offset: 0x000DEB90
	// (set) Token: 0x0600170F RID: 5903 RVA: 0x000E09C0 File Offset: 0x000DEBC0
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
	// (get) Token: 0x06001710 RID: 5904 RVA: 0x000E09F0 File Offset: 0x000DEBF0
	// (set) Token: 0x06001711 RID: 5905 RVA: 0x000E0A20 File Offset: 0x000DEC20
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

	// Token: 0x06001712 RID: 5906 RVA: 0x000E0A50 File Offset: 0x000DEC50
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x06001713 RID: 5907 RVA: 0x000E0A88 File Offset: 0x000DEC88
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x06001714 RID: 5908 RVA: 0x000E0AE4 File Offset: 0x000DECE4
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x06001715 RID: 5909 RVA: 0x000E0B14 File Offset: 0x000DED14
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x000E0B4C File Offset: 0x000DED4C
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x000E0BA8 File Offset: 0x000DEDA8
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x000E0BD8 File Offset: 0x000DEDD8
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x000E0C10 File Offset: 0x000DEE10
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x0600171A RID: 5914 RVA: 0x000E0C6C File Offset: 0x000DEE6C
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x000E0C9C File Offset: 0x000DEE9C
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x000E0CD4 File Offset: 0x000DEED4
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x000E0D30 File Offset: 0x000DEF30
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x0600171E RID: 5918 RVA: 0x000E0D60 File Offset: 0x000DEF60
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x0600171F RID: 5919 RVA: 0x000E0D98 File Offset: 0x000DEF98
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x06001720 RID: 5920 RVA: 0x000E0DF4 File Offset: 0x000DEFF4
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x06001721 RID: 5921 RVA: 0x000E0E24 File Offset: 0x000DF024
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

	// Token: 0x040022AA RID: 8874
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x040022AB RID: 8875
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x040022AC RID: 8876
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x040022AD RID: 8877
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x040022AE RID: 8878
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x040022AF RID: 8879
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x040022B0 RID: 8880
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x040022B1 RID: 8881
	private const string Str_ServicePurchased = "ServicePurchased_";
}
