using UnityEngine;

public class PhotoSwapperScript : MonoBehaviour
{
	public Renderer[] PhotoRenderer;

	public Texture[] EightiesPhoto;

	private void Start()
	{
		for (int i = 1; i < PhotoRenderer.Length; i++)
		{
			PhotoRenderer[i].material.mainTexture = EightiesPhoto[i];
		}
	}
}
