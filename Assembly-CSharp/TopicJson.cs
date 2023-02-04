using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class TopicJson : JsonData
{
	[SerializeField]
	private int[] topics;

	public static string FilePath
	{
		get
		{
			if (!GameGlobals.Eighties)
			{
				return Path.Combine(JsonData.FolderPath, "Topics.json");
			}
			return Path.Combine(JsonData.FolderPath, "EightiesTopics.json");
		}
	}

	public int[] Topics => topics;

	public static TopicJson[] LoadFromJson(string path)
	{
		TopicJson[] array = new TopicJson[101];
		Dictionary<string, object>[] array2 = JsonData.Deserialize(path);
		foreach (Dictionary<string, object> d in array2)
		{
			int num = TFUtils.LoadInt(d, "ID");
			if (num == 0)
			{
				break;
			}
			array[num] = new TopicJson();
			TopicJson topicJson = array[num];
			topicJson.topics = new int[26];
			for (int j = 1; j <= 25; j++)
			{
				topicJson.topics[j] = TFUtils.LoadInt(d, j.ToString());
			}
		}
		return array;
	}
}
