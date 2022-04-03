using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000346 RID: 838
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x0600193C RID: 6460 RVA: 0x000FCF48 File Offset: 0x000FB148
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x0600193D RID: 6461 RVA: 0x000FCF5C File Offset: 0x000FB15C
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
	// (get) Token: 0x0600193E RID: 6462 RVA: 0x000FCFC1 File Offset: 0x000FB1C1
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x0600193F RID: 6463 RVA: 0x000FCFC9 File Offset: 0x000FB1C9
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x040027A2 RID: 10146
	[SerializeField]
	private string name;

	// Token: 0x040027A3 RID: 10147
	[SerializeField]
	private int size;
}
