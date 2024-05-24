using UnityEngine;

public class ToggleRendererScript : MonoBehaviour
{
	public Renderer MyRenderer;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			MyRenderer.enabled = !MyRenderer.enabled;
		}
	}
}
