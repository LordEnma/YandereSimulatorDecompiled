using UnityEngine;

public static class TaskGlobals
{
	private const string Str_GuitarPhoto = "GuitarPhoto_";

	private const string Str_KittenPhoto = "KittenPhoto_";

	private const string Str_HorudaPhoto = "HorudaPhoto_";

	private const string Str_TaskStatus = "TaskStatus_";

	public static bool GetGuitarPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_GuitarPhoto_" + photoID);
	}

	public static void SetGuitarPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_GuitarPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_GuitarPhoto_" + text, value);
	}

	public static int[] KeysOfGuitarPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_GuitarPhoto_");
	}

	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_KittenPhoto_" + photoID);
	}

	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_KittenPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_KittenPhoto_" + text, value);
	}

	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_KittenPhoto_");
	}

	public static bool GetHorudaPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_HorudaPhoto_" + photoID);
	}

	public static void SetHorudaPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_HorudaPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_HorudaPhoto_" + text, value);
	}

	public static int[] KeysOfHorudaPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_HorudaPhoto_");
	}

	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile + "_TaskStatus_" + taskID);
	}

	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_TaskStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile + "_TaskStatus_" + text, value);
	}

	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_TaskStatus_");
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_GuitarPhoto_", KeysOfGuitarPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_KittenPhoto_", KeysOfKittenPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_HorudaPhoto_", KeysOfHorudaPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_TaskStatus_", KeysOfTaskStatus());
	}
}
