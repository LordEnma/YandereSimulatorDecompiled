using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000343 RID: 835
public abstract class JsonData
{
	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x0600190B RID: 6411 RVA: 0x000FB9A1 File Offset: 0x000F9BA1
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x0600190C RID: 6412 RVA: 0x000FB9B2 File Offset: 0x000F9BB2
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
