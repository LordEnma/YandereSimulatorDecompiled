using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class DatingGlobals
{
	// Token: 0x17000389 RID: 905
	// (get) Token: 0x060015A3 RID: 5539 RVA: 0x000DB3CC File Offset: 0x000D95CC
	// (set) Token: 0x060015A4 RID: 5540 RVA: 0x000DB3FC File Offset: 0x000D95FC
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
	// (get) Token: 0x060015A5 RID: 5541 RVA: 0x000DB42C File Offset: 0x000D962C
	// (set) Token: 0x060015A6 RID: 5542 RVA: 0x000DB45C File Offset: 0x000D965C
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

	// Token: 0x060015A7 RID: 5543 RVA: 0x000DB48C File Offset: 0x000D968C
	public static bool GetComplimentGiven(int complimentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + complimentID.ToString());
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x000DB4C4 File Offset: 0x000D96C4
	public static void SetComplimentGiven(int complimentID, bool value)
	{
		string text = complimentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_" + text, value);
	}

	// Token: 0x060015A9 RID: 5545 RVA: 0x000DB520 File Offset: 0x000D9720
	public static int[] KeysOfComplimentGiven()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_ComplimentGiven_");
	}

	// Token: 0x060015AA RID: 5546 RVA: 0x000DB550 File Offset: 0x000D9750
	public static bool GetSuitorCheck(int checkID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + checkID.ToString());
	}

	// Token: 0x060015AB RID: 5547 RVA: 0x000DB588 File Offset: 0x000D9788
	public static void SetSuitorCheck(int checkID, bool value)
	{
		string text = checkID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_" + text, value);
	}

	// Token: 0x060015AC RID: 5548 RVA: 0x000DB5E4 File Offset: 0x000D97E4
	public static int[] KeysOfSuitorCheck()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorCheck_");
	}

	// Token: 0x1700038B RID: 907
	// (get) Token: 0x060015AD RID: 5549 RVA: 0x000DB614 File Offset: 0x000D9814
	// (set) Token: 0x060015AE RID: 5550 RVA: 0x000DB644 File Offset: 0x000D9844
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

	// Token: 0x060015AF RID: 5551 RVA: 0x000DB674 File Offset: 0x000D9874
	public static int GetSuitorTrait(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + traitID.ToString());
	}

	// Token: 0x060015B0 RID: 5552 RVA: 0x000DB6AC File Offset: 0x000D98AC
	public static void SetSuitorTrait(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_" + text, value);
	}

	// Token: 0x060015B1 RID: 5553 RVA: 0x000DB708 File Offset: 0x000D9908
	public static int[] KeysOfSuitorTrait()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SuitorTrait_");
	}

	// Token: 0x060015B2 RID: 5554 RVA: 0x000DB738 File Offset: 0x000D9938
	public static bool GetTopicDiscussed(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + topicID.ToString());
	}

	// Token: 0x060015B3 RID: 5555 RVA: 0x000DB770 File Offset: 0x000D9970
	public static void SetTopicDiscussed(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_" + text, value);
	}

	// Token: 0x060015B4 RID: 5556 RVA: 0x000DB7CC File Offset: 0x000D99CC
	public static int[] KeysOfTopicDiscussed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscussed_");
	}

	// Token: 0x060015B5 RID: 5557 RVA: 0x000DB7FC File Offset: 0x000D99FC
	public static int GetTraitDemonstrated(int traitID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + traitID.ToString());
	}

	// Token: 0x060015B6 RID: 5558 RVA: 0x000DB834 File Offset: 0x000D9A34
	public static void SetTraitDemonstrated(int traitID, int value)
	{
		string text = traitID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_" + text, value);
	}

	// Token: 0x060015B7 RID: 5559 RVA: 0x000DB890 File Offset: 0x000D9A90
	public static int[] KeysOfTraitDemonstrated()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TraitDemonstrated_");
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x060015B8 RID: 5560 RVA: 0x000DB8C0 File Offset: 0x000D9AC0
	// (set) Token: 0x060015B9 RID: 5561 RVA: 0x000DB8F0 File Offset: 0x000D9AF0
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

	// Token: 0x060015BA RID: 5562 RVA: 0x000DB920 File Offset: 0x000D9B20
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

	// Token: 0x04002202 RID: 8706
	private const string Str_Affection = "Affection";

	// Token: 0x04002203 RID: 8707
	private const string Str_AffectionLevel = "AffectionLevel";

	// Token: 0x04002204 RID: 8708
	private const string Str_ComplimentGiven = "ComplimentGiven_";

	// Token: 0x04002205 RID: 8709
	private const string Str_SuitorCheck = "SuitorCheck_";

	// Token: 0x04002206 RID: 8710
	private const string Str_SuitorProgress = "SuitorProgress";

	// Token: 0x04002207 RID: 8711
	private const string Str_SuitorTrait = "SuitorTrait_";

	// Token: 0x04002208 RID: 8712
	private const string Str_TopicDiscussed = "TopicDiscussed_";

	// Token: 0x04002209 RID: 8713
	private const string Str_TraitDemonstrated = "TraitDemonstrated_";

	// Token: 0x0400220A RID: 8714
	private const string Str_RivalSabotaged = "RivalSabotaged";
}
