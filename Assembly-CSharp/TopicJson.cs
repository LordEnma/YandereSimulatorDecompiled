using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000347 RID: 839
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06001941 RID: 6465 RVA: 0x000FCFD9 File Offset: 0x000FB1D9
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

	// Token: 0x06001942 RID: 6466 RVA: 0x000FD004 File Offset: 0x000FB204
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

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06001943 RID: 6467 RVA: 0x000FD089 File Offset: 0x000FB289
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x040027A4 RID: 10148
	[SerializeField]
	private int[] topics;
}
