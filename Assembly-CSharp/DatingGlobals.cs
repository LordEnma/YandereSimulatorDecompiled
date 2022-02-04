using System;
using UnityEngine;

// Token: 0x020002EE RID: 750
public static class DatingGlobals
{
	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06001584 RID: 5508 RVA: 0x000D9B10 File Offset: 0x000D7D10
	// (set) Token: 0x06001585 RID: 5509 RVA: 0x000D9B40 File Offset: 0x000D7D40
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

	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06001586 RID: 5510 RVA: 0x000D9B70 File Offset: 0x000D7D70
	// (set) Token: 0x06001587 RID: 5511 RVA: 0x000D9BA0 File Offset: 0x000D7DA0
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

	// Token: 0x06001588 RID: 5512 RVA: 0x000D9BD0 File Offset: 0x000D7DD0
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x06001589 RID: 5513 RVA: 0x000D9C08 File Offset: 0x000D7E08
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x0600158A RID: 5514 RVA: 0x000D9C64 File Offset: 0x000D7E64
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x0600158B RID: 5515 RVA: 0x000D9C94 File Offset: 0x000D7E94
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x000D9CCC File Offset: 0x000D7ECC
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x0600158D RID: 5517 RVA: 0x000D9D28 File Offset: 0x000D7F28
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x0600158E RID: 5518 RVA: 0x000D9D58 File Offset: 0x000D7F58
	// (set) Token: 0x0600158F RID: 5519 RVA: 0x000D9D88 File Offset: 0x000D7F88
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

	// Token: 0x06001590 RID: 5520 RVA: 0x000D9DB8 File Offset: 0x000D7FB8
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x000D9DF0 File Offset: 0x000D7FF0
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x06001592 RID: 5522 RVA: 0x000D9E4C File Offset: 0x000D804C
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x000D9E7C File Offset: 0x000D807C
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x06001594 RID: 5524 RVA: 0x000D9EB4 File Offset: 0x000D80B4
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x06001595 RID: 5525 RVA: 0x000D9F10 File Offset: 0x000D8110
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x06001596 RID: 5526 RVA: 0x000D9F40 File Offset: 0x000D8140
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x06001597 RID: 5527 RVA: 0x000D9F78 File Offset: 0x000D8178
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x000D9FD4 File Offset: 0x000D81D4
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06001599 RID: 5529 RVA: 0x000DA004 File Offset: 0x000D8204
	// (set) Token: 0x0600159A RID: 5530 RVA: 0x000DA034 File Offset: 0x000D8234
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

	// Token: 0x0600159B RID: 5531 RVA: 0x000DA064 File Offset: 0x000D8264
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

	// Token: 0x040021B7 RID: 8631
	private const string Str_Affection = "Affection";

	// Token: 0x040021B8 RID: 8632
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021B9 RID: 8633
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021BA RID: 8634
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021BB RID: 8635
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021BC RID: 8636
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021BD RID: 8637
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021BE RID: 8638
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021BF RID: 8639
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
