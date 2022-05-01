using System;
using UnityEngine;

// Token: 0x020004A1 RID: 1185
public static class GameObjectUtils
{
	// Token: 0x06001F8E RID: 8078 RVA: 0x001BF894 File Offset: 0x001BDA94
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F8F RID: 8079 RVA: 0x001BF8F8 File Offset: 0x001BDAF8
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
