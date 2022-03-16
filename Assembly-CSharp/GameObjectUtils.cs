using System;
using UnityEngine;

// Token: 0x0200049C RID: 1180
public static class GameObjectUtils
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x001BC068 File Offset: 0x001BA268
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x001BC0CC File Offset: 0x001BA2CC
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
