using System;
using UnityEngine;

// Token: 0x020004A1 RID: 1185
public static class GameObjectUtils
{
	// Token: 0x06001F8F RID: 8079 RVA: 0x001BF990 File Offset: 0x001BDB90
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F90 RID: 8080 RVA: 0x001BF9F4 File Offset: 0x001BDBF4
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
