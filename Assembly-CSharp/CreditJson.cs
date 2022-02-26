using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000345 RID: 837
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x0600192F RID: 6447 RVA: 0x000FBDC0 File Offset: 0x000F9FC0
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001930 RID: 6448 RVA: 0x000FBDD4 File Offset: 0x000F9FD4
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
	// (get) Token: 0x06001931 RID: 6449 RVA: 0x000FBE39 File Offset: 0x000FA039
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06001932 RID: 6450 RVA: 0x000FBE41 File Offset: 0x000FA041
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x0400275C RID: 10076
	[SerializeField]
	private string name;

	// Token: 0x0400275D RID: 10077
	[SerializeField]
	private int size;
}
