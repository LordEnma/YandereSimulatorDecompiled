using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class MissionModeGlobals
{
	// Token: 0x06001625 RID: 5669 RVA: 0x000DCBE1 File Offset: 0x000DADE1
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001626 RID: 5670 RVA: 0x000DCBFC File Offset: 0x000DADFC
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001627 RID: 5671 RVA: 0x000DCC2D File Offset: 0x000DAE2D
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DCC39 File Offset: 0x000DAE39
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DCC45 File Offset: 0x000DAE45
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
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DCC52 File Offset: 0x000DAE52
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DCC5E File Offset: 0x000DAE5E
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
	// (get) Token: 0x0600162C RID: 5676 RVA: 0x000DCC6B File Offset: 0x000DAE6B
	// (set) Token: 0x0600162D RID: 5677 RVA: 0x000DCC77 File Offset: 0x000DAE77
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
	// (get) Token: 0x0600162E RID: 5678 RVA: 0x000DCC84 File Offset: 0x000DAE84
	// (set) Token: 0x0600162F RID: 5679 RVA: 0x000DCC90 File Offset: 0x000DAE90
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
	// (get) Token: 0x06001630 RID: 5680 RVA: 0x000DCC9D File Offset: 0x000DAE9D
	// (set) Token: 0x06001631 RID: 5681 RVA: 0x000DCCA9 File Offset: 0x000DAEA9
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
	// (get) Token: 0x06001632 RID: 5682 RVA: 0x000DCCB6 File Offset: 0x000DAEB6
	// (set) Token: 0x06001633 RID: 5683 RVA: 0x000DCCC2 File Offset: 0x000DAEC2
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
	// (get) Token: 0x06001634 RID: 5684 RVA: 0x000DCCCF File Offset: 0x000DAECF
	// (set) Token: 0x06001635 RID: 5685 RVA: 0x000DCCDB File Offset: 0x000DAEDB
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
	// (get) Token: 0x06001636 RID: 5686 RVA: 0x000DCCE8 File Offset: 0x000DAEE8
	// (set) Token: 0x06001637 RID: 5687 RVA: 0x000DCCF4 File Offset: 0x000DAEF4
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
	// (get) Token: 0x06001638 RID: 5688 RVA: 0x000DCD01 File Offset: 0x000DAF01
	// (set) Token: 0x06001639 RID: 5689 RVA: 0x000DCD0D File Offset: 0x000DAF0D
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
	// (get) Token: 0x0600163A RID: 5690 RVA: 0x000DCD1A File Offset: 0x000DAF1A
	// (set) Token: 0x0600163B RID: 5691 RVA: 0x000DCD26 File Offset: 0x000DAF26
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

	// Token: 0x0600163C RID: 5692 RVA: 0x000DCD34 File Offset: 0x000DAF34
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

	// Token: 0x04002225 RID: 8741
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002226 RID: 8742
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x04002227 RID: 8743
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x04002228 RID: 8744
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x04002229 RID: 8745
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x0400222A RID: 8746
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x0400222B RID: 8747
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x0400222C RID: 8748
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x0400222D RID: 8749
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x0400222E RID: 8750
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x0400222F RID: 8751
	private const string Str_MultiMission = "MultiMission";
}
