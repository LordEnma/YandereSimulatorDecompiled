using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000348 RID: 840
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06001947 RID: 6471 RVA: 0x000FD0D9 File Offset: 0x000FB2D9
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

	// Token: 0x06001948 RID: 6472 RVA: 0x000FD104 File Offset: 0x000FB304
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
	// (get) Token: 0x06001949 RID: 6473 RVA: 0x000FD189 File Offset: 0x000FB389
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x040027A7 RID: 10151
	[SerializeField]
	private int[] topics;
}
