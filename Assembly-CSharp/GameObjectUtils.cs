using System;
using UnityEngine;

// Token: 0x0200049F RID: 1183
public static class GameObjectUtils
{
	// Token: 0x06001F77 RID: 8055 RVA: 0x001BD5F4 File Offset: 0x001BB7F4
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F78 RID: 8056 RVA: 0x001BD658 File Offset: 0x001BB858
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
