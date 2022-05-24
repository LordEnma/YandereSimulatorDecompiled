using System;
using UnityEngine;

// Token: 0x020004A2 RID: 1186
public static class GameObjectUtils
{
	// Token: 0x06001F99 RID: 8089 RVA: 0x001C0FA4 File Offset: 0x001BF1A4
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F9A RID: 8090 RVA: 0x001C1008 File Offset: 0x001BF208
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
