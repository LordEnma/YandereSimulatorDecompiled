using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000348 RID: 840
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x0600194F RID: 6479 RVA: 0x000FD83D File Offset: 0x000FBA3D
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

	// Token: 0x06001950 RID: 6480 RVA: 0x000FD868 File Offset: 0x000FBA68
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
	// (get) Token: 0x06001951 RID: 6481 RVA: 0x000FD8ED File Offset: 0x000FBAED
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x040027B8 RID: 10168
	[SerializeField]
	private int[] topics;
}
