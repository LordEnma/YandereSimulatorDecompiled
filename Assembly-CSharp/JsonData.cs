using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000343 RID: 835
public abstract class JsonData
{
	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x06001912 RID: 6418 RVA: 0x000FC49D File Offset: 0x000FA69D
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x06001913 RID: 6419 RVA: 0x000FC4AE File Offset: 0x000FA6AE
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
