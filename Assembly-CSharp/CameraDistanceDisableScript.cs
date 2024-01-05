using UnityEngine;

public class CameraDistanceDisableScript : MonoBehaviour
{
	public Transform RenderTarget;

	public Transform Yandere;

	public Renderer MyRenderer;

	public Camera MyCamera;

	private void Update()
	{
		if (Vector3.Distance(Yandere.position, RenderTarget.position) > 15f)
		{
			MyRenderer.enabled = false;
			MyCamera.enabled = false;
		}
		else
		{
			MyRenderer.enabled = true;
			MyCamera.enabled = true;
		}
	}
}
