using System;
using UnityEngine;

// Token: 0x020002F2 RID: 754
public static class MissionModeGlobals
{
	// Token: 0x06001615 RID: 5653 RVA: 0x000DBE59 File Offset: 0x000DA059
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001616 RID: 5654 RVA: 0x000DBE74 File Offset: 0x000DA074
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001617 RID: 5655 RVA: 0x000DBEA5 File Offset: 0x000DA0A5
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x06001618 RID: 5656 RVA: 0x000DBEB1 File Offset: 0x000DA0B1
	// (set) Token: 0x06001619 RID: 5657 RVA: 0x000DBEBD File Offset: 0x000DA0BD
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

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x0600161A RID: 5658 RVA: 0x000DBECA File Offset: 0x000DA0CA
	// (set) Token: 0x0600161B RID: 5659 RVA: 0x000DBED6 File Offset: 0x000DA0D6
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

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x0600161C RID: 5660 RVA: 0x000DBEE3 File Offset: 0x000DA0E3
	// (set) Token: 0x0600161D RID: 5661 RVA: 0x000DBEEF File Offset: 0x000DA0EF
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

	// Token: 0x170003C7 RID: 967
	// (get) Token: 0x0600161E RID: 5662 RVA: 0x000DBEFC File Offset: 0x000DA0FC
	// (set) Token: 0x0600161F RID: 5663 RVA: 0x000DBF08 File Offset: 0x000DA108
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

	// Token: 0x170003C8 RID: 968
	// (get) Token: 0x06001620 RID: 5664 RVA: 0x000DBF15 File Offset: 0x000DA115
	// (set) Token: 0x06001621 RID: 5665 RVA: 0x000DBF21 File Offset: 0x000DA121
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

	// Token: 0x170003C9 RID: 969
	// (get) Token: 0x06001622 RID: 5666 RVA: 0x000DBF2E File Offset: 0x000DA12E
	// (set) Token: 0x06001623 RID: 5667 RVA: 0x000DBF3A File Offset: 0x000DA13A
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

	// Token: 0x170003CA RID: 970
	// (get) Token: 0x06001624 RID: 5668 RVA: 0x000DBF47 File Offset: 0x000DA147
	// (set) Token: 0x06001625 RID: 5669 RVA: 0x000DBF53 File Offset: 0x000DA153
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

	// Token: 0x170003CB RID: 971
	// (get) Token: 0x06001626 RID: 5670 RVA: 0x000DBF60 File Offset: 0x000DA160
	// (set) Token: 0x06001627 RID: 5671 RVA: 0x000DBF6C File Offset: 0x000DA16C
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

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DBF79 File Offset: 0x000DA179
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DBF85 File Offset: 0x000DA185
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

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DBF92 File Offset: 0x000DA192
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DBF9E File Offset: 0x000DA19E
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

	// Token: 0x0600162C RID: 5676 RVA: 0x000DBFAC File Offset: 0x000DA1AC
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

	// Token: 0x040021FC RID: 8700
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x040021FD RID: 8701
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x040021FE RID: 8702
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x040021FF RID: 8703
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x04002200 RID: 8704
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x04002201 RID: 8705
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x04002202 RID: 8706
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x04002203 RID: 8707
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x04002204 RID: 8708
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x04002205 RID: 8709
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x04002206 RID: 8710
	private const string Str_MultiMission = "MultiMission";
}
