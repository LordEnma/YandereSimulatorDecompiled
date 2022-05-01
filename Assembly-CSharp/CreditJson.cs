using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000347 RID: 839
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x0600194A RID: 6474 RVA: 0x000FD7E0 File Offset: 0x000FB9E0
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x0600194B RID: 6475 RVA: 0x000FD7F4 File Offset: 0x000FB9F4
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

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x0600194C RID: 6476 RVA: 0x000FD859 File Offset: 0x000FBA59
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x0600194D RID: 6477 RVA: 0x000FD861 File Offset: 0x000FBA61
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x040027B6 RID: 10166
	[SerializeField]
	private string name;

	// Token: 0x040027B7 RID: 10167
	[SerializeField]
	private int size;
}
