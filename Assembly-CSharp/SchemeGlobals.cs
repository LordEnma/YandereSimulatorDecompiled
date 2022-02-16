using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class SchemeGlobals
{
	// Token: 0x1700041C RID: 1052
	// (get) Token: 0x060016F0 RID: 5872 RVA: 0x000DF078 File Offset: 0x000DD278
	// (set) Token: 0x060016F1 RID: 5873 RVA: 0x000DF0A8 File Offset: 0x000DD2A8
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
	// (get) Token: 0x060016F2 RID: 5874 RVA: 0x000DF0D8 File Offset: 0x000DD2D8
	// (set) Token: 0x060016F3 RID: 5875 RVA: 0x000DF108 File Offset: 0x000DD308
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
	// (get) Token: 0x060016F4 RID: 5876 RVA: 0x000DF138 File Offset: 0x000DD338
	// (set) Token: 0x060016F5 RID: 5877 RVA: 0x000DF168 File Offset: 0x000DD368
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

	// Token: 0x060016F6 RID: 5878 RVA: 0x000DF198 File Offset: 0x000DD398
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x060016F7 RID: 5879 RVA: 0x000DF1D0 File Offset: 0x000DD3D0
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x060016F8 RID: 5880 RVA: 0x000DF22C File Offset: 0x000DD42C
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x000DF25C File Offset: 0x000DD45C
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x000DF294 File Offset: 0x000DD494
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x000DF2F0 File Offset: 0x000DD4F0
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x000DF320 File Offset: 0x000DD520
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x000DF358 File Offset: 0x000DD558
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x060016FE RID: 5886 RVA: 0x000DF3B4 File Offset: 0x000DD5B4
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x060016FF RID: 5887 RVA: 0x000DF3E4 File Offset: 0x000DD5E4
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x06001700 RID: 5888 RVA: 0x000DF41C File Offset: 0x000DD61C
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x06001701 RID: 5889 RVA: 0x000DF478 File Offset: 0x000DD678
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x06001702 RID: 5890 RVA: 0x000DF4A8 File Offset: 0x000DD6A8
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x06001703 RID: 5891 RVA: 0x000DF4E0 File Offset: 0x000DD6E0
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x06001704 RID: 5892 RVA: 0x000DF53C File Offset: 0x000DD73C
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x000DF56C File Offset: 0x000DD76C
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

	// Token: 0x04002264 RID: 8804
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x04002265 RID: 8805
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x04002266 RID: 8806
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x04002267 RID: 8807
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x04002268 RID: 8808
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x04002269 RID: 8809
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x0400226A RID: 8810
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x0400226B RID: 8811
	private const string Str_ServicePurchased = "ServicePurchased_";
}
