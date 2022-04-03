using System;
using UnityEngine;

// Token: 0x020002F5 RID: 757
public static class MissionModeGlobals
{
	// Token: 0x06001630 RID: 5680 RVA: 0x000DD58D File Offset: 0x000DB78D
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001631 RID: 5681 RVA: 0x000DD5A8 File Offset: 0x000DB7A8
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001632 RID: 5682 RVA: 0x000DD5D9 File Offset: 0x000DB7D9
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06001633 RID: 5683 RVA: 0x000DD5E5 File Offset: 0x000DB7E5
	// (set) Token: 0x06001634 RID: 5684 RVA: 0x000DD5F1 File Offset: 0x000DB7F1
	public static int MissionDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("MissionDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("MissionDifficulty", value);
		}
	}

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000DD5FE File Offset: 0x000DB7FE
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000DD60A File Offset: 0x000DB80A
	public static bool MissionMode
	{
		get
		{
			return GlobalsHelper.GetBool("MissionMode");
		}
		set
		{
			GlobalsHelper.SetBool("MissionMode", value);
		}
	}

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x06001637 RID: 5687 RVA: 0x000DD617 File Offset: 0x000DB817
	// (set) Token: 0x06001638 RID: 5688 RVA: 0x000DD623 File Offset: 0x000DB823
	public static bool MultiMission
	{
		get
		{
			return GlobalsHelper.GetBool("MultiMission");
		}
		set
		{
			GlobalsHelper.SetBool("MultiMission", value);
		}
	}

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000DD630 File Offset: 0x000DB830
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000DD63C File Offset: 0x000DB83C
	public static int MissionRequiredClothing
	{
		get
		{
			return PlayerPrefs.GetInt("MissionRequiredClothing");
		}
		set
		{
			PlayerPrefs.SetInt("MissionRequiredClothing", value);
		}
	}

	// Token: 0x170003CA RID: 970
	// (get) Token: 0x0600163B RID: 5691 RVA: 0x000DD649 File Offset: 0x000DB849
	// (set) Token: 0x0600163C RID: 5692 RVA: 0x000DD655 File Offset: 0x000DB855
	public static int MissionRequiredDisposal
	{
		get
		{
			return PlayerPrefs.GetInt("MissionRequiredDisposal");
		}
		set
		{
			PlayerPrefs.SetInt("MissionRequiredDisposal", value);
		}
	}

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x0600163D RID: 5693 RVA: 0x000DD662 File Offset: 0x000DB862
	// (set) Token: 0x0600163E RID: 5694 RVA: 0x000DD66E File Offset: 0x000DB86E
	public static int MissionRequiredWeapon
	{
		get
		{
			return PlayerPrefs.GetInt("MissionRequiredWeapon");
		}
		set
		{
			PlayerPrefs.SetInt("MissionRequiredWeapon", value);
		}
	}

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x0600163F RID: 5695 RVA: 0x000DD67B File Offset: 0x000DB87B
	// (set) Token: 0x06001640 RID: 5696 RVA: 0x000DD687 File Offset: 0x000DB887
	public static int MissionTarget
	{
		get
		{
			return PlayerPrefs.GetInt("MissionTarget");
		}
		set
		{
			PlayerPrefs.SetInt("MissionTarget", value);
		}
	}

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x06001641 RID: 5697 RVA: 0x000DD694 File Offset: 0x000DB894
	// (set) Token: 0x06001642 RID: 5698 RVA: 0x000DD6A0 File Offset: 0x000DB8A0
	public static string MissionTargetName
	{
		get
		{
			return PlayerPrefs.GetString("MissionTargetName");
		}
		set
		{
			PlayerPrefs.SetString("MissionTargetName", value);
		}
	}

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x06001643 RID: 5699 RVA: 0x000DD6AD File Offset: 0x000DB8AD
	// (set) Token: 0x06001644 RID: 5700 RVA: 0x000DD6B9 File Offset: 0x000DB8B9
	public static int NemesisDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("NemesisDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("NemesisDifficulty", value);
		}
	}

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x06001645 RID: 5701 RVA: 0x000DD6C6 File Offset: 0x000DB8C6
	// (set) Token: 0x06001646 RID: 5702 RVA: 0x000DD6D2 File Offset: 0x000DB8D2
	public static bool NemesisAggression
	{
		get
		{
			return GlobalsHelper.GetBool("NemesisAggression");
		}
		set
		{
			GlobalsHelper.SetBool("NemesisAggression", value);
		}
	}

	// Token: 0x06001647 RID: 5703 RVA: 0x000DD6E0 File Offset: 0x000DB8E0
	public static void DeleteAll()
	{
		Globals.DeleteCollection("MissionCondition_", MissionModeGlobals.KeysOfMissionCondition());
		Globals.Delete("MissionDifficulty");
		Globals.Delete("MissionMode");
		Globals.Delete("MissionRequiredClothing");
		Globals.Delete("MissionRequiredDisposal");
		Globals.Delete("MissionRequiredWeapon");
		Globals.Delete("MissionTarget");
		Globals.Delete("MissionTargetName");
		Globals.Delete("NemesisDifficulty");
		Globals.Delete("NemesisAggression");
		Globals.Delete("MultiMission");
	}

	// Token: 0x04002244 RID: 8772
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002245 RID: 8773
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x04002246 RID: 8774
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x04002247 RID: 8775
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x04002248 RID: 8776
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x04002249 RID: 8777
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x0400224A RID: 8778
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x0400224B RID: 8779
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x0400224C RID: 8780
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x0400224D RID: 8781
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x0400224E RID: 8782
	private const string Str_MultiMission = "MultiMission";
}
