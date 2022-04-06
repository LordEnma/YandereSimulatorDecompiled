using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000347 RID: 839
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06001942 RID: 6466 RVA: 0x000FD048 File Offset: 0x000FB248
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001943 RID: 6467 RVA: 0x000FD05C File Offset: 0x000FB25C
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
	// (get) Token: 0x06001944 RID: 6468 RVA: 0x000FD0C1 File Offset: 0x000FB2C1
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001945 RID: 6469 RVA: 0x000FD0C9 File Offset: 0x000FB2C9
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x040027A5 RID: 10149
	[SerializeField]
	private string name;

	// Token: 0x040027A6 RID: 10150
	[SerializeField]
	private int size;
}
