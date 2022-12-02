using System.Collections.Generic;

public static class ConversationGlobals
{
	private const string Str_TopicDiscovered = "TopicDiscovered_";

	private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";

	public static bool GetTopicDiscovered(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_TopicDiscovered_" + topicID);
	}

	public static void SetTopicDiscovered(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_TopicDiscovered_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_TopicDiscovered_" + text, value);
	}

	public static int[] KeysOfTopicDiscovered()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile + "_TopicDiscovered_");
	}

	public static bool GetTopicLearnedByStudent(int topicID, int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile + "_TopicLearnedByStudent_" + topicID + "_" + studentID);
	}

	public static void SetTopicLearnedByStudent(int topicID, int studentID, bool value)
	{
		string text = topicID.ToString();
		string text2 = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile + "_TopicLearnedByStudent_", text + "^" + text2);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile + "_TopicLearnedByStudent_" + text + "_" + text2, value);
	}

	public static IntAndIntPair[] KeysOfTopicLearnedByStudent()
	{
		KeyValuePair<int, int>[] keys = KeysHelper.GetKeys<int, int>("Profile_" + GameGlobals.Profile + "_TopicLearnedByStudent_");
		IntAndIntPair[] array = new IntAndIntPair[keys.Length];
		for (int i = 0; i < keys.Length; i++)
		{
			KeyValuePair<int, int> keyValuePair = keys[i];
			array[i] = new IntAndIntPair(keyValuePair.Key, keyValuePair.Value);
		}
		return array;
	}

	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile + "_TopicDiscovered_", KeysOfTopicDiscovered());
		IntAndIntPair[] array = KeysOfTopicLearnedByStudent();
		foreach (IntAndIntPair intAndIntPair in array)
		{
			Globals.Delete("Profile_" + GameGlobals.Profile + "_TopicLearnedByStudent_" + intAndIntPair.first + "_" + intAndIntPair.second);
		}
		KeysHelper.Delete("Profile_" + GameGlobals.Profile + "_TopicLearnedByStudent_");
	}
}
