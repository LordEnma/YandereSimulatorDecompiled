using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class MissionModeGlobals
{
	// Token: 0x06001612 RID: 5650 RVA: 0x000DB7AD File Offset: 0x000D99AD
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001613 RID: 5651 RVA: 0x000DB7C8 File Offset: 0x000D99C8
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001614 RID: 5652 RVA: 0x000DB7F9 File Offset: 0x000D99F9
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001615 RID: 5653 RVA: 0x000DB805 File Offset: 0x000D9A05
	// (set) Token: 0x06001616 RID: 5654 RVA: 0x000DB811 File Offset: 0x000D9A11
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
	// (get) Token: 0x06001617 RID: 5655 RVA: 0x000DB81E File Offset: 0x000D9A1E
	// (set) Token: 0x06001618 RID: 5656 RVA: 0x000DB82A File Offset: 0x000D9A2A
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
	// (get) Token: 0x06001619 RID: 5657 RVA: 0x000DB837 File Offset: 0x000D9A37
	// (set) Token: 0x0600161A RID: 5658 RVA: 0x000DB843 File Offset: 0x000D9A43
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
	// (get) Token: 0x0600161B RID: 5659 RVA: 0x000DB850 File Offset: 0x000D9A50
	// (set) Token: 0x0600161C RID: 5660 RVA: 0x000DB85C File Offset: 0x000D9A5C
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
	// (get) Token: 0x0600161D RID: 5661 RVA: 0x000DB869 File Offset: 0x000D9A69
	// (set) Token: 0x0600161E RID: 5662 RVA: 0x000DB875 File Offset: 0x000D9A75
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
	// (get) Token: 0x0600161F RID: 5663 RVA: 0x000DB882 File Offset: 0x000D9A82
	// (set) Token: 0x06001620 RID: 5664 RVA: 0x000DB88E File Offset: 0x000D9A8E
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
	// (get) Token: 0x06001621 RID: 5665 RVA: 0x000DB89B File Offset: 0x000D9A9B
	// (set) Token: 0x06001622 RID: 5666 RVA: 0x000DB8A7 File Offset: 0x000D9AA7
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
	// (get) Token: 0x06001623 RID: 5667 RVA: 0x000DB8B4 File Offset: 0x000D9AB4
	// (set) Token: 0x06001624 RID: 5668 RVA: 0x000DB8C0 File Offset: 0x000D9AC0
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
	// (get) Token: 0x06001625 RID: 5669 RVA: 0x000DB8CD File Offset: 0x000D9ACD
	// (set) Token: 0x06001626 RID: 5670 RVA: 0x000DB8D9 File Offset: 0x000D9AD9
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
	// (get) Token: 0x06001627 RID: 5671 RVA: 0x000DB8E6 File Offset: 0x000D9AE6
	// (set) Token: 0x06001628 RID: 5672 RVA: 0x000DB8F2 File Offset: 0x000D9AF2
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

	// Token: 0x06001629 RID: 5673 RVA: 0x000DB900 File Offset: 0x000D9B00
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

	// Token: 0x040021F0 RID: 8688
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x040021F1 RID: 8689
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x040021F2 RID: 8690
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x040021F3 RID: 8691
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x040021F4 RID: 8692
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x040021F5 RID: 8693
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x040021F6 RID: 8694
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x040021F7 RID: 8695
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x040021F8 RID: 8696
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x040021F9 RID: 8697
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x040021FA RID: 8698
	private const string Str_MultiMission = "MultiMission";
}
