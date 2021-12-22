using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;

// Token: 0x02000340 RID: 832
public abstract class JsonData
{
	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x060018F2 RID: 6386 RVA: 0x000FA169 File Offset: 0x000F8369
	protected static string FolderPath
	{
		get
		{
			return Path.Combine(Application.streamingAssetsPath, "JSON");
		}
	}

	// Token: 0x060018F3 RID: 6387 RVA: 0x000FA17A File Offset: 0x000F837A
	protected static Dictionary<string, object>[] Deserialize(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
	}
}
