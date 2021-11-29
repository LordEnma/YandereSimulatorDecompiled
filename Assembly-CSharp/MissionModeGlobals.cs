using System;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public static class MissionModeGlobals
{
	// Token: 0x06001607 RID: 5639 RVA: 0x000DAA75 File Offset: 0x000D8C75
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001608 RID: 5640 RVA: 0x000DAA90 File Offset: 0x000D8C90
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001609 RID: 5641 RVA: 0x000DAAC1 File Offset: 0x000D8CC1
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x0600160A RID: 5642 RVA: 0x000DAACD File Offset: 0x000D8CCD
	// (set) Token: 0x0600160B RID: 5643 RVA: 0x000DAAD9 File Offset: 0x000D8CD9
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
	// (get) Token: 0x0600160C RID: 5644 RVA: 0x000DAAE6 File Offset: 0x000D8CE6
	// (set) Token: 0x0600160D RID: 5645 RVA: 0x000DAAF2 File Offset: 0x000D8CF2
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
	// (get) Token: 0x0600160E RID: 5646 RVA: 0x000DAAFF File Offset: 0x000D8CFF
	// (set) Token: 0x0600160F RID: 5647 RVA: 0x000DAB0B File Offset: 0x000D8D0B
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
	// (get) Token: 0x06001610 RID: 5648 RVA: 0x000DAB18 File Offset: 0x000D8D18
	// (set) Token: 0x06001611 RID: 5649 RVA: 0x000DAB24 File Offset: 0x000D8D24
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
	// (get) Token: 0x06001612 RID: 5650 RVA: 0x000DAB31 File Offset: 0x000D8D31
	// (set) Token: 0x06001613 RID: 5651 RVA: 0x000DAB3D File Offset: 0x000D8D3D
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
	// (get) Token: 0x06001614 RID: 5652 RVA: 0x000DAB4A File Offset: 0x000D8D4A
	// (set) Token: 0x06001615 RID: 5653 RVA: 0x000DAB56 File Offset: 0x000D8D56
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
	// (get) Token: 0x06001616 RID: 5654 RVA: 0x000DAB63 File Offset: 0x000D8D63
	// (set) Token: 0x06001617 RID: 5655 RVA: 0x000DAB6F File Offset: 0x000D8D6F
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
	// (get) Token: 0x06001618 RID: 5656 RVA: 0x000DAB7C File Offset: 0x000D8D7C
	// (set) Token: 0x06001619 RID: 5657 RVA: 0x000DAB88 File Offset: 0x000D8D88
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
	// (get) Token: 0x0600161A RID: 5658 RVA: 0x000DAB95 File Offset: 0x000D8D95
	// (set) Token: 0x0600161B RID: 5659 RVA: 0x000DABA1 File Offset: 0x000D8DA1
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
	// (get) Token: 0x0600161C RID: 5660 RVA: 0x000DABAE File Offset: 0x000D8DAE
	// (set) Token: 0x0600161D RID: 5661 RVA: 0x000DABBA File Offset: 0x000D8DBA
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

	// Token: 0x0600161E RID: 5662 RVA: 0x000DABC8 File Offset: 0x000D8DC8
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

	// Token: 0x040021C9 RID: 8649
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x040021CA RID: 8650
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x040021CB RID: 8651
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x040021CC RID: 8652
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x040021CD RID: 8653
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x040021CE RID: 8654
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x040021CF RID: 8655
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x040021D0 RID: 8656
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x040021D1 RID: 8657
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x040021D2 RID: 8658
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x040021D3 RID: 8659
	private const string Str_MultiMission = "MultiMission";
}
