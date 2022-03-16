using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class MissionModeGlobals
{
	// Token: 0x0600162A RID: 5674 RVA: 0x000DD08D File Offset: 0x000DB28D
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x0600162B RID: 5675 RVA: 0x000DD0A8 File Offset: 0x000DB2A8
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x0600162C RID: 5676 RVA: 0x000DD0D9 File Offset: 0x000DB2D9
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x0600162D RID: 5677 RVA: 0x000DD0E5 File Offset: 0x000DB2E5
	// (set) Token: 0x0600162E RID: 5678 RVA: 0x000DD0F1 File Offset: 0x000DB2F1
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
	// (get) Token: 0x0600162F RID: 5679 RVA: 0x000DD0FE File Offset: 0x000DB2FE
	// (set) Token: 0x06001630 RID: 5680 RVA: 0x000DD10A File Offset: 0x000DB30A
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
	// (get) Token: 0x06001631 RID: 5681 RVA: 0x000DD117 File Offset: 0x000DB317
	// (set) Token: 0x06001632 RID: 5682 RVA: 0x000DD123 File Offset: 0x000DB323
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
	// (get) Token: 0x06001633 RID: 5683 RVA: 0x000DD130 File Offset: 0x000DB330
	// (set) Token: 0x06001634 RID: 5684 RVA: 0x000DD13C File Offset: 0x000DB33C
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
	// (get) Token: 0x06001635 RID: 5685 RVA: 0x000DD149 File Offset: 0x000DB349
	// (set) Token: 0x06001636 RID: 5686 RVA: 0x000DD155 File Offset: 0x000DB355
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
	// (get) Token: 0x06001637 RID: 5687 RVA: 0x000DD162 File Offset: 0x000DB362
	// (set) Token: 0x06001638 RID: 5688 RVA: 0x000DD16E File Offset: 0x000DB36E
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
	// (get) Token: 0x06001639 RID: 5689 RVA: 0x000DD17B File Offset: 0x000DB37B
	// (set) Token: 0x0600163A RID: 5690 RVA: 0x000DD187 File Offset: 0x000DB387
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
	// (get) Token: 0x0600163B RID: 5691 RVA: 0x000DD194 File Offset: 0x000DB394
	// (set) Token: 0x0600163C RID: 5692 RVA: 0x000DD1A0 File Offset: 0x000DB3A0
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
	// (get) Token: 0x0600163D RID: 5693 RVA: 0x000DD1AD File Offset: 0x000DB3AD
	// (set) Token: 0x0600163E RID: 5694 RVA: 0x000DD1B9 File Offset: 0x000DB3B9
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
	// (get) Token: 0x0600163F RID: 5695 RVA: 0x000DD1C6 File Offset: 0x000DB3C6
	// (set) Token: 0x06001640 RID: 5696 RVA: 0x000DD1D2 File Offset: 0x000DB3D2
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

	// Token: 0x06001641 RID: 5697 RVA: 0x000DD1E0 File Offset: 0x000DB3E0
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

	// Token: 0x04002236 RID: 8758
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002237 RID: 8759
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x04002238 RID: 8760
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x04002239 RID: 8761
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x0400223A RID: 8762
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x0400223B RID: 8763
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x0400223C RID: 8764
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x0400223D RID: 8765
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x0400223E RID: 8766
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x0400223F RID: 8767
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x04002240 RID: 8768
	private const string Str_MultiMission = "MultiMission";
}
