using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000343 RID: 835
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x0600191F RID: 6431 RVA: 0x000FB2EC File Offset: 0x000F94EC
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001920 RID: 6432 RVA: 0x000FB300 File Offset: 0x000F9500
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

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06001921 RID: 6433 RVA: 0x000FB365 File Offset: 0x000F9565
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x06001922 RID: 6434 RVA: 0x000FB36D File Offset: 0x000F956D
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x04002747 RID: 10055
	[SerializeField]
	private string name;

	// Token: 0x04002748 RID: 10056
	[SerializeField]
	private int size;
}
