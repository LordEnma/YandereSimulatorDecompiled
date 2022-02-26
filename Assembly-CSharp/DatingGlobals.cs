using System;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x06001594 RID: 5524 RVA: 0x000DA61C File Offset: 0x000D881C
	// (set) Token: 0x06001595 RID: 5525 RVA: 0x000DA64C File Offset: 0x000D884C
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
	// (get) Token: 0x06001596 RID: 5526 RVA: 0x000DA67C File Offset: 0x000D887C
	// (set) Token: 0x06001597 RID: 5527 RVA: 0x000DA6AC File Offset: 0x000D88AC
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

	// Token: 0x06001598 RID: 5528 RVA: 0x000DA6DC File Offset: 0x000D88DC
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x000DA714 File Offset: 0x000D8914
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x0600159A RID: 5530 RVA: 0x000DA770 File Offset: 0x000D8970
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x000DA7A0 File Offset: 0x000D89A0
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x000DA7D8 File Offset: 0x000D89D8
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x000DA834 File Offset: 0x000D8A34
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DA864 File Offset: 0x000D8A64
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DA894 File Offset: 0x000D8A94
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

	// Token: 0x060015A0 RID: 5536 RVA: 0x000DA8C4 File Offset: 0x000D8AC4
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x060015A1 RID: 5537 RVA: 0x000DA8FC File Offset: 0x000D8AFC
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x060015A2 RID: 5538 RVA: 0x000DA958 File Offset: 0x000D8B58
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x060015A3 RID: 5539 RVA: 0x000DA988 File Offset: 0x000D8B88
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x060015A4 RID: 5540 RVA: 0x000DA9C0 File Offset: 0x000D8BC0
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x000DAA1C File Offset: 0x000D8C1C
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x060015A6 RID: 5542 RVA: 0x000DAA4C File Offset: 0x000D8C4C
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x000DAA84 File Offset: 0x000D8C84
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x000DAAE0 File Offset: 0x000D8CE0
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000DAB10 File Offset: 0x000D8D10
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000DAB40 File Offset: 0x000D8D40
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

	// Token: 0x060015AB RID: 5547 RVA: 0x000DAB70 File Offset: 0x000D8D70
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

	// Token: 0x040021CE RID: 8654
	private const string Str_Affection = "Affection";

	// Token: 0x040021CF RID: 8655
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x040021D0 RID: 8656
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x040021D1 RID: 8657
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x040021D2 RID: 8658
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x040021D3 RID: 8659
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x040021D4 RID: 8660
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x040021D5 RID: 8661
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x040021D6 RID: 8662
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
