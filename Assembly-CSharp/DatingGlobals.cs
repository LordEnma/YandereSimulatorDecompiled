using System;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06001597 RID: 5527 RVA: 0x000DADBC File Offset: 0x000D8FBC
	// (set) Token: 0x06001598 RID: 5528 RVA: 0x000DADEC File Offset: 0x000D8FEC
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
	// (get) Token: 0x06001599 RID: 5529 RVA: 0x000DAE1C File Offset: 0x000D901C
	// (set) Token: 0x0600159A RID: 5530 RVA: 0x000DAE4C File Offset: 0x000D904C
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

	// Token: 0x0600159B RID: 5531 RVA: 0x000DAE7C File Offset: 0x000D907C
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x000DAEB4 File Offset: 0x000D90B4
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x000DAF10 File Offset: 0x000D9110
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x0600159E RID: 5534 RVA: 0x000DAF40 File Offset: 0x000D9140
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x0600159F RID: 5535 RVA: 0x000DAF78 File Offset: 0x000D9178
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x060015A0 RID: 5536 RVA: 0x000DAFD4 File Offset: 0x000D91D4
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x060015A1 RID: 5537 RVA: 0x000DB004 File Offset: 0x000D9204
	// (set) Token: 0x060015A2 RID: 5538 RVA: 0x000DB034 File Offset: 0x000D9234
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

	// Token: 0x060015A3 RID: 5539 RVA: 0x000DB064 File Offset: 0x000D9264
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x060015A4 RID: 5540 RVA: 0x000DB09C File Offset: 0x000D929C
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x000DB0F8 File Offset: 0x000D92F8
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x060015A6 RID: 5542 RVA: 0x000DB128 File Offset: 0x000D9328
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x000DB160 File Offset: 0x000D9360
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x000DB1BC File Offset: 0x000D93BC
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x060015A9 RID: 5545 RVA: 0x000DB1EC File Offset: 0x000D93EC
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x060015AA RID: 5546 RVA: 0x000DB224 File Offset: 0x000D9424
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x060015AB RID: 5547 RVA: 0x000DB280 File Offset: 0x000D9480
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015AC RID: 5548 RVA: 0x000DB2B0 File Offset: 0x000D94B0
	// (set) Token: 0x060015AD RID: 5549 RVA: 0x000DB2E0 File Offset: 0x000D94E0
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

	// Token: 0x060015AE RID: 5550 RVA: 0x000DB310 File Offset: 0x000D9510
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

	// Token: 0x040021F2 RID: 8690
	private const string Str_Affection = "Affection";

	// Token: 0x040021F3 RID: 8691
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021F4 RID: 8692
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021F5 RID: 8693
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021F6 RID: 8694
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021F7 RID: 8695
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021F8 RID: 8696
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021F9 RID: 8697
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021FA RID: 8698
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
