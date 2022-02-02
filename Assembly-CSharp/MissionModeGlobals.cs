using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class MissionModeGlobals
{
	// Token: 0x06001613 RID: 5651 RVA: 0x000DBCB5 File Offset: 0x000D9EB5
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001614 RID: 5652 RVA: 0x000DBCD0 File Offset: 0x000D9ED0
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001615 RID: 5653 RVA: 0x000DBD01 File Offset: 0x000D9F01
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001616 RID: 5654 RVA: 0x000DBD0D File Offset: 0x000D9F0D
	// (set) Token: 0x06001617 RID: 5655 RVA: 0x000DBD19 File Offset: 0x000D9F19
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

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x06001618 RID: 5656 RVA: 0x000DBD26 File Offset: 0x000D9F26
	// (set) Token: 0x06001619 RID: 5657 RVA: 0x000DBD32 File Offset: 0x000D9F32
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

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x0600161A RID: 5658 RVA: 0x000DBD3F File Offset: 0x000D9F3F
	// (set) Token: 0x0600161B RID: 5659 RVA: 0x000DBD4B File Offset: 0x000D9F4B
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

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x0600161C RID: 5660 RVA: 0x000DBD58 File Offset: 0x000D9F58
	// (set) Token: 0x0600161D RID: 5661 RVA: 0x000DBD64 File Offset: 0x000D9F64
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

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x0600161E RID: 5662 RVA: 0x000DBD71 File Offset: 0x000D9F71
	// (set) Token: 0x0600161F RID: 5663 RVA: 0x000DBD7D File Offset: 0x000D9F7D
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

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x06001620 RID: 5664 RVA: 0x000DBD8A File Offset: 0x000D9F8A
	// (set) Token: 0x06001621 RID: 5665 RVA: 0x000DBD96 File Offset: 0x000D9F96
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

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06001622 RID: 5666 RVA: 0x000DBDA3 File Offset: 0x000D9FA3
	// (set) Token: 0x06001623 RID: 5667 RVA: 0x000DBDAF File Offset: 0x000D9FAF
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

	// Token: 0x170003CA RID: 970
	// (get) Token: 0x06001624 RID: 5668 RVA: 0x000DBDBC File Offset: 0x000D9FBC
	// (set) Token: 0x06001625 RID: 5669 RVA: 0x000DBDC8 File Offset: 0x000D9FC8
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

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x06001626 RID: 5670 RVA: 0x000DBDD5 File Offset: 0x000D9FD5
	// (set) Token: 0x06001627 RID: 5671 RVA: 0x000DBDE1 File Offset: 0x000D9FE1
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

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DBDEE File Offset: 0x000D9FEE
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DBDFA File Offset: 0x000D9FFA
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

	// Token: 0x0600162A RID: 5674 RVA: 0x000DBE08 File Offset: 0x000DA008
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

	// Token: 0x040021F8 RID: 8696
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x040021F9 RID: 8697
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x040021FA RID: 8698
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x040021FB RID: 8699
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x040021FC RID: 8700
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x040021FD RID: 8701
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x040021FE RID: 8702
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x040021FF RID: 8703
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x04002200 RID: 8704
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x04002201 RID: 8705
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x04002202 RID: 8706
	private const string Str_MultiMission = "MultiMission";
}
