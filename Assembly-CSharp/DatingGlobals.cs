using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000DBA84 File Offset: 0x000D9C84
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000DBAB4 File Offset: 0x000D9CB4
	public static float Affection
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Affection");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Affection", value);
		}
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x060015AB RID: 5547 RVA: 0x000DBAE4 File Offset: 0x000D9CE4
	// (set) Token: 0x060015AC RID: 5548 RVA: 0x000DBB14 File Offset: 0x000D9D14
	public static float AffectionLevel
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_AffectionLevel");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_AffectionLevel", value);
		}
	}

	// Token: 0x060015AD RID: 5549 RVA: 0x000DBB44 File Offset: 0x000D9D44
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x060015AE RID: 5550 RVA: 0x000DBB7C File Offset: 0x000D9D7C
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x060015AF RID: 5551 RVA: 0x000DBBD8 File Offset: 0x000D9DD8
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x060015B0 RID: 5552 RVA: 0x000DBC08 File Offset: 0x000D9E08
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x060015B1 RID: 5553 RVA: 0x000DBC40 File Offset: 0x000D9E40
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x060015B2 RID: 5554 RVA: 0x000DBC9C File Offset: 0x000D9E9C
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x060015B3 RID: 5555 RVA: 0x000DBCCC File Offset: 0x000D9ECC
	// (set) Token: 0x060015B4 RID: 5556 RVA: 0x000DBCFC File Offset: 0x000D9EFC
	public static int SuitorProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorProgress", value);
		}
	}

	// Token: 0x060015B5 RID: 5557 RVA: 0x000DBD2C File Offset: 0x000D9F2C
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x060015B6 RID: 5558 RVA: 0x000DBD64 File Offset: 0x000D9F64
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x060015B7 RID: 5559 RVA: 0x000DBDC0 File Offset: 0x000D9FC0
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x060015B8 RID: 5560 RVA: 0x000DBDF0 File Offset: 0x000D9FF0
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x060015B9 RID: 5561 RVA: 0x000DBE28 File Offset: 0x000DA028
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x060015BA RID: 5562 RVA: 0x000DBE84 File Offset: 0x000DA084
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x060015BB RID: 5563 RVA: 0x000DBEB4 File Offset: 0x000DA0B4
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x060015BC RID: 5564 RVA: 0x000DBEEC File Offset: 0x000DA0EC
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x060015BD RID: 5565 RVA: 0x000DBF48 File Offset: 0x000DA148
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015BE RID: 5566 RVA: 0x000DBF78 File Offset: 0x000DA178
	// (set) Token: 0x060015BF RID: 5567 RVA: 0x000DBFA8 File Offset: 0x000DA1A8
	public static int RivalSabotaged
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalSabotaged");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalSabotaged", value);
		}
	}

	// Token: 0x060015C0 RID: 5568 RVA: 0x000DBFD8 File Offset: 0x000DA1D8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Affection");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AffectionLevel");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", DatingGlobals.KeysOfComplimentGiven());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", DatingGlobals.KeysOfSuitorCheck());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SuitorProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RivalSabotaged");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", DatingGlobals.KeysOfSuitorTrait());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", DatingGlobals.KeysOfTopicDiscussed());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", DatingGlobals.KeysOfTraitDemonstrated());
	}

	// Token: 0x0400220D RID: 8717
	private const string Str_Affection = "Affection";

	// Token: 0x0400220E RID: 8718
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x0400220F RID: 8719
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x04002210 RID: 8720
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x04002211 RID: 8721
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x04002212 RID: 8722
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x04002213 RID: 8723
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x04002214 RID: 8724
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x04002215 RID: 8725
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
