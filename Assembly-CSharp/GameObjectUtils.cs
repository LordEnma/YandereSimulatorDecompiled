using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public static class GameObjectUtils
{
	// Token: 0x06001F41 RID: 8001 RVA: 0x001B8754 File Offset: 0x001B6954
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x001B87B8 File Offset: 0x001B69B8
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
