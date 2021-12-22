using System;
using System.Collections.Generic;

// Token: 0x020002EB RID: 747
public static class ConversationGlobals
{
	// Token: 0x0600156D RID: 5485 RVA: 0x000D8A70 File Offset: 0x000D6C70
	public static bool GetTopicDiscovered(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + topicID.ToString());
	}

	// Token: 0x0600156E RID: 5486 RVA: 0x000D8AA8 File Offset: 0x000D6CA8
	public static void SetTopicDiscovered(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + text, value);
	}

	// Token: 0x0600156F RID: 5487 RVA: 0x000D8B04 File Offset: 0x000D6D04
	public static int[] KeysOfTopicDiscovered()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_");
	}

	// Token: 0x06001570 RID: 5488 RVA: 0x000D8B34 File Offset: 0x000D6D34
	public static bool GetTopicLearnedByStudent(int topicID, int studentID)
	{
		return GlobalsHelper.GetBool(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_TopicLearnedByStudent_",
			topicID.ToString(),
			"_",
			studentID.ToString()
		}));
	}

	// Token: 0x06001571 RID: 5489 RVA: 0x000D8B90 File Offset: 0x000D6D90
	public static void SetTopicLearnedByStudent(int topicID, int studentID, bool value)
	{
		string text = topicID.ToString();
		string text2 = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_", text + "^" + text2);
		GlobalsHelper.SetBool(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_TopicLearnedByStudent_",
			text,
			"_",
			text2
		}), value);
	}

	// Token: 0x06001572 RID: 5490 RVA: 0x000D8C1C File Offset: 0x000D6E1C
	public static IntAndIntPair[] KeysOfTopicLearnedByStudent()
	{
		KeyValuePair<int, int>[] keys = KeysHelper.GetKeys<int, int>("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_");
		IntAndIntPair[] array = new IntAndIntPair[keys.Length];
		for (int i = 0; i < keys.Length; i++)
		{
			KeyValuePair<int, int> keyValuePair = keys[i];
			array[i] = new IntAndIntPair(keyValuePair.Key, keyValuePair.Value);
		}
		return array;
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x000D8C84 File Offset: 0x000D6E84
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_", ConversationGlobals.KeysOfTopicDiscovered());
		foreach (IntAndIntPair intAndIntPair in ConversationGlobals.KeysOfTopicLearnedByStudent())
		{
			Globals.Delete(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_TopicLearnedByStudent_",
				intAndIntPair.first.ToString(),
				"_",
				intAndIntPair.second.ToString()
			}));
		}
		KeysHelper.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TopicLearnedByStudent_");
	}

	// Token: 0x040021A0 RID: 8608
	private const string Str_TopicDiscovered = "TopicDiscovered_";

	// Token: 0x040021A1 RID: 8609
	private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";
}
