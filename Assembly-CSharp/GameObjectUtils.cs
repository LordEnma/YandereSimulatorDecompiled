using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public static class GameObjectUtils
{
	// Token: 0x06001F3F RID: 7999 RVA: 0x001B7A84 File Offset: 0x001B5C84
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x001B7AE8 File Offset: 0x001B5CE8
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
