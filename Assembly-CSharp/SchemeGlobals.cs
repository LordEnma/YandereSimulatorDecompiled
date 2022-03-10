using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SchemeGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060016F9 RID: 5881 RVA: 0x000DFC8C File Offset: 0x000DDE8C
	// (set) Token: 0x060016FA RID: 5882 RVA: 0x000DFCBC File Offset: 0x000DDEBC
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
	// (get) Token: 0x060016FB RID: 5883 RVA: 0x000DFCEC File Offset: 0x000DDEEC
	// (set) Token: 0x060016FC RID: 5884 RVA: 0x000DFD1C File Offset: 0x000DDF1C
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
	// (get) Token: 0x060016FD RID: 5885 RVA: 0x000DFD4C File Offset: 0x000DDF4C
	// (set) Token: 0x060016FE RID: 5886 RVA: 0x000DFD7C File Offset: 0x000DDF7C
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

	// Token: 0x060016FF RID: 5887 RVA: 0x000DFDAC File Offset: 0x000DDFAC
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x06001700 RID: 5888 RVA: 0x000DFDE4 File Offset: 0x000DDFE4
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x06001701 RID: 5889 RVA: 0x000DFE40 File Offset: 0x000DE040
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x06001702 RID: 5890 RVA: 0x000DFE70 File Offset: 0x000DE070
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x06001703 RID: 5891 RVA: 0x000DFEA8 File Offset: 0x000DE0A8
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x06001704 RID: 5892 RVA: 0x000DFF04 File Offset: 0x000DE104
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x000DFF34 File Offset: 0x000DE134
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x06001706 RID: 5894 RVA: 0x000DFF6C File Offset: 0x000DE16C
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x06001707 RID: 5895 RVA: 0x000DFFC8 File Offset: 0x000DE1C8
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x06001708 RID: 5896 RVA: 0x000DFFF8 File Offset: 0x000DE1F8
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x000E0030 File Offset: 0x000DE230
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x000E008C File Offset: 0x000DE28C
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x000E00BC File Offset: 0x000DE2BC
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x0600170C RID: 5900 RVA: 0x000E00F4 File Offset: 0x000DE2F4
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x0600170D RID: 5901 RVA: 0x000E0150 File Offset: 0x000DE350
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x0600170E RID: 5902 RVA: 0x000E0180 File Offset: 0x000DE380
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

	// Token: 0x04002287 RID: 8839
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x04002288 RID: 8840
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x04002289 RID: 8841
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x0400228A RID: 8842
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x0400228B RID: 8843
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x0400228C RID: 8844
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x0400228D RID: 8845
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x0400228E RID: 8846
	private const string Str_ServicePurchased = "ServicePurchased_";
}
