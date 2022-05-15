using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class MissionModeGlobals
{
	// Token: 0x0600163E RID: 5694 RVA: 0x000DE025 File Offset: 0x000DC225
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x0600163F RID: 5695 RVA: 0x000DE040 File Offset: 0x000DC240
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001640 RID: 5696 RVA: 0x000DE071 File Offset: 0x000DC271
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x06001641 RID: 5697 RVA: 0x000DE07D File Offset: 0x000DC27D
	// (set) Token: 0x06001642 RID: 5698 RVA: 0x000DE089 File Offset: 0x000DC289
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
	// (get) Token: 0x06001643 RID: 5699 RVA: 0x000DE096 File Offset: 0x000DC296
	// (set) Token: 0x06001644 RID: 5700 RVA: 0x000DE0A2 File Offset: 0x000DC2A2
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
	// (get) Token: 0x06001645 RID: 5701 RVA: 0x000DE0AF File Offset: 0x000DC2AF
	// (set) Token: 0x06001646 RID: 5702 RVA: 0x000DE0BB File Offset: 0x000DC2BB
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
	// (get) Token: 0x06001647 RID: 5703 RVA: 0x000DE0C8 File Offset: 0x000DC2C8
	// (set) Token: 0x06001648 RID: 5704 RVA: 0x000DE0D4 File Offset: 0x000DC2D4
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
	// (get) Token: 0x06001649 RID: 5705 RVA: 0x000DE0E1 File Offset: 0x000DC2E1
	// (set) Token: 0x0600164A RID: 5706 RVA: 0x000DE0ED File Offset: 0x000DC2ED
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
	// (get) Token: 0x0600164B RID: 5707 RVA: 0x000DE0FA File Offset: 0x000DC2FA
	// (set) Token: 0x0600164C RID: 5708 RVA: 0x000DE106 File Offset: 0x000DC306
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
	// (get) Token: 0x0600164D RID: 5709 RVA: 0x000DE113 File Offset: 0x000DC313
	// (set) Token: 0x0600164E RID: 5710 RVA: 0x000DE11F File Offset: 0x000DC31F
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
	// (get) Token: 0x0600164F RID: 5711 RVA: 0x000DE12C File Offset: 0x000DC32C
	// (set) Token: 0x06001650 RID: 5712 RVA: 0x000DE138 File Offset: 0x000DC338
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
	// (get) Token: 0x06001651 RID: 5713 RVA: 0x000DE145 File Offset: 0x000DC345
	// (set) Token: 0x06001652 RID: 5714 RVA: 0x000DE151 File Offset: 0x000DC351
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
	// (get) Token: 0x06001653 RID: 5715 RVA: 0x000DE15E File Offset: 0x000DC35E
	// (set) Token: 0x06001654 RID: 5716 RVA: 0x000DE16A File Offset: 0x000DC36A
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

	// Token: 0x06001655 RID: 5717 RVA: 0x000DE178 File Offset: 0x000DC378
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

	// Token: 0x0400225A RID: 8794
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x0400225B RID: 8795
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x0400225C RID: 8796
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x0400225D RID: 8797
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x0400225E RID: 8798
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x0400225F RID: 8799
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x04002260 RID: 8800
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x04002261 RID: 8801
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x04002262 RID: 8802
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x04002263 RID: 8803
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x04002264 RID: 8804
	private const string Str_MultiMission = "MultiMission";
}
