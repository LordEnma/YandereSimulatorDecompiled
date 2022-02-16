using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000345 RID: 837
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x0600192B RID: 6443 RVA: 0x000FB521 File Offset: 0x000F9721
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

	// Token: 0x0600192C RID: 6444 RVA: 0x000FB54C File Offset: 0x000F974C
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

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x0600192D RID: 6445 RVA: 0x000FB5D1 File Offset: 0x000F97D1
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x0400274F RID: 10063
	[SerializeField]
	private int[] topics;
}
