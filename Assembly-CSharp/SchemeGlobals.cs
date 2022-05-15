using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class SchemeGlobals
{
	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x06001714 RID: 5908 RVA: 0x000E1148 File Offset: 0x000DF348
	// (set) Token: 0x06001715 RID: 5909 RVA: 0x000E1178 File Offset: 0x000DF378
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
	// (get) Token: 0x06001716 RID: 5910 RVA: 0x000E11A8 File Offset: 0x000DF3A8
	// (set) Token: 0x06001717 RID: 5911 RVA: 0x000E11D8 File Offset: 0x000DF3D8
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
	// (get) Token: 0x06001718 RID: 5912 RVA: 0x000E1208 File Offset: 0x000DF408
	// (set) Token: 0x06001719 RID: 5913 RVA: 0x000E1238 File Offset: 0x000DF438
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

	// Token: 0x0600171A RID: 5914 RVA: 0x000E1268 File Offset: 0x000DF468
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x000E12A0 File Offset: 0x000DF4A0
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x000E12FC File Offset: 0x000DF4FC
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x000E132C File Offset: 0x000DF52C
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x0600171E RID: 5918 RVA: 0x000E1364 File Offset: 0x000DF564
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x0600171F RID: 5919 RVA: 0x000E13C0 File Offset: 0x000DF5C0
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x06001720 RID: 5920 RVA: 0x000E13F0 File Offset: 0x000DF5F0
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x06001721 RID: 5921 RVA: 0x000E1428 File Offset: 0x000DF628
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x06001722 RID: 5922 RVA: 0x000E1484 File Offset: 0x000DF684
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x000E14B4 File Offset: 0x000DF6B4
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x000E14EC File Offset: 0x000DF6EC
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x000E1548 File Offset: 0x000DF748
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x06001726 RID: 5926 RVA: 0x000E1578 File Offset: 0x000DF778
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x000E15B0 File Offset: 0x000DF7B0
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x000E160C File Offset: 0x000DF80C
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x000E163C File Offset: 0x000DF83C
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

	// Token: 0x040022BD RID: 8893
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x040022BE RID: 8894
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x040022BF RID: 8895
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x040022C0 RID: 8896
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x040022C1 RID: 8897
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x040022C2 RID: 8898
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x040022C3 RID: 8899
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x040022C4 RID: 8900
	private const string Str_ServicePurchased = "ServicePurchased_";
}
