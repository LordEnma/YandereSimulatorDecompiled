using System;
using UnityEngine;

// Token: 0x020002EE RID: 750
public static class DatingGlobals
{
	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06001583 RID: 5507 RVA: 0x000D963C File Offset: 0x000D783C
	// (set) Token: 0x06001584 RID: 5508 RVA: 0x000D966C File Offset: 0x000D786C
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
	// (get) Token: 0x06001585 RID: 5509 RVA: 0x000D969C File Offset: 0x000D789C
	// (set) Token: 0x06001586 RID: 5510 RVA: 0x000D96CC File Offset: 0x000D78CC
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

	// Token: 0x06001587 RID: 5511 RVA: 0x000D96FC File Offset: 0x000D78FC
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x000D9734 File Offset: 0x000D7934
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x06001589 RID: 5513 RVA: 0x000D9790 File Offset: 0x000D7990
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x0600158A RID: 5514 RVA: 0x000D97C0 File Offset: 0x000D79C0
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x0600158B RID: 5515 RVA: 0x000D97F8 File Offset: 0x000D79F8
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x000D9854 File Offset: 0x000D7A54
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x0600158D RID: 5517 RVA: 0x000D9884 File Offset: 0x000D7A84
	// (set) Token: 0x0600158E RID: 5518 RVA: 0x000D98B4 File Offset: 0x000D7AB4
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

	// Token: 0x0600158F RID: 5519 RVA: 0x000D98E4 File Offset: 0x000D7AE4
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x06001590 RID: 5520 RVA: 0x000D991C File Offset: 0x000D7B1C
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x000D9978 File Offset: 0x000D7B78
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x06001592 RID: 5522 RVA: 0x000D99A8 File Offset: 0x000D7BA8
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x000D99E0 File Offset: 0x000D7BE0
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x06001594 RID: 5524 RVA: 0x000D9A3C File Offset: 0x000D7C3C
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x06001595 RID: 5525 RVA: 0x000D9A6C File Offset: 0x000D7C6C
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x06001596 RID: 5526 RVA: 0x000D9AA4 File Offset: 0x000D7CA4
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x06001597 RID: 5527 RVA: 0x000D9B00 File Offset: 0x000D7D00
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06001598 RID: 5528 RVA: 0x000D9B30 File Offset: 0x000D7D30
	// (set) Token: 0x06001599 RID: 5529 RVA: 0x000D9B60 File Offset: 0x000D7D60
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

	// Token: 0x0600159A RID: 5530 RVA: 0x000D9B90 File Offset: 0x000D7D90
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

	// Token: 0x040021B1 RID: 8625
	private const string Str_Affection = "Affection";

	// Token: 0x040021B2 RID: 8626
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021B3 RID: 8627
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021B4 RID: 8628
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021B5 RID: 8629
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021B6 RID: 8630
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021B7 RID: 8631
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021B8 RID: 8632
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021B9 RID: 8633
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
