using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000345 RID: 837
public abstract class JsonData
{
	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x0600191E RID: 6430 RVA: 0x000FCC29 File Offset: 0x000FAE29
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x0600191F RID: 6431 RVA: 0x000FCC3A File Offset: 0x000FAE3A
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
