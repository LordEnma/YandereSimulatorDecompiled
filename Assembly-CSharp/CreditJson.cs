using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000342 RID: 834
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06001916 RID: 6422 RVA: 0x000FA588 File Offset: 0x000F8788
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001917 RID: 6423 RVA: 0x000FA59C File Offset: 0x000F879C
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

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06001918 RID: 6424 RVA: 0x000FA601 File Offset: 0x000F8801
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06001919 RID: 6425 RVA: 0x000FA609 File Offset: 0x000F8809
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x04002732 RID: 10034
	[SerializeField]
	private string name;

	// Token: 0x04002733 RID: 10035
	[SerializeField]
	private int size;
}
