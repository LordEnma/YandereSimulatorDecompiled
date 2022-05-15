using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000346 RID: 838
public abstract class JsonData
{
	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x0600192C RID: 6444 RVA: 0x000FDBC7 File Offset: 0x000FBDC7
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x0600192D RID: 6445 RVA: 0x000FDBD8 File Offset: 0x000FBDD8
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
