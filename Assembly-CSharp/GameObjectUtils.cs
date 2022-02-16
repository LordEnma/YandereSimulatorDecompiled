using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
public static class GameObjectUtils
{
	// Token: 0x06001F4F RID: 8015 RVA: 0x001B95FC File Offset: 0x001B77FC
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F50 RID: 8016 RVA: 0x001B9660 File Offset: 0x001B7860
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
