using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class MissionModeGlobals
{
	// Token: 0x06001625 RID: 5669 RVA: 0x000DC8B1 File Offset: 0x000DAAB1
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x06001626 RID: 5670 RVA: 0x000DC8CC File Offset: 0x000DAACC
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001627 RID: 5671 RVA: 0x000DC8FD File Offset: 0x000DAAFD
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C5 RID: 965
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DC909 File Offset: 0x000DAB09
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DC915 File Offset: 0x000DAB15
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
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DC922 File Offset: 0x000DAB22
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DC92E File Offset: 0x000DAB2E
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
	// (get) Token: 0x0600162C RID: 5676 RVA: 0x000DC93B File Offset: 0x000DAB3B
	// (set) Token: 0x0600162D RID: 5677 RVA: 0x000DC947 File Offset: 0x000DAB47
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
	// (get) Token: 0x0600162E RID: 5678 RVA: 0x000DC954 File Offset: 0x000DAB54
	// (set) Token: 0x0600162F RID: 5679 RVA: 0x000DC960 File Offset: 0x000DAB60
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
	// (get) Token: 0x06001630 RID: 5680 RVA: 0x000DC96D File Offset: 0x000DAB6D
	// (set) Token: 0x06001631 RID: 5681 RVA: 0x000DC979 File Offset: 0x000DAB79
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
	// (get) Token: 0x06001632 RID: 5682 RVA: 0x000DC986 File Offset: 0x000DAB86
	// (set) Token: 0x06001633 RID: 5683 RVA: 0x000DC992 File Offset: 0x000DAB92
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
	// (get) Token: 0x06001634 RID: 5684 RVA: 0x000DC99F File Offset: 0x000DAB9F
	// (set) Token: 0x06001635 RID: 5685 RVA: 0x000DC9AB File Offset: 0x000DABAB
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
	// (get) Token: 0x06001636 RID: 5686 RVA: 0x000DC9B8 File Offset: 0x000DABB8
	// (set) Token: 0x06001637 RID: 5687 RVA: 0x000DC9C4 File Offset: 0x000DABC4
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
	// (get) Token: 0x06001638 RID: 5688 RVA: 0x000DC9D1 File Offset: 0x000DABD1
	// (set) Token: 0x06001639 RID: 5689 RVA: 0x000DC9DD File Offset: 0x000DABDD
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
	// (get) Token: 0x0600163A RID: 5690 RVA: 0x000DC9EA File Offset: 0x000DABEA
	// (set) Token: 0x0600163B RID: 5691 RVA: 0x000DC9F6 File Offset: 0x000DABF6
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

	// Token: 0x0600163C RID: 5692 RVA: 0x000DCA04 File Offset: 0x000DAC04
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

	// Token: 0x04002211 RID: 8721
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002212 RID: 8722
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x04002213 RID: 8723
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x04002214 RID: 8724
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x04002215 RID: 8725
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x04002216 RID: 8726
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x04002217 RID: 8727
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x04002218 RID: 8728
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x04002219 RID: 8729
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x0400221A RID: 8730
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x0400221B RID: 8731
	private const string Str_MultiMission = "MultiMission";
}
