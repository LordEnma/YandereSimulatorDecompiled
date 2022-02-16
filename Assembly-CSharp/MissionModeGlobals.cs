using System;
using UnityEngine;

// Token: 0x020002F3 RID: 755
public static class MissionModeGlobals
{
	// Token: 0x0600161C RID: 5660 RVA: 0x000DBFCD File Offset: 0x000DA1CD
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x0600161D RID: 5661 RVA: 0x000DBFE8 File Offset: 0x000DA1E8
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x0600161E RID: 5662 RVA: 0x000DC019 File Offset: 0x000DA219
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x0600161F RID: 5663 RVA: 0x000DC025 File Offset: 0x000DA225
	// (set) Token: 0x06001620 RID: 5664 RVA: 0x000DC031 File Offset: 0x000DA231
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

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06001621 RID: 5665 RVA: 0x000DC03E File Offset: 0x000DA23E
	// (set) Token: 0x06001622 RID: 5666 RVA: 0x000DC04A File Offset: 0x000DA24A
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

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x06001623 RID: 5667 RVA: 0x000DC057 File Offset: 0x000DA257
	// (set) Token: 0x06001624 RID: 5668 RVA: 0x000DC063 File Offset: 0x000DA263
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

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x06001625 RID: 5669 RVA: 0x000DC070 File Offset: 0x000DA270
	// (set) Token: 0x06001626 RID: 5670 RVA: 0x000DC07C File Offset: 0x000DA27C
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

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06001627 RID: 5671 RVA: 0x000DC089 File Offset: 0x000DA289
	// (set) Token: 0x06001628 RID: 5672 RVA: 0x000DC095 File Offset: 0x000DA295
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

	// Token: 0x170003CA RID: 970
	// (get) Token: 0x06001629 RID: 5673 RVA: 0x000DC0A2 File Offset: 0x000DA2A2
	// (set) Token: 0x0600162A RID: 5674 RVA: 0x000DC0AE File Offset: 0x000DA2AE
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

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x0600162B RID: 5675 RVA: 0x000DC0BB File Offset: 0x000DA2BB
	// (set) Token: 0x0600162C RID: 5676 RVA: 0x000DC0C7 File Offset: 0x000DA2C7
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

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x0600162D RID: 5677 RVA: 0x000DC0D4 File Offset: 0x000DA2D4
	// (set) Token: 0x0600162E RID: 5678 RVA: 0x000DC0E0 File Offset: 0x000DA2E0
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

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x0600162F RID: 5679 RVA: 0x000DC0ED File Offset: 0x000DA2ED
	// (set) Token: 0x06001630 RID: 5680 RVA: 0x000DC0F9 File Offset: 0x000DA2F9
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

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x06001631 RID: 5681 RVA: 0x000DC106 File Offset: 0x000DA306
	// (set) Token: 0x06001632 RID: 5682 RVA: 0x000DC112 File Offset: 0x000DA312
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

	// Token: 0x06001633 RID: 5683 RVA: 0x000DC120 File Offset: 0x000DA320
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

	// Token: 0x04002202 RID: 8706
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002203 RID: 8707
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x04002204 RID: 8708
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x04002205 RID: 8709
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x04002206 RID: 8710
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x04002207 RID: 8711
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x04002208 RID: 8712
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x04002209 RID: 8713
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x0400220A RID: 8714
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x0400220B RID: 8715
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x0400220C RID: 8716
	private const string Str_MultiMission = "MultiMission";
}
