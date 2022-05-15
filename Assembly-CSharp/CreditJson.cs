using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000348 RID: 840
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001950 RID: 6480 RVA: 0x000FDFE8 File Offset: 0x000FC1E8
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001951 RID: 6481 RVA: 0x000FDFFC File Offset: 0x000FC1FC
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
	// (get) Token: 0x06001952 RID: 6482 RVA: 0x000FE061 File Offset: 0x000FC261
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x06001953 RID: 6483 RVA: 0x000FE069 File Offset: 0x000FC269
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x040027C7 RID: 10183
	[SerializeField]
	private string name;

	// Token: 0x040027C8 RID: 10184
	[SerializeField]
	private int size;
}
