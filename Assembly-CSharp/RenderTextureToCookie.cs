using UnityEngine;

public class RenderTextureToCookie : MonoBehaviour
{
	public Light targetLight;

	public RenderTexture renderTexture;

	private void Start()
	{
		if ((bool)renderTexture && (bool)targetLight)
		{
			Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, mipChain: false);
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = null;
			targetLight.cookie = texture2D;
			Debug.Log("Cookie atualizado com sucesso!");
		}
		else
		{
			Debug.LogError("RenderTexture ou Light não atribuídos!");
		}
	}
}
