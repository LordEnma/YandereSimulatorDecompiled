using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class SchemeGlobals
{
	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060016E7 RID: 5863 RVA: 0x000DED60 File Offset: 0x000DCF60
	// (set) Token: 0x060016E8 RID: 5864 RVA: 0x000DED90 File Offset: 0x000DCF90
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
	// (get) Token: 0x060016E9 RID: 5865 RVA: 0x000DEDC0 File Offset: 0x000DCFC0
	// (set) Token: 0x060016EA RID: 5866 RVA: 0x000DEDF0 File Offset: 0x000DCFF0
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
	// (get) Token: 0x060016EB RID: 5867 RVA: 0x000DEE20 File Offset: 0x000DD020
	// (set) Token: 0x060016EC RID: 5868 RVA: 0x000DEE50 File Offset: 0x000DD050
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

	// Token: 0x060016ED RID: 5869 RVA: 0x000DEE80 File Offset: 0x000DD080
	public static int GetSchemePreviousStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + schemeID.ToString());
	}

	// Token: 0x060016EE RID: 5870 RVA: 0x000DEEB8 File Offset: 0x000DD0B8
	public static void SetSchemePreviousStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_" + text, value);
	}

	// Token: 0x060016EF RID: 5871 RVA: 0x000DEF14 File Offset: 0x000DD114
	public static int[] KeysOfSchemePreviousStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemePreviousStage_");
	}

	// Token: 0x060016F0 RID: 5872 RVA: 0x000DEF44 File Offset: 0x000DD144
	public static int GetSchemeStage(int schemeID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + schemeID.ToString());
	}

	// Token: 0x060016F1 RID: 5873 RVA: 0x000DEF7C File Offset: 0x000DD17C
	public static void SetSchemeStage(int schemeID, int value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_" + text, value);
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x000DEFD8 File Offset: 0x000DD1D8
	public static int[] KeysOfSchemeStage()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStage_");
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x000DF008 File Offset: 0x000DD208
	public static bool GetSchemeStatus(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + schemeID.ToString());
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x000DF040 File Offset: 0x000DD240
	public static void SetSchemeStatus(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_" + text, value);
	}

	// Token: 0x060016F5 RID: 5877 RVA: 0x000DF09C File Offset: 0x000DD29C
	public static int[] KeysOfSchemeStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeStatus_");
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x000DF0CC File Offset: 0x000DD2CC
	public static bool GetSchemeUnlocked(int schemeID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + schemeID.ToString());
	}

	// Token: 0x060016F7 RID: 5879 RVA: 0x000DF104 File Offset: 0x000DD304
	public static void SetSchemeUnlocked(int schemeID, bool value)
	{
		string text = schemeID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_" + text, value);
	}

	// Token: 0x060016F8 RID: 5880 RVA: 0x000DF160 File Offset: 0x000DD360
	public static int[] KeysOfSchemeUnlocked()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SchemeUnlocked_");
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x000DF190 File Offset: 0x000DD390
	public static bool GetServicePurchased(int serviceID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + serviceID.ToString());
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x000DF1C8 File Offset: 0x000DD3C8
	public static void SetServicePurchased(int serviceID, bool value)
	{
		string text = serviceID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_" + text, value);
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x000DF224 File Offset: 0x000DD424
	public static int[] KeysOfServicePurchased()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ServicePurchased_");
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x000DF254 File Offset: 0x000DD454
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

	// Token: 0x0400225A RID: 8794
	private const string Str_CurrentScheme = "CurrentScheme";

	// Token: 0x0400225B RID: 8795
	private const string Str_EmbarassingSecret = "EmbarassingSecret";

	// Token: 0x0400225C RID: 8796
	private const string Str_HelpingKokona = "HelpingKokona";

	// Token: 0x0400225D RID: 8797
	private const string Str_SchemePreviousStage = "SchemePreviousStage_";

	// Token: 0x0400225E RID: 8798
	private const string Str_SchemeStage = "SchemeStage_";

	// Token: 0x0400225F RID: 8799
	private const string Str_SchemeStatus = "SchemeStatus_";

	// Token: 0x04002260 RID: 8800
	private const string Str_SchemeUnlocked = "SchemeUnlocked_";

	// Token: 0x04002261 RID: 8801
	private const string Str_ServicePurchased = "ServicePurchased_";
}
