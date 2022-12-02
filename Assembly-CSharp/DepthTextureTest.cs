using UnityEngine;

public class DepthTextureTest : MonoBehaviour
{
	public Camera mainCamera;

	public void Update()
	{
		if (mainCamera.depthTextureMode != 0)
		{
			mainCamera.depthTextureMode = DepthTextureMode.None;
		}
	}
}
