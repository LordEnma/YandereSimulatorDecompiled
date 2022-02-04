using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public static class GameObjectUtils
{
	// Token: 0x06001F45 RID: 8005 RVA: 0x001B8F88 File Offset: 0x001B7188
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x001B8FEC File Offset: 0x001B71EC
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
