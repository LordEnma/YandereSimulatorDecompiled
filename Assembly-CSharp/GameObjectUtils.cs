using UnityEngine;

public static class GameObjectUtils
{
	public static void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (Transform item in obj.transform)
		{
			SetLayerRecursively(item.gameObject, newLayer);
		}
	}

	public static void SetTagRecursively(GameObject obj, string newTag)
	{
		obj.tag = newTag;
		foreach (Transform item in obj.transform)
		{
			SetTagRecursively(item.gameObject, newTag);
		}
	}
}
