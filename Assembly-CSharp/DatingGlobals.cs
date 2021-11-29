using System;
using UnityEngine;

// Token: 0x020002EC RID: 748
public static class DatingGlobals
{
	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06001578 RID: 5496 RVA: 0x000D8818 File Offset: 0x000D6A18
	// (set) Token: 0x06001579 RID: 5497 RVA: 0x000D8848 File Offset: 0x000D6A48
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
	// (get) Token: 0x0600157A RID: 5498 RVA: 0x000D8878 File Offset: 0x000D6A78
	// (set) Token: 0x0600157B RID: 5499 RVA: 0x000D88A8 File Offset: 0x000D6AA8
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

	// Token: 0x0600157C RID: 5500 RVA: 0x000D88D8 File Offset: 0x000D6AD8
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x0600157D RID: 5501 RVA: 0x000D8910 File Offset: 0x000D6B10
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x0600157E RID: 5502 RVA: 0x000D896C File Offset: 0x000D6B6C
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x0600157F RID: 5503 RVA: 0x000D899C File Offset: 0x000D6B9C
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x06001580 RID: 5504 RVA: 0x000D89D4 File Offset: 0x000D6BD4
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x06001581 RID: 5505 RVA: 0x000D8A30 File Offset: 0x000D6C30
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x06001582 RID: 5506 RVA: 0x000D8A60 File Offset: 0x000D6C60
	// (set) Token: 0x06001583 RID: 5507 RVA: 0x000D8A90 File Offset: 0x000D6C90
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

	// Token: 0x06001584 RID: 5508 RVA: 0x000D8AC0 File Offset: 0x000D6CC0
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x06001585 RID: 5509 RVA: 0x000D8AF8 File Offset: 0x000D6CF8
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x06001586 RID: 5510 RVA: 0x000D8B54 File Offset: 0x000D6D54
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x06001587 RID: 5511 RVA: 0x000D8B84 File Offset: 0x000D6D84
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x000D8BBC File Offset: 0x000D6DBC
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x06001589 RID: 5513 RVA: 0x000D8C18 File Offset: 0x000D6E18
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x0600158A RID: 5514 RVA: 0x000D8C48 File Offset: 0x000D6E48
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x0600158B RID: 5515 RVA: 0x000D8C80 File Offset: 0x000D6E80
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x000D8CDC File Offset: 0x000D6EDC
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x0600158D RID: 5517 RVA: 0x000D8D0C File Offset: 0x000D6F0C
	// (set) Token: 0x0600158E RID: 5518 RVA: 0x000D8D3C File Offset: 0x000D6F3C
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

	// Token: 0x0600158F RID: 5519 RVA: 0x000D8D6C File Offset: 0x000D6F6C
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

	// Token: 0x04002187 RID: 8583
	private const string Str_Affection = "Affection";

	// Token: 0x04002188 RID: 8584
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x04002189 RID: 8585
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x0400218A RID: 8586
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x0400218B RID: 8587
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x0400218C RID: 8588
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x0400218D RID: 8589
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x0400218E RID: 8590
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x0400218F RID: 8591
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
