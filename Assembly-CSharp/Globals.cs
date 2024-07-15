using UnityEngine;

public static class Globals
{
	public static bool KeyExists(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

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
		ChallengeGlobals.DeleteAll();
		DifficultyGlobals.DeleteAll();
		AudioGlobals.DeleteAll();
		GameGlobals.Profile = profile;
		DateGlobals.Week = 1;
		for (int i = 1; i < 101; i++)
		{
			StudentGlobals.SetStudentKidnapped(i, value: false);
			StudentGlobals.SetStudentArrested(i, value: false);
			StudentGlobals.SetStudentExpelled(i, value: false);
			StudentGlobals.SetStudentDead(i, value: false);
		}
	}

	public static void Delete(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public static void DeleteCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + num);
		}
		KeysHelper.Delete(key);
	}

	public static void DeleteCollection(string key, string[] usedKeys)
	{
		foreach (string text in usedKeys)
		{
			PlayerPrefs.DeleteKey(key + text);
		}
		KeysHelper.Delete(key);
	}

	public static void Save()
	{
		PlayerPrefs.Save();
	}
}
