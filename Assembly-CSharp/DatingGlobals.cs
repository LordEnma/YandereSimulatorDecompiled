using System;
using UnityEngine;

// Token: 0x020002F3 RID: 755
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x060015AB RID: 5547 RVA: 0x000DBED0 File Offset: 0x000DA0D0
	// (set) Token: 0x060015AC RID: 5548 RVA: 0x000DBF00 File Offset: 0x000DA100
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
	// (get) Token: 0x060015AD RID: 5549 RVA: 0x000DBF30 File Offset: 0x000DA130
	// (set) Token: 0x060015AE RID: 5550 RVA: 0x000DBF60 File Offset: 0x000DA160
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

	// Token: 0x060015AF RID: 5551 RVA: 0x000DBF90 File Offset: 0x000DA190
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x060015B0 RID: 5552 RVA: 0x000DBFC8 File Offset: 0x000DA1C8
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x060015B1 RID: 5553 RVA: 0x000DC024 File Offset: 0x000DA224
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x060015B2 RID: 5554 RVA: 0x000DC054 File Offset: 0x000DA254
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x060015B3 RID: 5555 RVA: 0x000DC08C File Offset: 0x000DA28C
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x060015B4 RID: 5556 RVA: 0x000DC0E8 File Offset: 0x000DA2E8
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x060015B5 RID: 5557 RVA: 0x000DC118 File Offset: 0x000DA318
	// (set) Token: 0x060015B6 RID: 5558 RVA: 0x000DC148 File Offset: 0x000DA348
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

	// Token: 0x060015B7 RID: 5559 RVA: 0x000DC178 File Offset: 0x000DA378
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x060015B8 RID: 5560 RVA: 0x000DC1B0 File Offset: 0x000DA3B0
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x060015B9 RID: 5561 RVA: 0x000DC20C File Offset: 0x000DA40C
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x060015BA RID: 5562 RVA: 0x000DC23C File Offset: 0x000DA43C
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x060015BB RID: 5563 RVA: 0x000DC274 File Offset: 0x000DA474
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x060015BC RID: 5564 RVA: 0x000DC2D0 File Offset: 0x000DA4D0
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x060015BD RID: 5565 RVA: 0x000DC300 File Offset: 0x000DA500
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x060015BE RID: 5566 RVA: 0x000DC338 File Offset: 0x000DA538
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x060015BF RID: 5567 RVA: 0x000DC394 File Offset: 0x000DA594
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015C0 RID: 5568 RVA: 0x000DC3C4 File Offset: 0x000DA5C4
	// (set) Token: 0x060015C1 RID: 5569 RVA: 0x000DC3F4 File Offset: 0x000DA5F4
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

	// Token: 0x060015C2 RID: 5570 RVA: 0x000DC424 File Offset: 0x000DA624
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

	// Token: 0x04002217 RID: 8727
	private const string Str_Affection = "Affection";

	// Token: 0x04002218 RID: 8728
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x04002219 RID: 8729
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x0400221A RID: 8730
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x0400221B RID: 8731
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x0400221C RID: 8732
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x0400221D RID: 8733
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x0400221E RID: 8734
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x0400221F RID: 8735
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
