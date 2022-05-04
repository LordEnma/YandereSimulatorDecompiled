using System;
using UnityEngine;

// Token: 0x020002F6 RID: 758
public static class MissionModeGlobals
{
	// Token: 0x0600163C RID: 5692 RVA: 0x000DDD21 File Offset: 0x000DBF21
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x0600163D RID: 5693 RVA: 0x000DDD3C File Offset: 0x000DBF3C
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x0600163E RID: 5694 RVA: 0x000DDD6D File Offset: 0x000DBF6D
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C6 RID: 966
	// (get) Token: 0x0600163F RID: 5695 RVA: 0x000DDD79 File Offset: 0x000DBF79
	// (set) Token: 0x06001640 RID: 5696 RVA: 0x000DDD85 File Offset: 0x000DBF85
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
	// (get) Token: 0x06001641 RID: 5697 RVA: 0x000DDD92 File Offset: 0x000DBF92
	// (set) Token: 0x06001642 RID: 5698 RVA: 0x000DDD9E File Offset: 0x000DBF9E
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
	// (get) Token: 0x06001643 RID: 5699 RVA: 0x000DDDAB File Offset: 0x000DBFAB
	// (set) Token: 0x06001644 RID: 5700 RVA: 0x000DDDB7 File Offset: 0x000DBFB7
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
	// (get) Token: 0x06001645 RID: 5701 RVA: 0x000DDDC4 File Offset: 0x000DBFC4
	// (set) Token: 0x06001646 RID: 5702 RVA: 0x000DDDD0 File Offset: 0x000DBFD0
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
	// (get) Token: 0x06001647 RID: 5703 RVA: 0x000DDDDD File Offset: 0x000DBFDD
	// (set) Token: 0x06001648 RID: 5704 RVA: 0x000DDDE9 File Offset: 0x000DBFE9
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
	// (get) Token: 0x06001649 RID: 5705 RVA: 0x000DDDF6 File Offset: 0x000DBFF6
	// (set) Token: 0x0600164A RID: 5706 RVA: 0x000DDE02 File Offset: 0x000DC002
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
	// (get) Token: 0x0600164B RID: 5707 RVA: 0x000DDE0F File Offset: 0x000DC00F
	// (set) Token: 0x0600164C RID: 5708 RVA: 0x000DDE1B File Offset: 0x000DC01B
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
	// (get) Token: 0x0600164D RID: 5709 RVA: 0x000DDE28 File Offset: 0x000DC028
	// (set) Token: 0x0600164E RID: 5710 RVA: 0x000DDE34 File Offset: 0x000DC034
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
	// (get) Token: 0x0600164F RID: 5711 RVA: 0x000DDE41 File Offset: 0x000DC041
	// (set) Token: 0x06001650 RID: 5712 RVA: 0x000DDE4D File Offset: 0x000DC04D
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
	// (get) Token: 0x06001651 RID: 5713 RVA: 0x000DDE5A File Offset: 0x000DC05A
	// (set) Token: 0x06001652 RID: 5714 RVA: 0x000DDE66 File Offset: 0x000DC066
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

	// Token: 0x06001653 RID: 5715 RVA: 0x000DDE74 File Offset: 0x000DC074
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

	// Token: 0x04002251 RID: 8785
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x04002252 RID: 8786
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x04002253 RID: 8787
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x04002254 RID: 8788
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x04002255 RID: 8789
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x04002256 RID: 8790
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x04002257 RID: 8791
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x04002258 RID: 8792
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x04002259 RID: 8793
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x0400225A RID: 8794
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x0400225B RID: 8795
	private const string Str_MultiMission = "MultiMission";
}
