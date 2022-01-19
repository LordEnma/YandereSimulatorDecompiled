using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000341 RID: 833
public abstract class JsonData
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x060018F8 RID: 6392 RVA: 0x000FA8CD File Offset: 0x000F8ACD
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x060018F9 RID: 6393 RVA: 0x000FA8DE File Offset: 0x000F8ADE
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
