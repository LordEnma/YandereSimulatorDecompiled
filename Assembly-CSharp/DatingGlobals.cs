using System;
using UnityEngine;

// Token: 0x020002F1 RID: 753
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x0600159D RID: 5533 RVA: 0x000DB2BC File Offset: 0x000D94BC
	// (set) Token: 0x0600159E RID: 5534 RVA: 0x000DB2EC File Offset: 0x000D94EC
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
	// (get) Token: 0x0600159F RID: 5535 RVA: 0x000DB31C File Offset: 0x000D951C
	// (set) Token: 0x060015A0 RID: 5536 RVA: 0x000DB34C File Offset: 0x000D954C
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

	// Token: 0x060015A1 RID: 5537 RVA: 0x000DB37C File Offset: 0x000D957C
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x060015A2 RID: 5538 RVA: 0x000DB3B4 File Offset: 0x000D95B4
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x060015A3 RID: 5539 RVA: 0x000DB410 File Offset: 0x000D9610
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x060015A4 RID: 5540 RVA: 0x000DB440 File Offset: 0x000D9640
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x000DB478 File Offset: 0x000D9678
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x060015A6 RID: 5542 RVA: 0x000DB4D4 File Offset: 0x000D96D4
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x060015A7 RID: 5543 RVA: 0x000DB504 File Offset: 0x000D9704
	// (set) Token: 0x060015A8 RID: 5544 RVA: 0x000DB534 File Offset: 0x000D9734
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

	// Token: 0x060015A9 RID: 5545 RVA: 0x000DB564 File Offset: 0x000D9764
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x060015AA RID: 5546 RVA: 0x000DB59C File Offset: 0x000D979C
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x060015AB RID: 5547 RVA: 0x000DB5F8 File Offset: 0x000D97F8
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x060015AC RID: 5548 RVA: 0x000DB628 File Offset: 0x000D9828
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x060015AD RID: 5549 RVA: 0x000DB660 File Offset: 0x000D9860
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x060015AE RID: 5550 RVA: 0x000DB6BC File Offset: 0x000D98BC
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x060015AF RID: 5551 RVA: 0x000DB6EC File Offset: 0x000D98EC
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x060015B0 RID: 5552 RVA: 0x000DB724 File Offset: 0x000D9924
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x060015B1 RID: 5553 RVA: 0x000DB780 File Offset: 0x000D9980
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015B2 RID: 5554 RVA: 0x000DB7B0 File Offset: 0x000D99B0
	// (set) Token: 0x060015B3 RID: 5555 RVA: 0x000DB7E0 File Offset: 0x000D99E0
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

	// Token: 0x060015B4 RID: 5556 RVA: 0x000DB810 File Offset: 0x000D9A10
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

	// Token: 0x04002200 RID: 8704
	private const string Str_Affection = "Affection";

	// Token: 0x04002201 RID: 8705
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x04002202 RID: 8706
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x04002203 RID: 8707
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x04002204 RID: 8708
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x04002205 RID: 8709
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x04002206 RID: 8710
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x04002207 RID: 8711
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x04002208 RID: 8712
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
