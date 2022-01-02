using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000340 RID: 832
public abstract class JsonData
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x060018F4 RID: 6388 RVA: 0x000FA41D File Offset: 0x000F861D
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x060018F5 RID: 6389 RVA: 0x000FA42E File Offset: 0x000F862E
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
