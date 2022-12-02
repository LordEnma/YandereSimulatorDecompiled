using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
	public Renderer MyRenderer;

	public float Offset;

	public float Speed;

	private void Start()
	{
		MyRenderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		Offset += Time.deltaTime * Speed;
		MyRenderer.material.SetTextureOffset("_MainTex", new Vector2(Offset, Offset));
	}
}
