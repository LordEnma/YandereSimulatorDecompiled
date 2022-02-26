using System;
using UnityEngine;

// Token: 0x02000499 RID: 1177
public static class GameObjectUtils
{
	// Token: 0x06001F58 RID: 8024 RVA: 0x001BA148 File Offset: 0x001B8348
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F59 RID: 8025 RVA: 0x001BA1AC File Offset: 0x001B83AC
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
