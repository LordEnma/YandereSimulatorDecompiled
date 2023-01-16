using UnityEngine;

public class EightiesTextureSwapperScript : MonoBehaviour
{
	public Texture EightiesTexture;

	public Renderer MyRenderer;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			MyRenderer.material.mainTexture = EightiesTexture;
		}
	}
}
