using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public static class GameObjectUtils
{
	// Token: 0x06001F43 RID: 8003 RVA: 0x001B8C7C File Offset: 0x001B6E7C
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F44 RID: 8004 RVA: 0x001B8CE0 File Offset: 0x001B6EE0
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
