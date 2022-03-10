using System;
using UnityEngine;

// Token: 0x02000499 RID: 1177
public static class GameObjectUtils
{
	// Token: 0x06001F5B RID: 8027 RVA: 0x001BA8E8 File Offset: 0x001B8AE8
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x001BA94C File Offset: 0x001B8B4C
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
