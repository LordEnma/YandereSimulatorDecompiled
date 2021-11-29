using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000342 RID: 834
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06001914 RID: 6420 RVA: 0x000F9E09 File Offset: 0x000F8009
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Topics.json");
		}
	}

	// Token: 0x06001915 RID: 6421 RVA: 0x000F9E1C File Offset: 0x000F801C
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

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06001916 RID: 6422 RVA: 0x000F9EA1 File Offset: 0x000F80A1
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x0400270F RID: 9999
	[SerializeField]
	private int[] topics;
}
