using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000341 RID: 833
public abstract class JsonData
{
	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x060018FB RID: 6395 RVA: 0x000FAECD File Offset: 0x000F90CD
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x060018FC RID: 6396 RVA: 0x000FAEDE File Offset: 0x000F90DE
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
