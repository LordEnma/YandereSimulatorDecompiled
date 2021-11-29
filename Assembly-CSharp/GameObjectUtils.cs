using System;
using UnityEngine;

// Token: 0x02000493 RID: 1171
public static class GameObjectUtils
{
	// Token: 0x06001F27 RID: 7975 RVA: 0x001B5E70 File Offset: 0x001B4070
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x001B5ED4 File Offset: 0x001B40D4
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
