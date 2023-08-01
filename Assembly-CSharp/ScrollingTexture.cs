using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
	public Renderer MyRenderer;

	public int MaterialID;

	public float Offset;

	public float Speed;

	private void Start()
	{
		MyRenderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		Offset += Time.deltaTime * Speed;
		MyRenderer.materials[MaterialID].SetTextureOffset("_MainTex", new Vector2(Offset, Offset));
	}
}
