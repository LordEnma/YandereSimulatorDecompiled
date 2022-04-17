using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000347 RID: 839
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x06001946 RID: 6470 RVA: 0x000FD2DC File Offset: 0x000FB4DC
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x06001947 RID: 6471 RVA: 0x000FD2F0 File Offset: 0x000FB4F0
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

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x06001948 RID: 6472 RVA: 0x000FD355 File Offset: 0x000FB555
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x06001949 RID: 6473 RVA: 0x000FD35D File Offset: 0x000FB55D
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x040027AD RID: 10157
	[SerializeField]
	private string name;

	// Token: 0x040027AE RID: 10158
	[SerializeField]
	private int size;
}
