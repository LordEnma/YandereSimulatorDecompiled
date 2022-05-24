using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class SchemeGlobals
{
	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x06001714 RID: 5908 RVA: 0x000E12C4 File Offset: 0x000DF4C4
	// (set) Token: 0x06001715 RID: 5909 RVA: 0x000E12F4 File Offset: 0x000DF4F4
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

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x06001716 RID: 5910 RVA: 0x000E1324 File Offset: 0x000DF524
	// (set) Token: 0x06001717 RID: 5911 RVA: 0x000E1354 File Offset: 0x000DF554
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

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x06001718 RID: 5912 RVA: 0x000E1384 File Offset: 0x000DF584
	// (set) Token: 0x06001719 RID: 5913 RVA: 0x000E13B4 File Offset: 0x000DF5B4
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

	// Token: 0x0600171A RID: 5914 RVA: 0x000E13E4 File Offset: 0x000DF5E4
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x000E141C File Offset: 0x000DF61C
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x000E1478 File Offset: 0x000DF678
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x000E14A8 File Offset: 0x000DF6A8
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x0600171E RID: 5918 RVA: 0x000E14E0 File Offset: 0x000DF6E0
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x0600171F RID: 5919 RVA: 0x000E153C File Offset: 0x000DF73C
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x06001720 RID: 5920 RVA: 0x000E156C File Offset: 0x000DF76C
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x06001721 RID: 5921 RVA: 0x000E15A4 File Offset: 0x000DF7A4
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x06001722 RID: 5922 RVA: 0x000E1600 File Offset: 0x000DF800
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x000E1630 File Offset: 0x000DF830
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x000E1668 File Offset: 0x000DF868
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x000E16C4 File Offset: 0x000DF8C4
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x06001726 RID: 5926 RVA: 0x000E16F4 File Offset: 0x000DF8F4
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x000E172C File Offset: 0x000DF92C
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x000E1788 File Offset: 0x000DF988
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x000E17B8 File Offset: 0x000DF9B8
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

	// Token: 0x040022BE RID: 8894
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x040022BF RID: 8895
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x040022C0 RID: 8896
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x040022C1 RID: 8897
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x040022C2 RID: 8898
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x040022C3 RID: 8899
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x040022C4 RID: 8900
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x040022C5 RID: 8901
	private const string Str_ServicePurchased = "ServicePurchased_";
}
