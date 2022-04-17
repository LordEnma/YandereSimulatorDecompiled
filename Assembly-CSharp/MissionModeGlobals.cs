using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class MissionModeGlobals
{
	// Token: 0x06001638 RID: 5688 RVA: 0x000DD885 File Offset: 0x000DBA85
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001639 RID: 5689 RVA: 0x000DD8A0 File Offset: 0x000DBAA0
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x0600163A RID: 5690 RVA: 0x000DD8D1 File Offset: 0x000DBAD1
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x0600163B RID: 5691 RVA: 0x000DD8DD File Offset: 0x000DBADD
	// (set) Token: 0x0600163C RID: 5692 RVA: 0x000DD8E9 File Offset: 0x000DBAE9
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
	// (get) Token: 0x0600163D RID: 5693 RVA: 0x000DD8F6 File Offset: 0x000DBAF6
	// (set) Token: 0x0600163E RID: 5694 RVA: 0x000DD902 File Offset: 0x000DBB02
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
	// (get) Token: 0x0600163F RID: 5695 RVA: 0x000DD90F File Offset: 0x000DBB0F
	// (set) Token: 0x06001640 RID: 5696 RVA: 0x000DD91B File Offset: 0x000DBB1B
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
	// (get) Token: 0x06001641 RID: 5697 RVA: 0x000DD928 File Offset: 0x000DBB28
	// (set) Token: 0x06001642 RID: 5698 RVA: 0x000DD934 File Offset: 0x000DBB34
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
	// (get) Token: 0x06001643 RID: 5699 RVA: 0x000DD941 File Offset: 0x000DBB41
	// (set) Token: 0x06001644 RID: 5700 RVA: 0x000DD94D File Offset: 0x000DBB4D
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
	// (get) Token: 0x06001645 RID: 5701 RVA: 0x000DD95A File Offset: 0x000DBB5A
	// (set) Token: 0x06001646 RID: 5702 RVA: 0x000DD966 File Offset: 0x000DBB66
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
	// (get) Token: 0x06001647 RID: 5703 RVA: 0x000DD973 File Offset: 0x000DBB73
	// (set) Token: 0x06001648 RID: 5704 RVA: 0x000DD97F File Offset: 0x000DBB7F
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
	// (get) Token: 0x06001649 RID: 5705 RVA: 0x000DD98C File Offset: 0x000DBB8C
	// (set) Token: 0x0600164A RID: 5706 RVA: 0x000DD998 File Offset: 0x000DBB98
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
	// (get) Token: 0x0600164B RID: 5707 RVA: 0x000DD9A5 File Offset: 0x000DBBA5
	// (set) Token: 0x0600164C RID: 5708 RVA: 0x000DD9B1 File Offset: 0x000DBBB1
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
	// (get) Token: 0x0600164D RID: 5709 RVA: 0x000DD9BE File Offset: 0x000DBBBE
	// (set) Token: 0x0600164E RID: 5710 RVA: 0x000DD9CA File Offset: 0x000DBBCA
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

	// Token: 0x0600164F RID: 5711 RVA: 0x000DD9D8 File Offset: 0x000DBBD8
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

	// Token: 0x04002248 RID: 8776
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002249 RID: 8777
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x0400224A RID: 8778
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x0400224B RID: 8779
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x0400224C RID: 8780
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x0400224D RID: 8781
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x0400224E RID: 8782
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x0400224F RID: 8783
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x04002250 RID: 8784
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x04002251 RID: 8785
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x04002252 RID: 8786
	private const string Str_MultiMission = "MultiMission";
}
