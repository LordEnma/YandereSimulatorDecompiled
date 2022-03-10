using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000346 RID: 838
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001934 RID: 6452 RVA: 0x000FC191 File Offset: 0x000FA391
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

	// Token: 0x06001935 RID: 6453 RVA: 0x000FC1BC File Offset: 0x000FA3BC
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
	// (get) Token: 0x06001936 RID: 6454 RVA: 0x000FC241 File Offset: 0x000FA441
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x04002774 RID: 10100
	[SerializeField]
	private int[] topics;
}
