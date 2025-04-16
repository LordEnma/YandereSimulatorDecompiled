using UnityEngine;

public class DepthTextureTest : MonoBehaviour
{
	public Camera mainCamera;

	public void Update()
	{
		if (mainCamera.depthTextureMode != DepthTextureMode.None)
		{
			mainCamera.depthTextureMode = DepthTextureMode.None;
		}
	}
}
