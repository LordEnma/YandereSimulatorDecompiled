using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x0200033F RID: 831
public abstract class JsonData
{
	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x060018EB RID: 6379 RVA: 0x000F9959 File Offset: 0x000F7B59
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x060018EC RID: 6380 RVA: 0x000F996A File Offset: 0x000F7B6A
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
