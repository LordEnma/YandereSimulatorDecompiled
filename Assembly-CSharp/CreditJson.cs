using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000342 RID: 834
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06001918 RID: 6424 RVA: 0x000FA83C File Offset: 0x000F8A3C
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001919 RID: 6425 RVA: 0x000FA850 File Offset: 0x000F8A50
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

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x0600191A RID: 6426 RVA: 0x000FA8B5 File Offset: 0x000F8AB5
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x0600191B RID: 6427 RVA: 0x000FA8BD File Offset: 0x000F8ABD
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x04002736 RID: 10038
	[SerializeField]
	private string name;

	// Token: 0x04002737 RID: 10039
	[SerializeField]
	private int size;
}
