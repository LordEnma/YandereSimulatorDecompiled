using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000348 RID: 840
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x0600194B RID: 6475 RVA: 0x000FD36D File Offset: 0x000FB56D
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

	// Token: 0x0600194C RID: 6476 RVA: 0x000FD398 File Offset: 0x000FB598
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

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x0600194D RID: 6477 RVA: 0x000FD41D File Offset: 0x000FB61D
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x040027AF RID: 10159
	[SerializeField]
	private int[] topics;
}
