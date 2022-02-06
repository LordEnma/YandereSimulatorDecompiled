using System;
using UnityEngine;

// Token: 0x02000497 RID: 1175
public static class GameObjectUtils
{
	// Token: 0x06001F48 RID: 8008 RVA: 0x001B91A8 File Offset: 0x001B73A8
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F49 RID: 8009 RVA: 0x001B920C File Offset: 0x001B740C
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
