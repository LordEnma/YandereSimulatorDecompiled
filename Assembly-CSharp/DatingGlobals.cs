using System;
using UnityEngine;

// Token: 0x020002ED RID: 749
public static class DatingGlobals
{
	// Token: 0x17000388 RID: 904
	// (get) Token: 0x0600157F RID: 5503 RVA: 0x000D9228 File Offset: 0x000D7428
	// (set) Token: 0x06001580 RID: 5504 RVA: 0x000D9258 File Offset: 0x000D7458
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
	// (get) Token: 0x06001581 RID: 5505 RVA: 0x000D9288 File Offset: 0x000D7488
	// (set) Token: 0x06001582 RID: 5506 RVA: 0x000D92B8 File Offset: 0x000D74B8
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

	// Token: 0x06001583 RID: 5507 RVA: 0x000D92E8 File Offset: 0x000D74E8
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x06001584 RID: 5508 RVA: 0x000D9320 File Offset: 0x000D7520
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x06001585 RID: 5509 RVA: 0x000D937C File Offset: 0x000D757C
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x06001586 RID: 5510 RVA: 0x000D93AC File Offset: 0x000D75AC
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x06001587 RID: 5511 RVA: 0x000D93E4 File Offset: 0x000D75E4
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x000D9440 File Offset: 0x000D7640
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038A RID: 906
	// (get) Token: 0x06001589 RID: 5513 RVA: 0x000D9470 File Offset: 0x000D7670
	// (set) Token: 0x0600158A RID: 5514 RVA: 0x000D94A0 File Offset: 0x000D76A0
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

	// Token: 0x0600158B RID: 5515 RVA: 0x000D94D0 File Offset: 0x000D76D0
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x000D9508 File Offset: 0x000D7708
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x0600158D RID: 5517 RVA: 0x000D9564 File Offset: 0x000D7764
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x0600158E RID: 5518 RVA: 0x000D9594 File Offset: 0x000D7794
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x0600158F RID: 5519 RVA: 0x000D95CC File Offset: 0x000D77CC
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x06001590 RID: 5520 RVA: 0x000D9628 File Offset: 0x000D7828
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x000D9658 File Offset: 0x000D7858
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x06001592 RID: 5522 RVA: 0x000D9690 File Offset: 0x000D7890
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x000D96EC File Offset: 0x000D78EC
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06001594 RID: 5524 RVA: 0x000D971C File Offset: 0x000D791C
	// (set) Token: 0x06001595 RID: 5525 RVA: 0x000D974C File Offset: 0x000D794C
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

	// Token: 0x06001596 RID: 5526 RVA: 0x000D977C File Offset: 0x000D797C
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

	// Token: 0x040021AA RID: 8618
	private const string Str_Affection = "Affection";

	// Token: 0x040021AB RID: 8619
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021AC RID: 8620
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021AD RID: 8621
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021AE RID: 8622
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021AF RID: 8623
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021B0 RID: 8624
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021B1 RID: 8625
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021B2 RID: 8626
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
