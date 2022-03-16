using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000345 RID: 837
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06001936 RID: 6454 RVA: 0x000FC8BC File Offset: 0x000FAABC
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001937 RID: 6455 RVA: 0x000FC8D0 File Offset: 0x000FAAD0
	public static CreditJson[] LoadFromJson(string path)
	{
		List<CreditJson> list = new List<CreditJson>();
		foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
		{
			list.Add(new CreditJson
			{
				name = TFUtils.LoadString(dictionary, "Name"),
				size = TFUtils.LoadInt(dictionary, "Size")
			});
		}
		return list.ToArray();
	}

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06001938 RID: 6456 RVA: 0x000FC935 File Offset: 0x000FAB35
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001939 RID: 6457 RVA: 0x000FC93D File Offset: 0x000FAB3D
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x0400278F RID: 10127
	[SerializeField]
	private string name;

	// Token: 0x04002790 RID: 10128
	[SerializeField]
	private int size;
}
