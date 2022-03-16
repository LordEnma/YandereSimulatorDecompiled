using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000346 RID: 838
[Serializable]
public class TopicJson : JsonData
{
	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x0600193B RID: 6459 RVA: 0x000FC94D File Offset: 0x000FAB4D
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

	// Token: 0x0600193C RID: 6460 RVA: 0x000FC978 File Offset: 0x000FAB78
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
	// (get) Token: 0x0600193D RID: 6461 RVA: 0x000FC9FD File Offset: 0x000FABFD
	public int[] Topics
	{
		get
		{
			return this.topics;
		}
	}

	// Token: 0x04002791 RID: 10129
	[SerializeField]
	private int[] topics;
}
