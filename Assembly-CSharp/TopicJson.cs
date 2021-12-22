using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000343 RID: 835
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x0600191B RID: 6427 RVA: 0x000FA619 File Offset: 0x000F8819
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Topics.json");
		}
	}

	// Token: 0x0600191C RID: 6428 RVA: 0x000FA62C File Offset: 0x000F882C
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
	// (get) Token: 0x0600191D RID: 6429 RVA: 0x000FA6B1 File Offset: 0x000F88B1
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x04002734 RID: 10036
	[SerializeField]
	private int[] topics;
}
