using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000344 RID: 836
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06001926 RID: 6438 RVA: 0x000FB490 File Offset: 0x000F9690
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001927 RID: 6439 RVA: 0x000FB4A4 File Offset: 0x000F96A4
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

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06001928 RID: 6440 RVA: 0x000FB509 File Offset: 0x000F9709
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06001929 RID: 6441 RVA: 0x000FB511 File Offset: 0x000F9711
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x0400274D RID: 10061
	[SerializeField]
	private string name;

	// Token: 0x0400274E RID: 10062
	[SerializeField]
	private int size;
}
