using System;
using System.Collections.Generic;

// Token: 0x020002EC RID: 748
public static class ConversationGlobals
{
	// Token: 0x06001572 RID: 5490 RVA: 0x000D965C File Offset: 0x000D785C
	public static bool GetTopicDiscovered(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + topicID.ToString());
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x000D9694 File Offset: 0x000D7894
	public static void SetTopicDiscovered(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + text, value);
	}

	// Token: 0x06001574 RID: 5492 RVA: 0x000D96F0 File Offset: 0x000D78F0
	public static int[] KeysOfTopicDiscovered()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_");
	}

	// Token: 0x06001575 RID: 5493 RVA: 0x000D9720 File Offset: 0x000D7920
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

	// Token: 0x06001576 RID: 5494 RVA: 0x000D977C File Offset: 0x000D797C
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

	// Token: 0x06001577 RID: 5495 RVA: 0x000D9808 File Offset: 0x000D7A08
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

	// Token: 0x06001578 RID: 5496 RVA: 0x000D9870 File Offset: 0x000D7A70
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

	// Token: 0x040021B2 RID: 8626
	private const string Str_TopicDiscovered = "TopicDiscovered_";

	// Token: 0x040021B3 RID: 8627
	private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";
}
