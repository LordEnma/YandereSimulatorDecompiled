using System;
using System.Collections.Generic;

// Token: 0x020002EE RID: 750
public static class ConversationGlobals
{
	// Token: 0x06001583 RID: 5507 RVA: 0x000DA7D4 File Offset: 0x000D89D4
	public static bool GetTopicDiscovered(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + topicID.ToString());
	}

	// Token: 0x06001584 RID: 5508 RVA: 0x000DA80C File Offset: 0x000D8A0C
	public static void SetTopicDiscovered(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + text, value);
	}

	// Token: 0x06001585 RID: 5509 RVA: 0x000DA868 File Offset: 0x000D8A68
	public static int[] KeysOfTopicDiscovered()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_");
	}

	// Token: 0x06001586 RID: 5510 RVA: 0x000DA898 File Offset: 0x000D8A98
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

	// Token: 0x06001587 RID: 5511 RVA: 0x000DA8F4 File Offset: 0x000D8AF4
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

	// Token: 0x06001588 RID: 5512 RVA: 0x000DA980 File Offset: 0x000D8B80
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

	// Token: 0x06001589 RID: 5513 RVA: 0x000DA9E8 File Offset: 0x000D8BE8
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

	// Token: 0x040021EA RID: 8682
	private const string Str_TopicDiscovered = "TopicDiscovered_";

	// Token: 0x040021EB RID: 8683
	private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";
}
