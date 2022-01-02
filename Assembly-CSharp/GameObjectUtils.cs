using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
public static class GameObjectUtils
{
	// Token: 0x06001F34 RID: 7988 RVA: 0x001B7104 File Offset: 0x001B5304
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F35 RID: 7989 RVA: 0x001B7168 File Offset: 0x001B5368
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
