using System;
using UnityEngine;

// Token: 0x020004A2 RID: 1186
public static class GameObjectUtils
{
	// Token: 0x06001F98 RID: 8088 RVA: 0x001C0B28 File Offset: 0x001BED28
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F99 RID: 8089 RVA: 0x001C0B8C File Offset: 0x001BED8C
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
