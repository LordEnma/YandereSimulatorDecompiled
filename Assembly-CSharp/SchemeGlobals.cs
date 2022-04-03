using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class SchemeGlobals
{
	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x06001704 RID: 5892 RVA: 0x000E0638 File Offset: 0x000DE838
	// (set) Token: 0x06001705 RID: 5893 RVA: 0x000E0668 File Offset: 0x000DE868
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
	// (get) Token: 0x06001706 RID: 5894 RVA: 0x000E0698 File Offset: 0x000DE898
	// (set) Token: 0x06001707 RID: 5895 RVA: 0x000E06C8 File Offset: 0x000DE8C8
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
	// (get) Token: 0x06001708 RID: 5896 RVA: 0x000E06F8 File Offset: 0x000DE8F8
	// (set) Token: 0x06001709 RID: 5897 RVA: 0x000E0728 File Offset: 0x000DE928
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

	// Token: 0x0600170A RID: 5898 RVA: 0x000E0758 File Offset: 0x000DE958
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x000E0790 File Offset: 0x000DE990
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x0600170C RID: 5900 RVA: 0x000E07EC File Offset: 0x000DE9EC
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x0600170D RID: 5901 RVA: 0x000E081C File Offset: 0x000DEA1C
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x0600170E RID: 5902 RVA: 0x000E0854 File Offset: 0x000DEA54
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x0600170F RID: 5903 RVA: 0x000E08B0 File Offset: 0x000DEAB0
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x06001710 RID: 5904 RVA: 0x000E08E0 File Offset: 0x000DEAE0
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x06001711 RID: 5905 RVA: 0x000E0918 File Offset: 0x000DEB18
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x06001712 RID: 5906 RVA: 0x000E0974 File Offset: 0x000DEB74
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x06001713 RID: 5907 RVA: 0x000E09A4 File Offset: 0x000DEBA4
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x06001714 RID: 5908 RVA: 0x000E09DC File Offset: 0x000DEBDC
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x06001715 RID: 5909 RVA: 0x000E0A38 File Offset: 0x000DEC38
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x000E0A68 File Offset: 0x000DEC68
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x000E0AA0 File Offset: 0x000DECA0
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x000E0AFC File Offset: 0x000DECFC
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x000E0B2C File Offset: 0x000DED2C
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

	// Token: 0x040022A6 RID: 8870
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x040022A7 RID: 8871
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x040022A8 RID: 8872
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x040022A9 RID: 8873
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x040022AA RID: 8874
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x040022AB RID: 8875
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x040022AC RID: 8876
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x040022AD RID: 8877
	private const string Str_ServicePurchased = "ServicePurchased_";
}
