using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000349 RID: 841
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x06001956 RID: 6486 RVA: 0x000FE27D File Offset: 0x000FC47D
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

	// Token: 0x06001957 RID: 6487 RVA: 0x000FE2A8 File Offset: 0x000FC4A8
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

	// Token: 0x17000495 RID: 1173
	// (get) Token: 0x06001958 RID: 6488 RVA: 0x000FE32D File Offset: 0x000FC52D
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x040027D0 RID: 10192
	[SerializeField]
	private int[] topics;
}
