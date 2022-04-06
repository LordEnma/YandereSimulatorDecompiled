using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class MissionModeGlobals
{
	// Token: 0x06001636 RID: 5686 RVA: 0x000DD69D File Offset: 0x000DB89D
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001637 RID: 5687 RVA: 0x000DD6B8 File Offset: 0x000DB8B8
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001638 RID: 5688 RVA: 0x000DD6E9 File Offset: 0x000DB8E9
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000DD6F5 File Offset: 0x000DB8F5
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000DD701 File Offset: 0x000DB901
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
	// (get) Token: 0x0600163B RID: 5691 RVA: 0x000DD70E File Offset: 0x000DB90E
	// (set) Token: 0x0600163C RID: 5692 RVA: 0x000DD71A File Offset: 0x000DB91A
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
	// (get) Token: 0x0600163D RID: 5693 RVA: 0x000DD727 File Offset: 0x000DB927
	// (set) Token: 0x0600163E RID: 5694 RVA: 0x000DD733 File Offset: 0x000DB933
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
	// (get) Token: 0x0600163F RID: 5695 RVA: 0x000DD740 File Offset: 0x000DB940
	// (set) Token: 0x06001640 RID: 5696 RVA: 0x000DD74C File Offset: 0x000DB94C
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
	// (get) Token: 0x06001641 RID: 5697 RVA: 0x000DD759 File Offset: 0x000DB959
	// (set) Token: 0x06001642 RID: 5698 RVA: 0x000DD765 File Offset: 0x000DB965
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
	// (get) Token: 0x06001643 RID: 5699 RVA: 0x000DD772 File Offset: 0x000DB972
	// (set) Token: 0x06001644 RID: 5700 RVA: 0x000DD77E File Offset: 0x000DB97E
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
	// (get) Token: 0x06001645 RID: 5701 RVA: 0x000DD78B File Offset: 0x000DB98B
	// (set) Token: 0x06001646 RID: 5702 RVA: 0x000DD797 File Offset: 0x000DB997
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
	// (get) Token: 0x06001647 RID: 5703 RVA: 0x000DD7A4 File Offset: 0x000DB9A4
	// (set) Token: 0x06001648 RID: 5704 RVA: 0x000DD7B0 File Offset: 0x000DB9B0
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
	// (get) Token: 0x06001649 RID: 5705 RVA: 0x000DD7BD File Offset: 0x000DB9BD
	// (set) Token: 0x0600164A RID: 5706 RVA: 0x000DD7C9 File Offset: 0x000DB9C9
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
	// (get) Token: 0x0600164B RID: 5707 RVA: 0x000DD7D6 File Offset: 0x000DB9D6
	// (set) Token: 0x0600164C RID: 5708 RVA: 0x000DD7E2 File Offset: 0x000DB9E2
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

	// Token: 0x0600164D RID: 5709 RVA: 0x000DD7F0 File Offset: 0x000DB9F0
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

	// Token: 0x04002246 RID: 8774
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002247 RID: 8775
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x04002248 RID: 8776
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x04002249 RID: 8777
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x0400224A RID: 8778
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x0400224B RID: 8779
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x0400224C RID: 8780
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x0400224D RID: 8781
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x0400224E RID: 8782
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x0400224F RID: 8783
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x04002250 RID: 8784
	private const string Str_MultiMission = "MultiMission";
}
