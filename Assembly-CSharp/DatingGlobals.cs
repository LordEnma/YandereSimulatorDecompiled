using System;
using UnityEngine;

// Token: 0x020002EE RID: 750
public static class DatingGlobals
{
	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06001583 RID: 5507 RVA: 0x000D9550 File Offset: 0x000D7750
	// (set) Token: 0x06001584 RID: 5508 RVA: 0x000D9580 File Offset: 0x000D7780
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
	// (get) Token: 0x06001585 RID: 5509 RVA: 0x000D95B0 File Offset: 0x000D77B0
	// (set) Token: 0x06001586 RID: 5510 RVA: 0x000D95E0 File Offset: 0x000D77E0
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

	// Token: 0x06001587 RID: 5511 RVA: 0x000D9610 File Offset: 0x000D7810
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x000D9648 File Offset: 0x000D7848
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x06001589 RID: 5513 RVA: 0x000D96A4 File Offset: 0x000D78A4
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x0600158A RID: 5514 RVA: 0x000D96D4 File Offset: 0x000D78D4
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x0600158B RID: 5515 RVA: 0x000D970C File Offset: 0x000D790C
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x000D9768 File Offset: 0x000D7968
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x0600158D RID: 5517 RVA: 0x000D9798 File Offset: 0x000D7998
	// (set) Token: 0x0600158E RID: 5518 RVA: 0x000D97C8 File Offset: 0x000D79C8
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

	// Token: 0x0600158F RID: 5519 RVA: 0x000D97F8 File Offset: 0x000D79F8
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x06001590 RID: 5520 RVA: 0x000D9830 File Offset: 0x000D7A30
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x000D988C File Offset: 0x000D7A8C
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x06001592 RID: 5522 RVA: 0x000D98BC File Offset: 0x000D7ABC
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x000D98F4 File Offset: 0x000D7AF4
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x06001594 RID: 5524 RVA: 0x000D9950 File Offset: 0x000D7B50
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x06001595 RID: 5525 RVA: 0x000D9980 File Offset: 0x000D7B80
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x06001596 RID: 5526 RVA: 0x000D99B8 File Offset: 0x000D7BB8
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x06001597 RID: 5527 RVA: 0x000D9A14 File Offset: 0x000D7C14
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06001598 RID: 5528 RVA: 0x000D9A44 File Offset: 0x000D7C44
	// (set) Token: 0x06001599 RID: 5529 RVA: 0x000D9A74 File Offset: 0x000D7C74
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

	// Token: 0x0600159A RID: 5530 RVA: 0x000D9AA4 File Offset: 0x000D7CA4
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

	// Token: 0x040021AE RID: 8622
	private const string Str_Affection = "Affection";

	// Token: 0x040021AF RID: 8623
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021B0 RID: 8624
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021B1 RID: 8625
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021B2 RID: 8626
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021B3 RID: 8627
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021B4 RID: 8628
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021B5 RID: 8629
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021B6 RID: 8630
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
