using System;
using UnityEngine;

// Token: 0x020004A0 RID: 1184
public static class GameObjectUtils
{
	// Token: 0x06001F85 RID: 8069 RVA: 0x001BE4D8 File Offset: 0x001BC6D8
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetLayerRecursively(((Transform)obj2).gameObject, newLayer);
		}
	}

	// Token: 0x06001F86 RID: 8070 RVA: 0x001BE53C File Offset: 0x001BC73C
	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (object obj2 in obj.transform)
		{
			GameObjectUtils.SetTagRecursively(((Transform)obj2).gameObject, newTag);
		}
	}
}
