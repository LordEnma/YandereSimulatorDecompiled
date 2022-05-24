using System;
using System.Collections.Generic;

// Token: 0x020002F1 RID: 753
public static class ConversationGlobals
{
	// Token: 0x06001597 RID: 5527 RVA: 0x000DB8E8 File Offset: 0x000D9AE8
	public static bool GetTopicDiscovered(int topicID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + topicID.ToString());
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x000DB920 File Offset: 0x000D9B20
	public static void SetTopicDiscovered(int topicID, bool value)
	{
		string text = topicID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_" + text, value);
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x000DB97C File Offset: 0x000D9B7C
	public static int[] KeysOfTopicDiscovered()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TopicDiscovered_");
	}

	// Token: 0x0600159A RID: 5530 RVA: 0x000DB9AC File Offset: 0x000D9BAC
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

	// Token: 0x0600159B RID: 5531 RVA: 0x000DBA08 File Offset: 0x000D9C08
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

	// Token: 0x0600159C RID: 5532 RVA: 0x000DBA94 File Offset: 0x000D9C94
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

	// Token: 0x0600159D RID: 5533 RVA: 0x000DBAFC File Offset: 0x000D9CFC
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

	// Token: 0x0400220F RID: 8719
	private const string Str_TopicDiscovered = "TopicDiscovered_";

	// Token: 0x04002210 RID: 8720
	private const string Str_TopicLearnedByStudent = "TopicLearnedByStudent_";
}
