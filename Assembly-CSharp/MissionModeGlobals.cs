using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class MissionModeGlobals
{
	// Token: 0x06001612 RID: 5650 RVA: 0x000DB899 File Offset: 0x000D9A99
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001613 RID: 5651 RVA: 0x000DB8B4 File Offset: 0x000D9AB4
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001614 RID: 5652 RVA: 0x000DB8E5 File Offset: 0x000D9AE5
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001615 RID: 5653 RVA: 0x000DB8F1 File Offset: 0x000D9AF1
	// (set) Token: 0x06001616 RID: 5654 RVA: 0x000DB8FD File Offset: 0x000D9AFD
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
	// (get) Token: 0x06001617 RID: 5655 RVA: 0x000DB90A File Offset: 0x000D9B0A
	// (set) Token: 0x06001618 RID: 5656 RVA: 0x000DB916 File Offset: 0x000D9B16
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
	// (get) Token: 0x06001619 RID: 5657 RVA: 0x000DB923 File Offset: 0x000D9B23
	// (set) Token: 0x0600161A RID: 5658 RVA: 0x000DB92F File Offset: 0x000D9B2F
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
	// (get) Token: 0x0600161B RID: 5659 RVA: 0x000DB93C File Offset: 0x000D9B3C
	// (set) Token: 0x0600161C RID: 5660 RVA: 0x000DB948 File Offset: 0x000D9B48
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
	// (get) Token: 0x0600161D RID: 5661 RVA: 0x000DB955 File Offset: 0x000D9B55
	// (set) Token: 0x0600161E RID: 5662 RVA: 0x000DB961 File Offset: 0x000D9B61
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
	// (get) Token: 0x0600161F RID: 5663 RVA: 0x000DB96E File Offset: 0x000D9B6E
	// (set) Token: 0x06001620 RID: 5664 RVA: 0x000DB97A File Offset: 0x000D9B7A
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
	// (get) Token: 0x06001621 RID: 5665 RVA: 0x000DB987 File Offset: 0x000D9B87
	// (set) Token: 0x06001622 RID: 5666 RVA: 0x000DB993 File Offset: 0x000D9B93
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
	// (get) Token: 0x06001623 RID: 5667 RVA: 0x000DB9A0 File Offset: 0x000D9BA0
	// (set) Token: 0x06001624 RID: 5668 RVA: 0x000DB9AC File Offset: 0x000D9BAC
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
	// (get) Token: 0x06001625 RID: 5669 RVA: 0x000DB9B9 File Offset: 0x000D9BB9
	// (set) Token: 0x06001626 RID: 5670 RVA: 0x000DB9C5 File Offset: 0x000D9BC5
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
	// (get) Token: 0x06001627 RID: 5671 RVA: 0x000DB9D2 File Offset: 0x000D9BD2
	// (set) Token: 0x06001628 RID: 5672 RVA: 0x000DB9DE File Offset: 0x000D9BDE
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

	// Token: 0x06001629 RID: 5673 RVA: 0x000DB9EC File Offset: 0x000D9BEC
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

	// Token: 0x040021F3 RID: 8691
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x040021F4 RID: 8692
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x040021F5 RID: 8693
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x040021F6 RID: 8694
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x040021F7 RID: 8695
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x040021F8 RID: 8696
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x040021F9 RID: 8697
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x040021FA RID: 8698
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x040021FB RID: 8699
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x040021FC RID: 8700
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x040021FD RID: 8701
	private const string Str_MultiMission = "MultiMission";
}
