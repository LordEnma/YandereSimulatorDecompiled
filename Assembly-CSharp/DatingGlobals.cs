using System;
using UnityEngine;

// Token: 0x020002EF RID: 751
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x0600158B RID: 5515 RVA: 0x000D9D38 File Offset: 0x000D7F38
	// (set) Token: 0x0600158C RID: 5516 RVA: 0x000D9D68 File Offset: 0x000D7F68
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
	// (get) Token: 0x0600158D RID: 5517 RVA: 0x000D9D98 File Offset: 0x000D7F98
	// (set) Token: 0x0600158E RID: 5518 RVA: 0x000D9DC8 File Offset: 0x000D7FC8
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

	// Token: 0x0600158F RID: 5519 RVA: 0x000D9DF8 File Offset: 0x000D7FF8
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x06001590 RID: 5520 RVA: 0x000D9E30 File Offset: 0x000D8030
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x000D9E8C File Offset: 0x000D808C
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x06001592 RID: 5522 RVA: 0x000D9EBC File Offset: 0x000D80BC
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x000D9EF4 File Offset: 0x000D80F4
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x06001594 RID: 5524 RVA: 0x000D9F50 File Offset: 0x000D8150
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06001595 RID: 5525 RVA: 0x000D9F80 File Offset: 0x000D8180
	// (set) Token: 0x06001596 RID: 5526 RVA: 0x000D9FB0 File Offset: 0x000D81B0
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

	// Token: 0x06001597 RID: 5527 RVA: 0x000D9FE0 File Offset: 0x000D81E0
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x000DA018 File Offset: 0x000D8218
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x000DA074 File Offset: 0x000D8274
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x0600159A RID: 5530 RVA: 0x000DA0A4 File Offset: 0x000D82A4
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x000DA0DC File Offset: 0x000D82DC
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x000DA138 File Offset: 0x000D8338
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x000DA168 File Offset: 0x000D8368
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x0600159E RID: 5534 RVA: 0x000DA1A0 File Offset: 0x000D83A0
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x0600159F RID: 5535 RVA: 0x000DA1FC File Offset: 0x000D83FC
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DA22C File Offset: 0x000D842C
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DA25C File Offset: 0x000D845C
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

	// Token: 0x060015A2 RID: 5538 RVA: 0x000DA28C File Offset: 0x000D848C
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

	// Token: 0x040021BF RID: 8639
	private const string Str_Affection = "Affection";

	// Token: 0x040021C0 RID: 8640
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021C1 RID: 8641
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021C2 RID: 8642
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021C3 RID: 8643
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021C4 RID: 8644
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021C5 RID: 8645
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021C6 RID: 8646
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021C7 RID: 8647
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
