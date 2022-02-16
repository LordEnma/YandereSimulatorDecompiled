using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000342 RID: 834
public abstract class JsonData
{
	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06001902 RID: 6402 RVA: 0x000FB071 File Offset: 0x000F9271
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x06001903 RID: 6403 RVA: 0x000FB082 File Offset: 0x000F9282
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
