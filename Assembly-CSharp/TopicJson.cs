using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000343 RID: 835
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x0600191D RID: 6429 RVA: 0x000FA8CD File Offset: 0x000F8ACD
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Topics.json");
		}
	}

	// Token: 0x0600191E RID: 6430 RVA: 0x000FA8E0 File Offset: 0x000F8AE0
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
	// (get) Token: 0x0600191F RID: 6431 RVA: 0x000FA965 File Offset: 0x000F8B65
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x04002738 RID: 10040
	[SerializeField]
	private int[] topics;
}
