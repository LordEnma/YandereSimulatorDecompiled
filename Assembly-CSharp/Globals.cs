using System;
using UnityEngine;

// Token: 0x020002E9 RID: 745
public static class Globals
{
	// Token: 0x06001524 RID: 5412 RVA: 0x000D8A72 File Offset: 0x000D6C72
	public static bool KeyExists(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	// Token: 0x06001525 RID: 5413 RVA: 0x000D8A7C File Offset: 0x000D6C7C
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

	// Token: 0x06001526 RID: 5414 RVA: 0x000D8B0C File Offset: 0x000D6D0C
	public static void Delete(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	// Token: 0x06001527 RID: 5415 RVA: 0x000D8B14 File Offset: 0x000D6D14
	public static void DeleteCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x06001528 RID: 5416 RVA: 0x000D8B50 File Offset: 0x000D6D50
	public static void DeleteCollection(string key, string[] usedKeys)
	{
		foreach (string str in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + str);
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x06001529 RID: 5417 RVA: 0x000D8B83 File Offset: 0x000D6D83
	public static void Save()
	{
		PlayerPrefs.Save();
	}
}
