using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000348 RID: 840
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001951 RID: 6481 RVA: 0x000FE1EC File Offset: 0x000FC3EC
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001952 RID: 6482 RVA: 0x000FE200 File Offset: 0x000FC400
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

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06001953 RID: 6483 RVA: 0x000FE265 File Offset: 0x000FC465
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06001954 RID: 6484 RVA: 0x000FE26D File Offset: 0x000FC46D
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x040027CE RID: 10190
	[SerializeField]
	private string name;

	// Token: 0x040027CF RID: 10191
	[SerializeField]
	private int size;
}
