using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000341 RID: 833
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x0600190F RID: 6415 RVA: 0x000F9D78 File Offset: 0x000F7F78
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001910 RID: 6416 RVA: 0x000F9D8C File Offset: 0x000F7F8C
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
	// (get) Token: 0x06001911 RID: 6417 RVA: 0x000F9DF1 File Offset: 0x000F7FF1
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x06001912 RID: 6418 RVA: 0x000F9DF9 File Offset: 0x000F7FF9
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x0400270D RID: 9997
	[SerializeField]
	private string name;

	// Token: 0x0400270E RID: 9998
	[SerializeField]
	private int size;
}
