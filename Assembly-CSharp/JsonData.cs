using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000346 RID: 838
public abstract class JsonData
{
	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x0600192D RID: 6445 RVA: 0x000FDDCD File Offset: 0x000FBFCD
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x0600192E RID: 6446 RVA: 0x000FDDDE File Offset: 0x000FBFDE
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
