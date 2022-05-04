using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000345 RID: 837
public abstract class JsonData
{
	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06001926 RID: 6438 RVA: 0x000FD38D File Offset: 0x000FB58D
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x06001927 RID: 6439 RVA: 0x000FD39E File Offset: 0x000FB59E
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
