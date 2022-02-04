using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000341 RID: 833
public abstract class JsonData
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x060018F9 RID: 6393 RVA: 0x000FADC1 File Offset: 0x000F8FC1
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x060018FA RID: 6394 RVA: 0x000FADD2 File Offset: 0x000F8FD2
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
