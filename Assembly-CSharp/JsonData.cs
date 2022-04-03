using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000344 RID: 836
public abstract class JsonData
{
	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x06001918 RID: 6424 RVA: 0x000FCB29 File Offset: 0x000FAD29
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x06001919 RID: 6425 RVA: 0x000FCB3A File Offset: 0x000FAD3A
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
