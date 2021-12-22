using System;
using UnityEngine;

// Token: 0x020002F1 RID: 753
public static class MissionModeGlobals
{
	// Token: 0x0600160E RID: 5646 RVA: 0x000DB235 File Offset: 0x000D9435
	public static int GetMissionCondition(int id)
	{
		return PlayerPrefs.GetInt("MissionCondition_" + id.ToString());
	}

	// Token: 0x0600160F RID: 5647 RVA: 0x000DB250 File Offset: 0x000D9450
	public static void SetMissionCondition(int id, int value)
	{
		string text = id.ToString();
		KeysHelper.AddIfMissing("MissionCondition_", text);
		PlayerPrefs.SetInt("MissionCondition_" + text, value);
	}

	// Token: 0x06001610 RID: 5648 RVA: 0x000DB281 File Offset: 0x000D9481
	public static int[] KeysOfMissionCondition()
	{
		return KeysHelper.GetIntegerKeys("MissionCondition_");
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001611 RID: 5649 RVA: 0x000DB28D File Offset: 0x000D948D
	// (set) Token: 0x06001612 RID: 5650 RVA: 0x000DB299 File Offset: 0x000D9499
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
	// (get) Token: 0x06001613 RID: 5651 RVA: 0x000DB2A6 File Offset: 0x000D94A6
	// (set) Token: 0x06001614 RID: 5652 RVA: 0x000DB2B2 File Offset: 0x000D94B2
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
	// (get) Token: 0x06001615 RID: 5653 RVA: 0x000DB2BF File Offset: 0x000D94BF
	// (set) Token: 0x06001616 RID: 5654 RVA: 0x000DB2CB File Offset: 0x000D94CB
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
	// (get) Token: 0x06001617 RID: 5655 RVA: 0x000DB2D8 File Offset: 0x000D94D8
	// (set) Token: 0x06001618 RID: 5656 RVA: 0x000DB2E4 File Offset: 0x000D94E4
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
	// (get) Token: 0x06001619 RID: 5657 RVA: 0x000DB2F1 File Offset: 0x000D94F1
	// (set) Token: 0x0600161A RID: 5658 RVA: 0x000DB2FD File Offset: 0x000D94FD
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
	// (get) Token: 0x0600161B RID: 5659 RVA: 0x000DB30A File Offset: 0x000D950A
	// (set) Token: 0x0600161C RID: 5660 RVA: 0x000DB316 File Offset: 0x000D9516
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
	// (get) Token: 0x0600161D RID: 5661 RVA: 0x000DB323 File Offset: 0x000D9523
	// (set) Token: 0x0600161E RID: 5662 RVA: 0x000DB32F File Offset: 0x000D952F
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
	// (get) Token: 0x0600161F RID: 5663 RVA: 0x000DB33C File Offset: 0x000D953C
	// (set) Token: 0x06001620 RID: 5664 RVA: 0x000DB348 File Offset: 0x000D9548
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
	// (get) Token: 0x06001621 RID: 5665 RVA: 0x000DB355 File Offset: 0x000D9555
	// (set) Token: 0x06001622 RID: 5666 RVA: 0x000DB361 File Offset: 0x000D9561
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
	// (get) Token: 0x06001623 RID: 5667 RVA: 0x000DB36E File Offset: 0x000D956E
	// (set) Token: 0x06001624 RID: 5668 RVA: 0x000DB37A File Offset: 0x000D957A
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

	// Token: 0x06001625 RID: 5669 RVA: 0x000DB388 File Offset: 0x000D9588
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

	// Token: 0x040021E9 RID: 8681
	private const string Str_MissionCondition = "MissionCondition_";

	// Token: 0x040021EA RID: 8682
	private const string Str_MissionDifficulty = "MissionDifficulty";

	// Token: 0x040021EB RID: 8683
	private const string Str_MissionMode = "MissionMode";

	// Token: 0x040021EC RID: 8684
	private const string Str_MissionRequiredClothing = "MissionRequiredClothing";

	// Token: 0x040021ED RID: 8685
	private const string Str_MissionRequiredDisposal = "MissionRequiredDisposal";

	// Token: 0x040021EE RID: 8686
	private const string Str_MissionRequiredWeapon = "MissionRequiredWeapon";

	// Token: 0x040021EF RID: 8687
	private const string Str_MissionTarget = "MissionTarget";

	// Token: 0x040021F0 RID: 8688
	private const string Str_MissionTargetName = "MissionTargetName";

	// Token: 0x040021F1 RID: 8689
	private const string Str_NemesisDifficulty = "NemesisDifficulty";

	// Token: 0x040021F2 RID: 8690
	private const string Str_NemesisAggression = "NemesisAggression";

	// Token: 0x040021F3 RID: 8691
	private const string Str_MultiMission = "MultiMission";
}
