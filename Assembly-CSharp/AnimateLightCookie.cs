using UnityEngine;

public class AnimateLightCookie : MonoBehaviour
{
	public Light spotLight;

	public Vector2 speed = new Vector2(0.1f, 0.1f);

	private Material cookieMaterial;

	private Vector2 uvOffset = Vector2.zero;

	private void Start()
	{
		if (spotLight == null || spotLight.cookie == null)
		{
			Debug.LogError("Luz ou Cookie não atribuído!");
			return;
		}
		cookieMaterial = new Material(Shader.Find("Unlit/Texture"));
		cookieMaterial.mainTexture = spotLight.cookie;
		spotLight.cookie = cookieMaterial.mainTexture;
	}

	private void Update()
	{
		if (cookieMaterial != null)
		{
			uvOffset += speed * Time.deltaTime;
			cookieMaterial.SetTextureOffset("_MainTex", uvOffset);
		}
	}
}
