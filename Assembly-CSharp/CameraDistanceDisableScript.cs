using UnityEngine;

public class CameraDistanceDisableScript : MonoBehaviour
{
	public Transform RenderTarget;

	public Transform Yandere;

	public Camera MyCamera;

	private void Update()
	{
		if (Vector3.Distance(Yandere.position, RenderTarget.position) > 15f)
		{
			MyCamera.enabled = false;
		}
		else
		{
			MyCamera.enabled = true;
		}
	}
}
