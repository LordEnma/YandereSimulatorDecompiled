using UnityEngine;

public class CheapFilmGrainScript : MonoBehaviour
{
	public Renderer MyRenderer;

	public float Floor = 100f;

	public float Ceiling = 200f;

	private void Update()
	{
		MyRenderer.material.mainTextureScale = new Vector2(Random.Range(Floor, Ceiling), Random.Range(Floor, Ceiling));
	}
}
