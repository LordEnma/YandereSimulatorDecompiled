using System;
using UnityEngine;

// Token: 0x020004A0 RID: 1184
public static class GameObjectUtils
{
	// Token: 0x06001F7F RID: 8063 RVA: 0x001BDAFC File Offset: 0x001BBCFC
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x001BDB60 File Offset: 0x001BBD60
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
