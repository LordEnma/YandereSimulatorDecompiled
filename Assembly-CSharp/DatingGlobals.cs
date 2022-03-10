using System;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06001594 RID: 5524 RVA: 0x000DA94C File Offset: 0x000D8B4C
	// (set) Token: 0x06001595 RID: 5525 RVA: 0x000DA97C File Offset: 0x000D8B7C
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
	// (get) Token: 0x06001596 RID: 5526 RVA: 0x000DA9AC File Offset: 0x000D8BAC
	// (set) Token: 0x06001597 RID: 5527 RVA: 0x000DA9DC File Offset: 0x000D8BDC
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

	// Token: 0x06001598 RID: 5528 RVA: 0x000DAA0C File Offset: 0x000D8C0C
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x000DAA44 File Offset: 0x000D8C44
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x0600159A RID: 5530 RVA: 0x000DAAA0 File Offset: 0x000D8CA0
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x000DAAD0 File Offset: 0x000D8CD0
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x000DAB08 File Offset: 0x000D8D08
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x000DAB64 File Offset: 0x000D8D64
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DAB94 File Offset: 0x000D8D94
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DABC4 File Offset: 0x000D8DC4
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

	// Token: 0x060015A0 RID: 5536 RVA: 0x000DABF4 File Offset: 0x000D8DF4
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x060015A1 RID: 5537 RVA: 0x000DAC2C File Offset: 0x000D8E2C
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x060015A2 RID: 5538 RVA: 0x000DAC88 File Offset: 0x000D8E88
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x060015A3 RID: 5539 RVA: 0x000DACB8 File Offset: 0x000D8EB8
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x060015A4 RID: 5540 RVA: 0x000DACF0 File Offset: 0x000D8EF0
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x000DAD4C File Offset: 0x000D8F4C
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x060015A6 RID: 5542 RVA: 0x000DAD7C File Offset: 0x000D8F7C
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x000DADB4 File Offset: 0x000D8FB4
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x000DAE10 File Offset: 0x000D9010
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000DAE40 File Offset: 0x000D9040
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000DAE70 File Offset: 0x000D9070
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

	// Token: 0x060015AB RID: 5547 RVA: 0x000DAEA0 File Offset: 0x000D90A0
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

	// Token: 0x040021E2 RID: 8674
	private const string Str_Affection = "Affection";

	// Token: 0x040021E3 RID: 8675
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021E4 RID: 8676
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021E5 RID: 8677
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021E6 RID: 8678
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021E7 RID: 8679
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021E8 RID: 8680
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021E9 RID: 8681
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021EA RID: 8682
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
