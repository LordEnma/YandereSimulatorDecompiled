using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
public static class GameObjectUtils
{
	// Token: 0x06001F31 RID: 7985 RVA: 0x001B6C2C File Offset: 0x001B4E2C
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x001B6C90 File Offset: 0x001B4E90
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
