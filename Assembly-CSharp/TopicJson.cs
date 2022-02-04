using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000344 RID: 836
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06001922 RID: 6434 RVA: 0x000FB271 File Offset: 0x000F9471
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

	// Token: 0x06001923 RID: 6435 RVA: 0x000FB29C File Offset: 0x000F949C
	public static TopicJson[] LoadFromJson(string path)
	{
		TopicJson[] array = new TopicJson[101];
		foreach (Dictionary<string, object> d in JsonData.Deserialize(path))
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

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06001924 RID: 6436 RVA: 0x000FB321 File Offset: 0x000F9521
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x04002746 RID: 10054
	[SerializeField]
	private int[] topics;
}
