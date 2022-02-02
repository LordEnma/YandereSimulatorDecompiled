using System;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public static class Globals
{
	// Token: 0x06001516 RID: 5398 RVA: 0x000D7BFE File Offset: 0x000D5DFE
	public static bool KeyExists(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	// Token: 0x06001517 RID: 5399 RVA: 0x000D7C08 File Offset: 0x000D5E08
	public static void DeleteAll()
	{
		int profile = GameGlobals.Profile;
		ClassGlobals.DeleteAll();
		ClubGlobals.DeleteAll();
		CollectibleGlobals.DeleteAll();
		ConversationGlobals.DeleteAll();
		DateGlobals.DeleteAll();
		DatingGlobals.DeleteAll();
		EventGlobals.DeleteAll();
		GameGlobals.DeleteAll();
		HomeGlobals.DeleteAll();
		MissionModeGlobals.DeleteAll();
		PlayerGlobals.DeleteAll();
		PoseModeGlobals.DeleteAll();
		SchemeGlobals.DeleteAll();
		SchoolGlobals.DeleteAll();
		SenpaiGlobals.DeleteAll();
		StudentGlobals.DeleteAll();
		TaskGlobals.DeleteAll();
		YanvaniaGlobals.DeleteAll();
		WeaponGlobals.DeleteAll();
		TutorialGlobals.DeleteAll();
		CounselorGlobals.DeleteAll();
		YancordGlobals.DeleteAll();
		CorkboardGlobals.DeleteAll();
		GameGlobals.Profile = profile;
		DateGlobals.Week = 1;
	}

	// Token: 0x06001518 RID: 5400 RVA: 0x000D7C98 File Offset: 0x000D5E98
	public static void Delete(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	// Token: 0x06001519 RID: 5401 RVA: 0x000D7CA0 File Offset: 0x000D5EA0
	public static void DeleteCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x0600151A RID: 5402 RVA: 0x000D7CDC File Offset: 0x000D5EDC
	public static void DeleteCollection(string key, string[] usedKeys)
	{
		foreach (string str in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + str);
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x0600151B RID: 5403 RVA: 0x000D7D0F File Offset: 0x000D5F0F
	public static void Save()
	{
		PlayerPrefs.Save();
	}
}
